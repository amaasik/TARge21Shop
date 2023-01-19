using Microsoft.AspNetCore.Mvc;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;
using TARge21Shop.Models.Car;

namespace TARge21Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly TARge21ShopContext _context;
        private readonly ICarServices _carsServices;

        public CarsController
            (
                TARge21ShopContext context,
                ICarServices carsServices
            )
        {
            _context = context;
            _carsServices = carsServices;
        }

        public IActionResult Index()
        {
            var result = _context.Cars
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new CarIndexViewModel
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Type = x.Type,
                    Model = x.Model,
                    Color = x.Color,
                    Price = x.Price,
                    HorsePower = x.HorsePower,
                    Weight = x.Weight
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            CarEditViewModel car = new CarEditViewModel();

            return View("Edit", car);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarEditViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Brand = vm.Brand,
                Type = vm.Type,
                Model = vm.Model,
                Color = vm.Color,
                Price = vm.Price,
                HorsePower = vm.HorsePower,
                Weight = vm.Weight,
                BuiltDate = vm.BuiltDate,
                LastMaintenance = vm.LastMaintenance,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt
            };

            var result = await _carsServices.Add(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var car = await _carsServices.GetUpdate(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarEditViewModel()
            {
                Id = car.Id,
                Brand = car.Brand,
                Type = car.Type,
                Model = car.Model,
                Color = car.Color,
                Price = car.Price,
                HorsePower = car.HorsePower,
                Weight = car.Weight,
                BuiltDate = car.BuiltDate,
                LastMaintenance = car.LastMaintenance,
                CreatedAt = car.CreatedAt,
                ModifiedAt = car.ModifiedAt
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarEditViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Brand = vm.Brand,
                Type = vm.Type,
                Model = vm.Model,
                Color = vm.Color,
                Price = vm.Price,
                HorsePower = vm.HorsePower,
                Weight = vm.Weight,
                BuiltDate = vm.BuiltDate,
                LastMaintenance = vm.LastMaintenance,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt
            };

            var result = await _carsServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var car = await _carsServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarDetailsViewModel()
            {
                Id = car.Id,
                Brand = car.Brand,
                Type = car.Type,
                Model = car.Model,
                Color = car.Color,
                Price = car.Price,
                HorsePower = car.HorsePower,
                Weight = car.Weight,
                BuiltDate = car.BuiltDate,
                LastMaintenance = car.LastMaintenance,
                CreatedAt = car.CreatedAt,
                ModifiedAt = car.ModifiedAt
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carsServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarDeleteViewModel()
            {
                Id = car.Id,
                Brand = car.Brand,
                Type = car.Type,
                Model = car.Model,
                Color = car.Color,
                Price = car.Price,
                HorsePower = car.HorsePower,
                Weight = car.Weight,
                BuiltDate = car.BuiltDate,
                LastMaintenance = car.LastMaintenance,
                CreatedAt = car.CreatedAt,
                ModifiedAt = car.ModifiedAt
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var carId = await _carsServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}