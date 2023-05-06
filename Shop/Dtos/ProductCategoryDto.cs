using Shop.Dtos.Base;

namespace Shop.Dtos
{
    public class ProductCategoryDto : DtoBase
    {
        public string Name { get; set; }
        public int NumberOfPurchasedItems { get; set; }
    }
}