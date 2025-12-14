using DoAn.Server.Data;
using DoAn.Server.Models;
using DoAn.Server.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DoAn.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            // 1. Kiểm tra dữ liệu đầu vào
            if (_context.NguoiDung.Any(u => u.TenDangNhap == model.Username))
            {
                return BadRequest(new { message = "Tên đăng nhập đã tồn tại." });
            }

            if (_context.NguoiDung.Any(u => u.Email == model.Email))
            {
                return BadRequest(new { message = "Email này đã được sử dụng." });
            }

            // 2. Lấy quyền mặc định (Ví dụ: "NguoiDan")
            // Bạn cần đảm bảo trong DB bảng VaiTro đã có dòng tên là "NguoiDan"
            var defaultRole = _context.VaiTro.FirstOrDefault(r => r.TenVaiTro == "NguoiDan");

            // Nếu chưa có role NguoiDan, có thể fallback về 1 role nào đó hoặc báo lỗi
            if (defaultRole == null)
            {
                return StatusCode(500, new { message = "Lỗi hệ thống: Chưa cấu hình vai trò mặc định (NguoiDan)." });
            }

            // 3. Tạo đối tượng người dùng mới
            var newUser = new NguoiDung
            {
                MaNguoiDung = Guid.NewGuid().ToString(), // Tạo ID ngẫu nhiên
                TenDangNhap = model.Username,
                // Mã hóa mật khẩu trước khi lưu
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
                HoTen = model.HoTen,
                Email = model.Email,
                AvatarUrl = "", // Avatar mặc định hoặc rỗng
                TrangThai = true, // Mặc định là 'Hoạt động'
                IsLocked = false,
                MaVaiTro = defaultRole.MaVaiTro,
                NgayTao = DateTime.Now // Nếu model có trường này
            };

            // 4. Lưu vào Database
            try
            {
                _context.NguoiDung.Add(newUser);
                _context.SaveChanges();

                return Ok(new { message = "Đăng ký thành công!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi lưu dữ liệu: " + ex.Message });
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var user = _context.NguoiDung
                .Include(u => u.VaiTro)
                .FirstOrDefault(u => u.TenDangNhap == model.Username && u.TrangThai);

            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                return Unauthorized(new { message = "Sai tài khoản hoặc mật khẩu" });

            if (user.IsLocked)
                return Unauthorized(new { message = "Tài khoản bị khóa" });

            // Tạo token
            var token = GenerateJwtToken(user);

            return Ok(new
            {
                token,
                user = new
                {
                    user.MaNguoiDung,
                    user.HoTen,
                    user.Email,
                    user.AvatarUrl,
                    role = user.VaiTro.TenVaiTro,
                    user.MaVaiTro
                }
            });
        }

        private string GenerateJwtToken(NguoiDung user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.MaNguoiDung),
                new Claim(ClaimTypes.Name, user.HoTen),
                new Claim(ClaimTypes.Role, user.VaiTro.TenVaiTro),
                new Claim("MaVaiTro", user.MaVaiTro)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [Authorize]
        [HttpPost("change-password")]
        public IActionResult ChangePassword([FromBody] ChangePasswordModel model)
        {
            // 1. Lấy ID người dùng từ Token (User.Identity)
            // Khi đăng nhập, ta đã lưu MaNguoiDung vào ClaimTypes.NameIdentifier
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "Không tìm thấy thông tin người dùng trong Token." });
            }

            // 2. Tìm người dùng trong Database
            var user = _context.NguoiDung.FirstOrDefault(u => u.MaNguoiDung == userId);

            if (user == null)
            {
                return NotFound(new { message = "Người dùng không tồn tại." });
            }

            // 3. Kiểm tra mật khẩu cũ có đúng không
            if (!BCrypt.Net.BCrypt.Verify(model.OldPassword, user.PasswordHash))
            {
                return BadRequest(new { message = "Mật khẩu cũ không chính xác." });
            }

            // 4. Kiểm tra mật khẩu mới không được trùng mật khẩu cũ (Tùy chọn)
            if (BCrypt.Net.BCrypt.Verify(model.NewPassword, user.PasswordHash))
            {
                return BadRequest(new { message = "Mật khẩu mới không được trùng với mật khẩu cũ." });
            }

            // 5. Mã hóa mật khẩu mới và lưu vào DB
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);

            try
            {
                _context.SaveChanges();
                return Ok(new { message = "Đổi mật khẩu thành công!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi cập nhật mật khẩu: " + ex.Message });
            }
        }
    }
}