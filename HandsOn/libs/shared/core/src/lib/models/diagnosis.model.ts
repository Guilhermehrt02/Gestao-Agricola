export interface Diagnosis {
    id: string;
    userId: string;
    farm: { id: string; name: string; };
    harvest: { id: string; name: string; };
    plot: { id: string; name: string; };
    uploadType: string | number;
    photoUrl: string;
    date: Date;
    status: string | number;
    result: [{ imageBook: string; similarity: number }];
    createdAt: Date;
    updatedAt: Date;
    locationShapes?: any;
}