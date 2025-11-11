export interface Farm {
    id: string;
    userId: string;
    name: string;
    totalArea?: number;
    affectedArea?: number;
    location?: string;
    createdAt: Date;
    updatedAt: Date;
    locationShapes?: any[];
}