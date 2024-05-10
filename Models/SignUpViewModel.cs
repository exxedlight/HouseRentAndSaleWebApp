namespace HouseRentAndSaleWebApp.Models
{
    public class SignUpViewModel
    {
        public string login { get; set; } = "";
        
        public string pib { get; set; } = "";
        public string phone { get; set; } = "";
        public string email { get; set; } = "";
        
        public string pass1 { get; set; } = "";
        public string pass2 { get; set; } = "";

        public string? error_mes { get; set; } = null;
    }
}
