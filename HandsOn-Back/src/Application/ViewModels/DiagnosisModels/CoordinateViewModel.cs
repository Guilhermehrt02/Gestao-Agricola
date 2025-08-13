using Core.Entities;
using Core.Enums;
using Application.ViewModels.FarmModels;
using Application.ViewModels.HarvestModels;
using Application.ViewModels.PlotModels;

namespace Application.ViewModels
{
    public class CoordinateViewModel
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
        public static CoordinateViewModel FromEntity(Coordinate coordinate)
        {
            return new CoordinateViewModel
            {
                Lat = coordinate.Lat,
                Lng = coordinate.Lng,
            };
        }
    }
}