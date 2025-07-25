export interface Farm {
    id: string;
    userId: string;
    name: string;
    location?: string;
    createdAt: Date;
    updatedAt: Date;
}