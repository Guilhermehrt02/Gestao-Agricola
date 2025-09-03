using Core.Enums;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Application.InputModels.DiagnosisModels
{
    public class UpdateDiagnosisResultInputModel
    {
        [Required]
        public string Result { get; set; }
    }
}