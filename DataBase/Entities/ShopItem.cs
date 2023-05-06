using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Entities
{
    public class ShopItem
    {
        [Key]
        public int ShopItemId { get; set; }
        public string Name { get; set; }
        public string ArticleNumber { get; set; }
        public decimal Price { get; set; }
        public ProductCategory Category { get; set; }
        [ForeignKey("ProductCategory")]
        public int ProductCategoryId { get; set; }
    }
}