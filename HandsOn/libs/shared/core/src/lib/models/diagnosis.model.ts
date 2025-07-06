export interface Diagnosis {
    id: string;
    userId: string;
    farmId: string; 
    harvestId: string;
    plotId: string;
    uploadType: string | number;
    photoUrl: string;
    date: Date;
    status: string | number;
    result: string;
    latitude?: number;
    longitude?: number;
    createdAt: Date;
    updatedAt: Date;
}