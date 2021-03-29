using WebAPI.Data;

namespace WebAPI.Entities
{
    public class Product : BaseEntity
    {
        public float Price { get; set; }
        public string Name { get; set; }
        public string Description { set; get; }
        public string Category { get; set; }
    }
}
