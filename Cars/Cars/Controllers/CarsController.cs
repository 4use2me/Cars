using Cars.Data;
using Cars.Models.Cars;
using Microsoft.AspNetCore.Mvc;
using Cars.Core.Dto;
using Cars.Core.ServiceInterface;

namespace Cars.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarsContext _context;
        public CarsController
            (
            CarsContext context
            )
        {
            _context = context;
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
    }
}
