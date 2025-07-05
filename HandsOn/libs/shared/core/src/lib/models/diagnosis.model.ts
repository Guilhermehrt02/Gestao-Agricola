export interface Diagnosis {
    id: string;
    userId: string;
    farmId: string; // or reference to a Farm
    harvestId: string; // or reference to a Harvest
    plotId: string; // or reference to a Plot
    uploadType: string | number;
    photoUrl: string;
    date: Date;
    status: string | number;
    result: string;
    latitude?: number; // GPS coordinate
    longitude?: number; // GPS coordinate
    createdAt: Date;
    updatedAt: Date;
}