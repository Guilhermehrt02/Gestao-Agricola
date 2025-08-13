export interface LocationShapeData {
  type: 'polygon' | 'marker';
  label: string;
  coordinates: { lat: number; lng: number }[];
}
