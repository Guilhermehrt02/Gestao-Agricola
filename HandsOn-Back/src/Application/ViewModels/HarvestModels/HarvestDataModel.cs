using Core.Entities;

namespace Application.ViewModels.HarvestModels
{
    public class HarvestDataModel
    {
        public string Name { get; set; } = string.Empty;
        public Guid Id { get; set; }

        public static HarvestDataModel FromEntity(Harvest harvest)
        {
            return new HarvestDataModel
            {
                Name = harvest.Name,
                Id = harvest.Id
            };
        }
    }
}
