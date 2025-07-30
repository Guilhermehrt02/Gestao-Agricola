using Core.Entities;

namespace Application.ViewModels.FarmModels
{
    public class FarmDataModel
    {
        public string Name { get; set; } = string.Empty;
        public Guid Id { get; set; }

        public static FarmDataModel FromEntity(Farm farm)
        {
            return new FarmDataModel
            {
                Name = farm.Name,
                Id = farm.Id
            };
        }
    }
}