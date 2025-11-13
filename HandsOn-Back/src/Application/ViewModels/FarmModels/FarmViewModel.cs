using Core.Entities;
using Application.ViewModels.DiagnosisModels;
namespace Application.ViewModels
{
    public class FarmViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Location { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<LocationShapeViewModel>? LocationShapes { get; set; }

        public static FarmViewModel FromEntity(Farm farm)
        {
            return new FarmViewModel
            {
                Id = farm.Id,
                UserId = farm.UserId,
                Name = farm.Name,
                Location = farm.Location,
                CreatedAt = farm.CreatedAt,
                UpdatedAt = farm.UpdatedAt,
                LocationShapes = farm.LocationShapes?
                    .Select(LocationShapeViewModel.FromEntity)
                    .ToList()
            };
        }
    }
}