using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Domain;
using TARge21Shop.Core.Domain.Car;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;

namespace TARge21Shop.ApplicationServices.Services
{
    public class CarsServices : ICarsServices
    {
        private readonly TARge21ShopContext _context;
        private readonly IFilesServices _files;

        public CarsServices
            (
                TARge21ShopContext context,
                IFilesServices files
            )
        {
            _context = context;
            _files = files;
        }


        public async Task<Car> Create(CarDto dto)
        {
            Car car = new Car();
            FileToDatabase file = new FileToDatabase();

            car.Id = Guid.NewGuid();
            car.Brand = dto.Brand;
            car.Type = dto.Type;
            car.Model = dto.Model;
            car.Color = dto.Color;
            car.Price = dto.Price;
            car.HorsePower = dto.HorsePower;
            car.Weight = dto.Weight;
            car.LastMaintenance = dto.LastMaintenance;
            car.BuiltDate = dto.BuiltDate;
            car.LastMaintenance= dto.LastMaintenance;
            car.CreatedAt = DateTime.Now;
            car.ModifiedAt = DateTime.Now;

            if (dto.Files != null)
            {
                _files.UploadFilesToDatabase(dto, car);
            }


            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }


        public async Task<Car> Update(CarDto dto)
        {
            var domain = new Car()
            {
                Id = dto.Id,
                Brand = dto.Brand,
                Type = dto.Type,
                Model = dto.Model,
                Color = dto.Color,
                Price = dto.Price,
                HorsePower = dto.HorsePower,
                Weight = dto.Weight,
                LastMaintenance = dto.LastMaintenance,
                BuiltDate = dto.BuiltDate,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = DateTime.Now,
            };
            if (dto.Files != null)
            {
                _files.UploadFilesToDatabase(dto, domain);
            }

            _context.Cars.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }


        public async Task<Car> Delete(Guid id)
        {
            var carId = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            var images = await _context.FileToDatabases
                .Where(x => x.CarId == id)
                .Select(y => new FileToDatabaseDto
                {
                    Id = y.Id,
                    ImageTitle = y.ImageTitle,
                    CarId = y.CarId,
                })
                .ToArrayAsync();

            await _files.RemoveImagesFromDatabase(images);
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