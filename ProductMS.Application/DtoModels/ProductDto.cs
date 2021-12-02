using ProductMS.Domain.Models;

namespace ProductMS.Application.DtoModels
{
    public class ProductDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ProductType ProductType { get; set; }
    }
}
