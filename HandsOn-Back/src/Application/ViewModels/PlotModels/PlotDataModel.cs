using Core.Entities;

namespace Application.ViewModels.PlotModels
{
    public class PlotDataModel
    {
        public string Name { get; set; } = string.Empty;
        public Guid Id { get; set; }

        public static PlotDataModel FromEntity(Plot plot)
        {
            return new PlotDataModel
            {
                Name = plot.Name,
                Id = plot.Id
            };
        }
    }
}
