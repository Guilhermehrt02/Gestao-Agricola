export interface FarmMapInput {
    startDate: Date;
    endDate: Date;
    farmId?: string | null;
    plotId?: string | null;
    harvestId?: string | null;
    diagnosisId?: string | null;
    diseaseId?: string | null;
    cultureId?: string | null;
    //fazenda, talhao, cultura, data e problema
}