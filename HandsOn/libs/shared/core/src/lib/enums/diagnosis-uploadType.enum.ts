export enum DiagnosisUploadType {
    Disease = 'Disease',
    Pest = 'Pest',
    Deficiency = 'Deficiency',
    Other = 'Other',
}
export const DiagnosisUploadTypeLabels: Record<DiagnosisUploadType, string> = {
    [DiagnosisUploadType.Disease]: 'Doença',
    [DiagnosisUploadType.Pest]: 'Praga',
    [DiagnosisUploadType.Deficiency]: 'Deficiência',
    [DiagnosisUploadType.Other]: 'Outro',
};