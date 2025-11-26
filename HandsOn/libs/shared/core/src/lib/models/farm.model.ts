export interface Farm {
    id: string;
    userId: string;
    name: string;
    totalArea?: number;
    affectedArea?: number;
    perimeter?: number;
    location?: string;
    createdAt: Date;
    updatedAt: Date;
    locationShapes?: any;
}