using System.ComponentModel.DataAnnotations;

namespace DataBase.Entities
{
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
    }
}