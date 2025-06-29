using System.ComponentModel.DataAnnotations;

namespace Application.InputModels.PlotModels
{
    public class UpdatePlotInputModel
    {
        [MaxLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string? Name { get; set; }

        public Guid? FarmId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Area must be a positive number.")]
        public double? Area { get; set; }

        [MaxLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string? Description { get; set; }

        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90 degrees.")]
        public double? Latitude { get; set; }
        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180 degrees.")]
        public double? Longitude { get; set; }
    }
}