export interface Plot {
    id: string;
    farmId: string;
    name: string;
    area?: number;
    description?: string;
    latitude?: number;
    longitude?: number;
    createdAt: Date;
    updatedAt: Date;
    locationShapes?: any;
    totalArea?: number;
    affectedArea?: number;
}