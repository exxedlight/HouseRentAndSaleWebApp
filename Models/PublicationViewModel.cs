using HouseRentAndSaleWebApp.DB.Entites;

namespace HouseRentAndSaleWebApp.Models
{
    public class PublicationViewModel : ObjectInfoEntity
    {
        public PublicationViewModel() { }
        public PublicationViewModel(ObjectEntity entity) : base(entity)
        {
        }

        public List<IFormFile> images { get; set; } = new List<IFormFile>();
        public List<string> images_pathes { get; set; } = new List<string>();
    }
}
