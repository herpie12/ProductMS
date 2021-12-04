using ProductMS.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace ProductMS.Application.DtoModels
{
    public class ProductDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public ProductType ProductType { get; set; }

        public decimal? Fee { get; set; }
    }
}
