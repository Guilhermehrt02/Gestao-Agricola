using Core.Entities;

namespace Application.ViewModels
{
    public class PlotViewModel
    {
        public Guid Id { get; set; }
        public Guid FarmId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public double? Area { get; set; }
        public double? Latitude { get; set; }   
        public double? Longitude { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public static PlotViewModel FromEntity(Plot plot)
        {
            return new PlotViewModel
            {
                Id = plot.Id,
                FarmId = plot.FarmId,
                Name = plot.Name,
                Description = plot.Description,
                Area = plot.Area,
                Latitude = plot.Latitude,
                Longitude = plot.Longitude,
                CreatedAt = plot.CreatedAt,
                UpdatedAt = plot.UpdatedAt
            };
        }
    }
}