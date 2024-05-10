namespace HouseRentAndSaleWebApp.DB.Entites
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string login { get; set; }
        public string pass { get; set; }
        public string PIB { get; set; }
        public string? phone { get; set; }
        public string? email { get; set; }
    }
}
