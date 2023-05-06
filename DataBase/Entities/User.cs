using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FullName { get; set; }
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }
        public string RegistrationDate { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
    }
}