using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Entities
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }
        [Column(TypeName = "date")]
        public DateTime PurchaseDate { get; set; }
        public decimal TotalCost { get; set; }
        public ICollection<PurchasedItem> PurchaseItems { get; set; }
        
        public User User { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}