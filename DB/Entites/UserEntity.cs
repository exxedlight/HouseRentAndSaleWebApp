namespace HouseRentAndSaleWebApp.DB.Entites
{
    public class UserEntity
    {
        public UserEntity() { }
        public UserEntity(UserEntity user)
        {
            Id = user.Id;
            login = user.login;
            pass = user.pass;
            PIB = user.PIB;
            phone = user.phone;
            email = user.email;
        }
        public Guid Id { get; set; }
        public string login { get; set; }
        public string pass { get; set; }
        public string PIB { get; set; }
        public string? phone { get; set; }
        public string? email { get; set; }
    }
}
