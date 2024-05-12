namespace HouseRentAndSaleWebApp.Models
{
    public class HomeSearchViewModel
    {
        //  select filters
        public int operation_type { get; set; } = -1;
        public int build_type { get; set; } = -1;
        public string item_state { get; set; } = "exist";
        public int area { get; set; } = -1;
    }
}
