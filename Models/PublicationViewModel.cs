namespace HouseRentAndSaleWebApp.Models
{
    public class PublicationViewModel
    {
        public string title { get; set; } = "";
        public string adres { get; set; } = "";
        public int operation_type { get; set; } = 1;
        public int build_type { get; set; } = 1;
        public string item_state { get; set; } = "new";
        public int area { get; set; } = 1;
        public string square { get; set; } = "";
        public string floor { get; set; } = "";
        public string price { get; set; } = "";
        public string about { get; set; } = "";
        public List<IFormFile> images { get; set; } = new List<IFormFile>();
    }
}
