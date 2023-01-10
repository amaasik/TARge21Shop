using Microsoft.AspNetCore.Mvc;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;
using TARge21Shop.Models.Car;

namespace TARge21Shop.Controllers
{
    public class CarsController1 : Controller
    {
        private readonly TARge21ShopContext _context;
        private readonly ICarsServices _carsServices;

        public CarsController1
            (
                TARge21ShopContext context,
                ICarsServices carsServices
            )
        {
            _context = context;
            _carsServices = carsServices;
        }

        public IActionResult Index()
        {
            var result = _context.Cars
                .OrderByDescending(y => y.BuiltDate)
                .Select(x => new CarIndexViewModel
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Model = x.Model,
                    Color = x.Color,
                    FuelType = x.FuelType,
                    Price = x.Price,
                    EnginePower = x.EnginePower,
                    Mileage = x.Mileage,
                    BuiltDate= x.BuiltDate,
                    MaintanceDate= x.MaintanceDate,
                });

            return View(result);
        }
        [HttpGet]
        public IActionResult Add()
        {
            CarCreateUpdateViewModel car = new CarCreateUpdateViewModel();

            return View("CreateUpdate", car);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Brand = vm.Brand,
                Model = vm.Model,
                Color = vm.Color,
                FuelType = vm.FuelType,
                Price = vm.Price,
                EnginePower = vm.EnginePower,
                Mileage = vm.Mileage,
                BuiltDate = vm.BuiltDate,
                MaintanceDate = vm.MaintanceDate,
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

            var vm = new CarCreateUpdateViewModel()
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Color = car.Color,
                FuelType = car.FuelType,
                Price = car.Price,
                EnginePower = car.EnginePower,
                Mileage = car.Mileage,
                BuiltDate = car.BuiltDate,
                MaintanceDate = car.MaintanceDate,
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Brand = vm.Brand,
                Model = vm.Model,
                Color = vm.Color,
                FuelType = vm.FuelType,
                Price = vm.Price,
                EnginePower = vm.EnginePower,
                Mileage = vm.Mileage,
                BuiltDate = vm.BuiltDate,
                MaintanceDate = vm.MaintanceDate,
            };
            var result = await _carsServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var carId = await _carsServices.Delete(id);
            if (carId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
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
                Model = car.Model,
                Color = car.Color,
                FuelType = car.FuelType,
                Price = car.Price,
                EnginePower = car.EnginePower,
                Mileage = car.Mileage,
                BuiltDate = car.BuiltDate,
                MaintanceDate = car.MaintanceDate,
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
                Model = car.Model,
                Color = car.Color,
                FuelType = car.FuelType,
                Price = car.Price,
                EnginePower = car.EnginePower,
                Mileage = car.Mileage,
                BuiltDate = car.BuiltDate,
                MaintanceDate = car.MaintanceDate,
            };

            return View(vm);
        }
    }
}
