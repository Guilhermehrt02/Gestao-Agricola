namespace Core.Entities
{
    public class Harvest //colheita
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid FarmId { get; set; } 
        public DateTime? StartDate { get; set; } 
        public DateTime? EndDate { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public Harvest() { }

        public Harvest(Guid farmId, string name, DateTime? startDate, DateTime? endDate)
        {
            FarmId = farmId;
            Name = name;
            StartDate = startDate; 
            EndDate = endDate;
        }

        public void Update(string? name, DateTime? startDate, DateTime? endDate, Guid? farmId)
        {
            Name = name ?? Name;
            StartDate = startDate ?? StartDate;
            EndDate = endDate ?? EndDate;
            FarmId = farmId ?? FarmId;
            UpdatedAt = DateTime.Now;
        }
    }
}