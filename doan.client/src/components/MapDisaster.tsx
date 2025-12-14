import { MapContainer, TileLayer, Marker, Popup } from 'react-leaflet';
import { useEffect, useState } from 'react';
import L from 'leaflet';
import 'leaflet/dist/leaflet.css';

// Fix icon
delete (L.Icon.Default.prototype as any)._getIconUrl;
L.Icon.Default.mergeOptions({
  iconRetinaUrl: 'https://cdnjs.cloudflare.com/ajax/libs/leaflet/1.7.1/images/marker-icon-2x.png',
  iconUrl: 'https://cdnjs.cloudflare.com/ajax/libs/leaflet/1.7.1/images/marker-icon.png',
  shadowUrl: 'https://cdnjs.cloudflare.com/ajax/libs/leaflet/1.7.1/images/marker-shadow.png'
});

interface BaoCao {
  tieuDe: string;
  kinhDo: number;
  viDo: number;
  linkHinhAnh?: string;
}

export default function MapDisaster() {
  const [reports, setReports] = useState<BaoCao[]>([]);

  useEffect(() => {
    fetch('https://localhost:7274/api/Map/baocao') // ← thay 7274 bằng port backend của bạn
      .then(r => r.json())
      .then(setReports);
  }, []);

  return (
    <MapContainer center={[16.0, 107.0]} zoom={6} style={{ height: "90vh", width: "100%" }}>
      <TileLayer url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png" />
      {reports.map((r, i) => (
        <Marker key={i} position={[r.viDo, r.kinhDo]}>
          <Popup>
            <b>{r.tieuDe}</b><br />
            {r.linkHinhAnh && <img src={r.linkHinhAnh} alt="hiện trường" width={200} />}
          </Popup>
        </Marker>
      ))}
    </MapContainer>
  );
}