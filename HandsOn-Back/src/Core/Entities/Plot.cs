namespace Core.Entities
{
    public class Plot // talhão, lote, área cultivada
    {
        public Guid Id { get; set; }
        public Guid FarmId { get; set; }
        public string Name { get; set; } = string.Empty; 
        public string? Description { get; set; } 
        public double? Area { get; set; } 
        public double? Latitude { get; set; }   // Coordenada GPS
        public double? Longitude { get; set; }  // Coordenada GPS
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public Plot() { }

        public Plot(Guid farmId, string name, double? area = null, string? description = null, double? latitude = null, double? longitude = null)
        {
            FarmId = farmId;
            Name = name;
            Area = area;
            Description = description;
            Latitude = latitude;
            Longitude = longitude;
        }

        public void Update(string? name, Guid? farmId, double? area, string? description, double? latitude = null, double? longitude = null)
        {
            Name = name ?? Name;
            FarmId = farmId ?? FarmId; 
            Area = area ?? Area;
            Description = description ?? Description;
            Latitude = latitude ?? Latitude;
            Longitude = longitude ?? Longitude;
            UpdatedAt = DateTime.Now; 
        }
    }
}