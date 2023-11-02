using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using AutoMapper;
using CarStocksApi.Data;
using CarStocksApi.Models;
using CarStocksApi.Interfaces;
using CarStocksApi.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace CarStocksApi.Repository
{
    public class CarRepository : ICarRepository
    {
        private DataContext _context;
        public CarRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Car>> GetCars()
        {
            return await _context.Set<Car>().ToListAsync();
        }
        public async Task<Car?> GetCarAsync(int? id)
        {
            if(id == null)
            {
                return null;
            }
            return await _context.Cars.FindAsync(id);
        }
        public async Task<Car> AddCar(Car car)
        {
            if(car == null)
            {
                throw new Exception($"Car does not exisit");
            }
            await _context.AddAsync(car);
            await _context.SaveChangesAsync();
            return car;
        }
        public async Task DeleteCar(int id)
        {
            var cars = await _context.Cars.FindAsync(id);
            if(cars == null)
            {
                throw new Exception($"Cannot find Car{id}.");
            }
            _context.Cars.Remove(cars);
            await _context.SaveChangesAsync();
        }
        public async Task<Car> UpdateCarStock(int id, StockDto stockDto)
        {
            var c = await _context.Cars.FindAsync(id);
            if (id != c.id)
            {
                throw new Exception($"Cannot find Car{id}"); 
            }
            var updateCar = await _context.Cars.FindAsync(id);
            if (updateCar == null)
            {
                throw new Exception($"Cannot find Car{id}");
            }

            c.Stocks = stockDto.Stocks;
            await _context.SaveChangesAsync();

            return updateCar;

        }
        public async Task<IEnumerable<Car>> SearchModel(string model)
        {
            IQueryable<Car> query = _context.Cars;
            if(!string.IsNullOrEmpty(model))
            {
                query = query.Where(e => e.Model.Contains(model));
            }
            var results = await query.ToListAsync();
            return results;
        }
        public async Task<IEnumerable<Car>> SearchMake(string make)
        {
            IQueryable<Car> query = _context.Cars;
            if (!string.IsNullOrEmpty(make))
            {
                query = query.Where(e => e.Make.Contains(make));
            }
            var results = await query.ToListAsync();
            return results;
        }
    }
}
