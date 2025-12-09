export interface ShapeStyle {
  strokeColor?: string;     
  strokeOpacity?: number;   
  strokeWeight?: number;    
  fillColor?: string;       
  fillOpacity?: number;     
}


export interface MapElement {
    id: string;
    class?: 'farm' | 'plot' | 'diagnosis' | 'temporary' | null;
    label?: string;
    hasShapes?: boolean;
    style?: ShapeStyle;
    visible?: boolean;
    editable?: boolean;
    children?: MapElement[];
    hideShapeOnly?: boolean;
    type?: 'polygon' | 'marker' | null;
    mapObject?: any;
    info?: {
        id?: string;
        coordinates?: { lat: number; lng: number }[];
        name?: string;
        diseaseName?: string;
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
        perimeter?: number;
        photoUrl?: string;
    };
}