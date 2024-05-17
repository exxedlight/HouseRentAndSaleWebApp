using HouseRentAndSaleWebApp.DB.Entites;

namespace HouseRentAndSaleWebApp.Models
{
    public class DetailsViewModel : PublicationViewModel
    {
        public UserEntity author { get; set; } = new UserEntity();
    }
}
