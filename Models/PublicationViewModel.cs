using HouseRentAndSaleWebApp.DB.Entites;

namespace HouseRentAndSaleWebApp.Models
{
    public class PublicationViewModel : ObjectInfoEntity
    {
        public PublicationViewModel() { }
        public PublicationViewModel(ObjectEntity entity) : base(entity)
        {
            List<string> images_pathes = Directory.GetFiles(Path.Combine("wwwroot", "publish_images", $"{entity.Id}")).ToList();

            if (images_pathes.Count == 0) images_pathes.Add(Path.Combine("wwwroot", "img", "no_image.jpg"));
            else
            {
                images_pathes = images_pathes.Select(x => x.Replace("wwwroot\\", "/").Replace("\\", "/")).ToList();
                this.images_pathes = images_pathes;
            }
        }

        public List<IFormFile> images { get; set; } = new List<IFormFile>();
        public List<string> images_pathes { get; set; } = new List<string>();
    }
}
