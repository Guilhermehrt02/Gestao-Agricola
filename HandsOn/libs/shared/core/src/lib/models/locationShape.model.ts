export interface LocationShapeData {
  id : string;
  type: 'polygon' | 'marker';
  label: string;
  coordinates: { lat: number; lng: number }[];
  color?: string;
  visible?: boolean;
  hasShapes?: boolean;
  info?: {
    diagnosisId?: string;
    diseaseName?: string;
    farmId?: string;
    plotId?: string;
    harvestId?: string;
  };
}
