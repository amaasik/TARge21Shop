using Microsoft.AspNetCore.Mvc;
using TARge21Shop.ApplicationServices.Services;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;
using TARge21Shop.Models.RealEstate;
using TARge21Shop.Models.Spaceship;

namespace TARge21Shop.Controllers
{
    public class RealEstatesController : Controller
    {
        private readonly IRealEstatesServices _realEstatesServices;
        private readonly TARge21ShopContext _context;

        public RealEstatesController
            (
                IRealEstatesServices realEstatesServices,
                TARge21ShopContext context
            )
        {
            _realEstatesServices = realEstatesServices;
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.RealEstates
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new RealEstateIndexViewModel
                {
                    Id = x.Id,
                    Address = x.Address,
                    City = x.City,
                    Country = x.Country,
                    Size = x.Size,
                    Price = x.Price
                });

            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            RealEstateCreateUpdateViewModel vm = new RealEstateCreateUpdateViewModel();

            return View("CreateUpdate", vm);
        }

        [HttpPost]

        public async Task<IActionResult> Create(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Address=vm.Address,
                City=vm.City,
                Country=vm.Country,
                Size=vm.Size,
                Price=vm.Price,
                Floor=vm.Floor,
                Region=vm.Region,
                Phone=vm.Phone,
                Fax=vm.Fax,
                PostalCode=vm.PostalCode,
                RoomCount=vm.RoomCount,
                CreatedAt=vm.CreatedAt,
                ModifiedAt=vm.ModifiedAt
            };
            var result = await _realEstatesServices.Create(dto);
            
            if(result==null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var realEstate = await _realEstatesServices.GetAsync(id);

            if (realEstate == null)
            {
                return NotFound();
            }

            //var photos = await _context.FileToDatabases
            //    .Where(x => x.RealEstateId == id)
            //    .Select(y => new ImageViewModel
            //    {
            //        RealEstateId = y.Id,
            //        ImageId = y.Id,
            //        ImageData = y.ImageData,
            //        ImageTitle = y.ImageTitle,
            //        Image = string.Format("data:image/gif;base64, {0}", Convert.ToBase64String(y.ImageData))
            //    }).ToArrayAsync();

            var vm = new RealEstateCreateUpdateViewModel();

            vm.Id = id;
            vm.Address = realEstate.Address;
            vm.City = realEstate.City;
            vm.Region = realEstate.Region;
            vm.PostalCode = realEstate.PostalCode;
            vm.Country = realEstate.Country;
            vm.Phone = realEstate.Phone;
            vm.Fax = realEstate.Fax;
            vm.Size = realEstate.Size;
            vm.Floor = realEstate.Floor;
            vm.Price = realEstate.Price;
            vm.RoomCount = realEstate.RoomCount;
            vm.ModifiedAt = realEstate.ModifiedAt;
            vm.CreatedAt = realEstate.CreatedAt;
         //   vm.Image.AddRange(photos);

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Address = vm.Address,
                City = vm.City,
                Region = vm.Region,
                PostalCode = vm.PostalCode,
                Country = vm.Country,
                Phone = vm.Phone,
                Fax = vm.Fax,
                Size = vm.Size,
                Floor = vm.Floor,
                Price = vm.Price,
                RoomCount = vm.RoomCount,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                //Files = vm.Files,
                //Image = vm.Image.Select(x => new FileToDatabaseDto
                //{
                //    Id = x.ImageId,
                //    ImageData = x.ImageData,
                //    ImageTitle = x.ImageTitle,
                //    RealEstateId = x.RealEstateId,
                //}).ToArray()
            };

            var result = await _realEstatesServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var realEstate = await _realEstatesServices.GetAsync(id);

            if (realEstate == null)
            {
                return NotFound();
            }

            //var photos = await _context.FileToDatabases
            //    .Where(x => x.RealEstateId == id)
            //    .Select(y => new ImageViewModel
            //    {
            //        RealEstateId = y.Id,
            //        ImageId = y.Id,
            //        ImageData = y.ImageData,
            //        ImageTitle = y.ImageTitle,
            //        Image = string.Format("data:image/gif;base64, {0}", Convert.ToBase64String(y.ImageData))
            //    }).ToArrayAsync();

            var vm = new RealEstateDetailsViewModel();

            vm.Id = id;
            vm.Address = realEstate.Address;
            vm.City = realEstate.City;
            vm.Region = realEstate.Region;
            vm.PostalCode = realEstate.PostalCode;
            vm.Country = realEstate.Country;
            vm.Phone = realEstate.Phone;
            vm.Fax = realEstate.Fax;
            vm.Size = realEstate.Size;
            vm.Floor = realEstate.Floor;
            vm.Price = realEstate.Price;
            vm.RoomCount = realEstate.RoomCount;
            vm.ModifiedAt = realEstate.ModifiedAt;
            vm.CreatedAt = realEstate.CreatedAt;
         //   vm.Image.AddRange(photos);

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var realEstate = await _realEstatesServices.GetAsync(id);

            if (realEstate == null)
            {
                return NotFound();
            }

            //var photos = await _context.FileToDatabases
            //    .Where(x => x.RealEstateId == id)
            //    .Select(y => new ImageViewModel
            //    {
            //        RealEstateId = y.Id,
            //        ImageId = y.Id,
            //        ImageData = y.ImageData,
            //        ImageTitle = y.ImageTitle,
            //        Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
            //    }).ToArrayAsync();

            var vm = new RealEstateDeleteViewModel();

            vm.Id = id;
            vm.Address = realEstate.Address;
            vm.City = realEstate.City;
            vm.Region = realEstate.Region;
            vm.PostalCode = realEstate.PostalCode;
            vm.Country = realEstate.Country;
            vm.Phone = realEstate.Phone;
            vm.Fax = realEstate.Fax;
            vm.Size = realEstate.Size;
            vm.Floor = realEstate.Floor;
            vm.Price = realEstate.Price;
            vm.RoomCount = realEstate.RoomCount;
            vm.ModifiedAt = realEstate.ModifiedAt;
            vm.CreatedAt = realEstate.CreatedAt;
          //  vm.Image.AddRange(photos);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var realEstate = await _realEstatesServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        //[HttpPost]
        //public async Task<IActionResult> RemoveImage(ImageViewModel file)
        //{
        //    var dto = new FileToDatabaseDto() { Id = file.ImageId };
        //    var image = await _filesServices.RemoveImage(dto);

        //    return RedirectToAction(nameof(Index));
        //     return View("CreateUpdate", new { id = file.RealEstateId });
        //}
    }
}
