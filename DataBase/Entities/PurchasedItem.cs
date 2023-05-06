using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Entities
{
    public class PurchasedItem
    {
        [Key]
        public int PurchasedItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public ShopItem ShopItem { get; set; }

        public Purchase Purchase { get; set; }
        
        [ForeignKey("Purchase")]
        public int PurchaseId { get; set; }
        [ForeignKey("ShopItem")]
        public int ShopItemId { get; set; }
    }
}