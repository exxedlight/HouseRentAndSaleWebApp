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
        public decimal? price_min { get; set; } = null;
        public decimal? price_max { get; set; } = null;

        public double? square_min { get; set; } = null;
        public double? square_max { get; set; } = null;

        public int? floor_min { get; set; } = null;
        public int? floor_max { get; set; } = null;

        //  publications list
        public List<PublicationViewModel> Publications { get; set; } = new List<PublicationViewModel>();

        //  page
        public int page = 1;
    }
}
