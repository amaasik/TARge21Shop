using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Domain;
using TARge21Shop.Core.Dto;
using TARge21Shop.Data;

namespace TARge21Shop.ApplicationServices.Services
{
	public class CarsServices
	{
		private readonly TARge21ShopContext _context;
		public CarsServices
			(
			TARge21ShopContext context
			)
		{
			_context = context;
		}

		public async Task<Car> Add(CarDto dto)
		{
			var domain = new Car()
			{
				Id = Guid.NewGuid(),
				Brand = dto.Brand,
				Model = dto.Model,
				Color = dto.Color,
				FuelType = dto.FuelType,
				Price = dto.Price,
				EnginePower = dto.EnginePower,
				Mileage = dto.Mileage,
				BuiltDate = DateTime.Now,
				MaintanceDate = DateTime.Now
			};

			await _context.Cars.AddAsync(domain);
			await _context.SaveChangesAsync();

			return domain;
		}

		public async Task<Car> Update(CarDto dto)
		{
			var domain = new Car()
			{
				Id = dto.Id,
				Brand = dto.Brand,
				Model = dto.Model,
				Color = dto.Color,
				FuelType = dto.FuelType,
				Price = dto.Price,
				EnginePower = dto.EnginePower,
				Mileage = dto.Mileage,
				BuiltDate = dto.BuiltDate,
				MaintanceDate = dto.MaintanceDate
			};

			_context.Cars.Update(domain);
			await _context.SaveChangesAsync();
			return domain;


		}
		public async Task<Car> GetUpdate(Guid id)
		{
			var result = await _context.Cars
				.FirstOrDefaultAsync(x => x.Id == id);

			return result;
		}

		public async Task<Car> Delete(Guid id)
		{
			var carId = await _context.Cars
				.FirstOrDefaultAsync(x => x.Id == id);

			_context.Cars.Remove(carId);
			await _context.SaveChangesAsync();

			return carId;
		}

		public async Task<Car> GetAsync(Guid id)
		{
			var result = await _context.Cars
				.FirstOrDefaultAsync(x => x.Id == id);

			return result;
		}
	}
}
