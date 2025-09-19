using Core.Entities;

namespace Application.ViewModels.DiagnosisModels
{
    public class LocationShapeViewModel
    {
        public string Type { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public List<CoordinateViewModel> Coordinates { get; set; } = new List<CoordinateViewModel>();

        public static LocationShapeViewModel FromEntity(LocationShape locationShape)
        {
            return new LocationShapeViewModel
            {
                Type = locationShape.Type,
                Label = locationShape.Label,
                Coordinates = locationShape.Coordinates.Select(CoordinateViewModel.FromEntity).ToList()
            };
        }
    }
}