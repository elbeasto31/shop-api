using System;
using Shop.Dtos.Base;

namespace Shop.Dtos
{
    public class UserDto : DtoBase
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? LastPurchaseDate { get; set; }
        public string RegistrationDate { get; set; }
    }
}