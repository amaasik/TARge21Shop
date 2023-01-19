namespace TARge21Shop.Models.Car
{
    public class CarDetailsViewModel
    {
        public Guid? Id { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public int HorsePower { get; set; }
        public int Weight { get; set; }
        public DateTime BuiltDate { get; set; }
        public DateTime LastMaintenance { get; set; }

        // only in database
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
