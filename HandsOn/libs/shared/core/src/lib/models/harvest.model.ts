export interface Harvest {
    id: string;
    name: string;
    farmId: string; 
    startDate?: Date;
    endDate?: Date;
    createdAt: Date;
    updatedAt: Date;
}