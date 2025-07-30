using Core.Entities;

namespace Application.ViewModels
{
    public class HarvestViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid FarmId { get; set; } 
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public static HarvestViewModel FromEntity(Harvest harvest)
        {
            return new HarvestViewModel
            {
                Id = harvest.Id,
                Name = harvest.Name,
                FarmId = harvest.FarmId,
                StartDate = harvest.StartDate,
                EndDate = harvest.EndDate,
                CreatedAt = harvest.CreatedAt,
                UpdatedAt = harvest.UpdatedAt
            };
        }
    }
}