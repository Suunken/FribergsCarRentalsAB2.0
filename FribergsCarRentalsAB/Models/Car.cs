namespace FribergsCarRentalsAB.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Name => $"{Color} {Brand}";
        public bool Rentable { get; set; } = true;
        public string CarPicUrl1 { get; set; } = "";
        public string CarPicUrl2 { get; set; } = "";


    }
}
