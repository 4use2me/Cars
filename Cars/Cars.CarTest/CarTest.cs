using Cars.Core.Dto;
using Cars.Core.ServiceInterface;

namespace Cars.CarTest
{
    public class CarTest : TestBase
    {
        [Fact]
        public async Task Should_ReturnResult_When_ValidCarIsProvided()
        {
            //Arrange
            CarDto dto = new();

            dto.Make = "Mercedes";
            dto.Model = "asd";
            dto.Year = 2020;
            dto.Price = 10000;
            dto.Mileage = 200000;
            dto.Fuel = "petrol";
            dto.Color = "Red";
            dto.CreatedAt = DateTime.Now;
            dto.ModifiedAt = DateTime.Now;

            //Act
            var result = await Svc<ICarsServices>().Create(dto);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_DeleteByIdCar_WhenDeleteCar()
        {
            CarDto car = MockCarData();

            var addCar = await Svc<ICarsServices>().Create(car);
            var result = await Svc<ICarsServices>().Delete((Guid)addCar.Id);

            Assert.Equal(result, addCar);
        }

        [Fact]
        public async Task Should_UpdateCar_WhenUpdateData()
        {
            CarDto dto = MockCarData();
            var createCar = await Svc<ICarsServices>().Create(dto);

            CarDto update = MockUpdateCarData();
            var result = await Svc<ICarsServices>().Update(update);

            Assert.DoesNotMatch(result.Color, createCar.Color);
            Assert.NotEqual(result.ModifiedAt, createCar.ModifiedAt);
        }

        [Fact]
        public async Task ShouldNot_UpdateCar_WhenDidNotUpdateData()
        {
            CarDto dto = MockCarData();
            var createCar = await Svc<ICarsServices>().Create(dto);

            CarDto nullUpdate = MockNullCarData();
            var result = await Svc<ICarsServices>().Update(nullUpdate);

            Assert.NotEqual(createCar.Id, result.Id);
        }

        private CarDto MockCarData()
        {
            CarDto car = new()
            {
                Make = "Mercedes",
                Model = "asd",
                Year = 2020,
                Price = 10000,
                Mileage = 200000,
                Fuel = "petrol",
                Color = "Red",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            return car;
        }

        private CarDto MockUpdateCarData()
        {
            CarDto car = new()
            {
                Make = "Mercedes",
                Model = "asd",
                Year = 2020,
                Price = 10000,
                Mileage = 200000,
                Fuel = "petrol",
                Color = "Green",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now.AddYears(1)
            };
            return car;
        }

        private CarDto MockNullCarData()
        {
            CarDto car = new()
            {
                Id = null,
                Make = "Mercedes",
                Model = "vbn",
                Year = 2022,
                Price = 10500,
                Mileage = 100000,
                Fuel = "petrol",
                Color = "Green",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now.AddYears(1)
            };
            return car;
        }
    }
}
