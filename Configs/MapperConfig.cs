using AutoMapper;
using CarStocksApi.DTO;
using CarStocksApi.Models;

namespace CarStocksApi.Configs
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<Car, CarDto>();
            CreateMap<CarDto, Car>();
        } 
    }
}
