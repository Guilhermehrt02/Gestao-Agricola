
namespace Core.Entities
{
    public class Coordinate
    {
        public Guid Id { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public Guid LocationShapeId { get; set; }
    }
}