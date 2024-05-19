using HouseRentAndSaleWebApp.DB.Entites;

namespace HouseRentAndSaleWebApp.Models
{
    public class DetailsViewModel : PublicationViewModel
    {
        public DetailsViewModel() { }
        public DetailsViewModel(PublicationViewModel publModel, UserEntity userModel) : base(publModel)
        {
            author = new UserEntity(userModel);
        }
        public UserEntity author { get; set; } = new UserEntity();
    }
}
