
namespace ProductMS.Domain.Models
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool IsActive { get; private set; }
        public ProductType ProductType { get; private set; }
        public DateTime Created { get; private set; }

        public Product(string name, bool isActive, ProductType productType)
        {
            Name = name;
            ProductType = productType;
            IsActive = isActive;
            Created = new DateTime();
        }

        public void DeactivateProduct()
        {
            if (IsActive) throw new ArgumentException($"Product is active: {Name}");

            IsActive = false;
        }

    }
}
