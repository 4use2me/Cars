using Cars.Data;
using Cars.Models.Cars;
using Microsoft.AspNetCore.Mvc;
using Cars.Core.Dto;
using Cars.Core.ServiceInterface;
using Cars.Core.Domain;

namespace Cars.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarsContext _context;
        private readonly ICarsServices _carServices;
        public CarsController
            (
            CarsContext context,
            ICarsServices carServices
            )
        {
            _context = context;
            _carServices = carServices;
        }
        public IActionResult Index()
        {
            var result = _context.Cars
                .Select(x => new CarsIndexViewModel
                {
                    Id = x.Id,
                    Make = x.Make,
                    Model = x.Model,
                    Year = x.Year,
                    Price = x.Price,
                    Mileage = x.Mileage,
                    Fuel = x.Fuel,
                    Color = x.Color,
                });
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var car = await _carServices.DetailAsync(id);
            if (car == null)
            {
                return View("Error");
            }
            var vm = new CarDetailsViewModel();
            vm.Id = car.Id;
            vm.Make = car.Make;
            vm.Model = car.Model;
            vm.Year = car.Year;
            vm.Price = car.Price;
            vm.Mileage = car.Mileage;
            vm.Fuel = car.Fuel;
            vm.Color = car.Color;
            vm.CreatedAt = car.CreatedAt;
            vm.ModifiedAt = car.ModifiedAt;
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _carServices.DetailAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var vm = new CarCreateUpdateViewModel();
            vm.Id = car.Id;
            vm.Make = car.Make;
            vm.Model = car.Model;
            vm.Year = car.Year;
            vm.Price = car.Price;
            vm.Mileage = car.Mileage;
            vm.Fuel = car.Fuel;
            vm.Color = car.Color;
            vm.CreatedAt = car.CreatedAt;
            vm.ModifiedAt = car.ModifiedAt;
            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Make = vm.Make,
                Model = vm.Model,
                Year = vm.Year,
                Price = vm.Price,
                Mileage = vm.Mileage,
                Fuel = vm.Fuel,
                Color = vm.Color,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt
            };
            var result = await _carServices.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }
    }
}
