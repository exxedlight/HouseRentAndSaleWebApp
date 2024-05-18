namespace HouseRentAndSaleWebApp.Models
{
    public class PostsViewModel : HomeSearchViewModel
    {
        //  copy from HomeSearch
        public PostsViewModel(HomeSearchViewModel model) 
        {
            areaId = model.areaId;
            state = model.state;
            operation_type = model.operation_type;
            objtypeId = model.objtypeId;
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
