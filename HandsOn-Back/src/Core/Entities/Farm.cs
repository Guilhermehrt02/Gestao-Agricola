namespace Core.Entities
{
    public class Farm
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; } // Referência ao usuário dono da fazenda
        public string Name { get; set; } = string.Empty; 
        public string? Location { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; 
        public DateTime UpdatedAt { get; set; } = DateTime.Now; 

        public Farm() { }

        public Farm(Guid userId, string name, string? location = null)
        {
            UserId = userId;
            Name = name;
            Location = location;
        }

        public void Update(string? name, string? location, Guid? userId = null)
        {
            Name = name ?? Name;
            Location = location ?? Location;
            UserId = userId ?? UserId;
            
            UpdatedAt = DateTime.Now;
        }
    }
}