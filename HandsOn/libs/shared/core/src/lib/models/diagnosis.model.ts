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
    result: DiagnosisResult;
    createdAt: Date;
    updatedAt: Date;
    locationShapes?: any;
}

export interface DiagnosisResult {
    imageSimilarities: Array<{
        imageBook: string;
        similarity: number;
        disease: Disease | null;
    }>;
}
export interface Disease {
    id: string;
    name: string;
    description: string;
    class: string;
    referenceImageUrl: string;
    createdAt: Date;
    updatedAt: Date;
    symptoms: string;
    prevention: string;
    recommendation: string;
}