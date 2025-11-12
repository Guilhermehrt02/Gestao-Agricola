export interface LocationShapeData {
  id : string;
  type: 'polygon' | 'marker';
  label: string;
  coordinates: { lat: number; lng: number }[];
  color?: string;
  diagnosisInfo?: {
    diagnosisId?: string;
    diseaseName?: string;
    farm?: string;
    plot?: string;
    harvest?: string;
  };
}
