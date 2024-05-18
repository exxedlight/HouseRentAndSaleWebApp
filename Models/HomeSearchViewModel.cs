namespace HouseRentAndSaleWebApp.Models
{
    public class HomeSearchViewModel
    {
        //  select filters
        public int operation_type { get; set; } = -1;
        public int objtypeId { get; set; } = -1;
        public string state { get; set; } = "exist";
        public int areaId { get; set; } = -1;
    }
}
