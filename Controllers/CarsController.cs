using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarStocksApi.Data;
using CarStocksApi.Models;
using CarStocksApi.Interfaces;
using CarStocksApi.Repository;
using CarStocksApi.DTO;
using Microsoft.AspNetCore.Authorization;

namespace CarStocksApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        public CarsController(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Car>))]
        public async Task<ActionResult<List<Car>>> GetCars()
        {
            try
            {
                var cars = await _carRepository.GetCars();
                var carTransfer = _mapper.Map<List<CarDto>>(cars);

                return Ok(cars);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }
        //PostApi for Add Car
        [HttpPost]
        public async Task<ActionResult<Car>> AddCar(CarDto carDto)
        {
            try
            {
                var carTransfer = _mapper.Map<Car>(carDto);
                await _carRepository.AddCar(carTransfer);
                return CreatedAtAction("GetCars", new { id = carTransfer.id }, carTransfer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        //DeleteApi for Delete car by id
        [HttpDelete("id")]
        public async Task<IActionResult> DeletCar(int id)
        {

            try
            {
                if (_carRepository.GetCars == null)
                {
                    return NotFound();
                }
                var cars = await _carRepository.GetCarAsync(id);
                if (cars == null)
                {
                    return NotFound();
                }
                await _carRepository.DeleteCar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

         }
        //PutApi for Update car stocks
        [HttpPut("update-stocks")]
        public async Task<IActionResult> UpdateCarStock(int id, StockDto stockDto)
        {
            try
            {
                await _carRepository.UpdateCarStock(id, stockDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //GetApi for searching by model
        [HttpGet("search-by-model")]
        public async Task<ActionResult<IEnumerable<Car>>> SearchModels(string model)
        {
            try
            {
                var result = await _carRepository.SearchModel(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        //GetApi for searching by manufactor 
        [HttpGet("search-by-make")]
        public async Task<ActionResult<IEnumerable<Car>>> SearchMakes(string make)
        {
            try
            {
                var result = await _carRepository.SearchMake(make);
                return Ok(result);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
