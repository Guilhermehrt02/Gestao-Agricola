namespace Core.Entities
{
    public class Farm
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; } 
        public string Name { get; set; } = string.Empty; 
        public string? Location { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now; 
        public List<LocationShape>? LocationShapes { get; set; }

        public Farm() { }

        public Farm(Guid userId, string name, string? location = null, List<LocationShape>? locationShapes = null)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Name = name;
            Location = location;
            LocationShapes = locationShapes;
        }

        public void Update(string? name, string? location, Guid? userId = null, List<LocationShape>? locationShapes = null)
        {
            Name = name ?? Name;
            Location = location ?? Location;
            UserId = userId ?? UserId;
            LocationShapes = locationShapes ?? LocationShapes;
            UpdatedAt = DateTime.Now;
        }
    }
}