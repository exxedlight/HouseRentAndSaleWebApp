using HouseRentAndSale.DB;

namespace HouseRentAndSaleWebApp.DB.Entites
{
    public class ObjectInfoEntity : ObjectEntity
    {
        public string area_inf { get; set; } = "";
        public string objtype_inf { get; set; } = "";
        public string operation_inf { get; set; } = "";
        public string state_inf { get; set; } = "";

        public ObjectInfoEntity() { }
        public ObjectInfoEntity(ObjectEntity basic)
        {
            this.Id = basic.Id;
            this.title = basic.title;
            this.adres = basic.adres;
            this.square = basic.square;
            this.floor = basic.floor;
            this.price = basic.price;
            this.about = basic.about;
            this.userId = basic.userId;
            this.areaId = basic.areaId;
            this.objtypeId = basic.objtypeId;
            this.operation_type = basic.operation_type;
            this.state = basic.state;
            this.creation_datetime = basic.creation_datetime;

            using (Context context = new Context())
            {
                area_inf = context.Regions.First(x => x.Id == basic.areaId).region_name;
                objtype_inf = context.ObjType.First(x => x.Id == basic.objtypeId).name;
            }

            operation_inf = basic.operation_type == 1 ? "Продаж" : "Оренда";
            state_inf = basic.state == "new" ? "Нове" : "Вторинний ринок";
        }
    }
}
