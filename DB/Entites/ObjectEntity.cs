namespace HouseRentAndSaleWebApp.DB.Entites
{
    public class ObjectEntity
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string adres { get; set; }
        public double square { get; set; }
        public int floor { get; set; }
        public decimal price { get; set; }
        public string about { get; set; }
        public Guid userId { get; set; }
        public int areaId { get; set; }
        public int objtypeId { get; set; }
        public int operation_type { get; set; }
        public string state { get; set; }
    }
}
