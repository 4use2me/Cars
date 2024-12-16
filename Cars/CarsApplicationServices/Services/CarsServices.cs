using Microsoft.EntityFrameworkCore;
using Cars.Core.Domain;
using Cars.Core.Dto;
using Cars.Core.ServiceInterface;
using Cars.Data;

namespace Cars.ApplicationServices.Services
{
    public class CarsServices : ICarsServices
    {
        private readonly CarsContext _context;
        public CarsServices
            (
            CarsContext context
            )
        {
            _context = context;
        }

        public async Task<Car> Create(CarDto dto)
        {
            Car car = new Car();
            car.Id = Guid.NewGuid();
            car.Make = dto.Make;
            car.Model = dto.Model;
            car.Year = dto.Year;
            car.Price = dto.Price;
            car.Mileage = dto.Mileage;
            car.Fuel = dto.Fuel;
            car.Color = dto.Color;
            car.CreatedAt = DateTime.Now;
            car.ModifiedAt = DateTime.Now;
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> DetailAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Car> Update(CarDto dto)
        {
            Car domain = new();
            domain.Id = (Guid?)dto.Id;
            domain.Make = dto.Make;
            domain.Model = dto.Model;
            domain.Year = dto.Year;
            domain.Price = dto.Price;
            domain.Mileage = dto.Mileage;
            domain.Fuel = dto.Fuel;
            domain.Color = dto.Color;
            domain.CreatedAt = dto.CreatedAt;
            domain.ModifiedAt = DateTime.Now;
            _context.Cars.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

        public async Task<Car> Delete(Guid id)
        {
            var car = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return car;
        }
    }
}
