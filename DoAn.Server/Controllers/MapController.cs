using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoAn.Server.Data;

namespace DoAn.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MapController : ControllerBase
    {
        private readonly AppDbContext _db;
        public MapController(AppDbContext db) => _db = db;

        [HttpGet("baocao")]
        public async Task<IActionResult> GetBaoCao()
        {
            var data = await _db.BaoCaoHienTruong
                .Select(b => new {
                    b.TieuDe,
                    b.KinhDo,
                    b.ViDo,
                    b.LinkHinhAnh
                }).Take(500).ToListAsync();
            return Ok(data);
        }
    }
}