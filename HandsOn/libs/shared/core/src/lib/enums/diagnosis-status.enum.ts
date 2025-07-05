export enum DiagnosisStatus {
    Pending = 'Pending',
    Processed = 'Processed',
    Error = 'Error',
}

export const DiagnosisStatusLabels: Record<DiagnosisStatus, string> = {
    [DiagnosisStatus.Pending]: 'Pendente',
    [DiagnosisStatus.Processed]: 'Processado',
    [DiagnosisStatus.Error]: 'Erro',
};