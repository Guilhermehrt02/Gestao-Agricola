export interface MapElement {
    id: string;
    class?: 'farm' | 'plot' | 'diagnosis' | null;
    label?: string;
    hasShapes?: boolean;
    color?: string;
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
        photoUrl?: string;
    };
}