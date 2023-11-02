using CarStocksApi.DTO;
using CarStocksApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarStocksApi.Interfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCars();
        Task<Car?> GetCarAsync(int? id);
        Task<Car> AddCar(Car car);
        Task<Car> UpdateCarStock(int id, StockDto stkDto);
        Task<IEnumerable<Car>> SearchModel(string model);
        Task<IEnumerable<Car>> SearchMake(string make);
        Task DeleteCar(int id);
    }
}
