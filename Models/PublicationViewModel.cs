using HouseRentAndSaleWebApp.DB.Entites;

namespace HouseRentAndSaleWebApp.Models
{
    public class PublicationViewModel
    {

        public PublicationViewModel() { }
        public PublicationViewModel(ObjectEntity entity) 
        {
            title = entity.title;
            adres = entity.adres;
            operation_type = entity.operation_type;
            build_type = entity.objtypeId;
            item_state = entity.state;
            area = entity.areaId;
            square = entity.square.ToString();
            floor = entity.floor.ToString();
            price = entity.price.ToString();
            about = entity.about;
            images = new List<IFormFile>();
            Id = entity.Id;
            userId = entity.userId;
        }

        public int? Id { get; set; } = null;
        public Guid? userId { get; set; } = null;

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
        public List<string> images_pathes { get; set; } = new List<string>();
    }
}
