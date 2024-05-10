namespace HouseRentAndSaleWebApp.Models
{
    public class SignInViewModel
    {
        public string login { get; set; } = "";
        public string pass { get; set; } = "";

        public string? form_message { get; set; } = null;
        public string form_massage_color { get; set; } = "Green";
    }
}
