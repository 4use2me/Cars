namespace Cars.Models.Cars
{
    public class CarsIndexViewModel
    {
        public Guid? Id { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public float Price { get; set; }
        public int Mileage { get; set; }
        public string? Fuel { get; set; }
        public string? Color { get; set; }
    }
}
