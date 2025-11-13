export interface MapLocation {
  type?: 'polygon' | 'marker';
  class?: 'farm' | 'plot' | 'diagnosis';
  hasShapes?: boolean;
  label?: string;
  coordinates?: { lat: number; lng: number }[];
  color?: string;
  visible?: boolean;
  info?: {
    id?: string;
    name?: string;
    farmId?: string;
    farmName?: string;
    plotId?: string;
    plotName?: string;
    harvestId?: string;
    harvestName?: string;
    status?: any;
    date?: Date;
    affectedArea?: number;
    totalArea?: number;
  };
}
