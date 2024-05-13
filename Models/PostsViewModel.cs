namespace HouseRentAndSaleWebApp.Models
{
    public class PostsViewModel : HomeSearchViewModel
    {
        //  copy from HomeSearch
        public PostsViewModel(HomeSearchViewModel model) 
        {
            area = model.area;
            build_type = model.build_type;
            operation_type = model.build_type;
            item_state = model.item_state;
        }
        public PostsViewModel() { }


        // rest filters
        public decimal price_min { get; set; } = 0;
        public decimal price_max { get; set; } = decimal.MaxValue;

        public double square_min { get; set; } = 0;
        public double square_max { get; set; } = double.MaxValue;

        public int floor_min { get; set; } = 0;
        public int floor_max { get; set; } = int.MaxValue;

        //  publications list
        public List<PublicationViewModel> Publications { get; set; } = new List<PublicationViewModel>();

        //  page
        public int page = 1;
    }
}
