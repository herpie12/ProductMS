
namespace ProductMS.Domain.Models
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal? Fee { get; private set; }
        public bool IsActive { get; private set; }
        public ProductType ProductType { get; private set; }
        public DateTime Created { get; private set; }

        public Product(string name, bool isActive, ProductType productType, decimal? fee)
        {
            Name = name;
            ProductType = productType;
            IsActive = isActive;
            Created = new DateTime();
            Fee = fee ?? 0;
        }

        public void DeactivateProduct()
        {
            if (!IsActive) throw new ArgumentException($"Product is already deactivate: {Name}");

            IsActive = false;
        }
        public void SetFee(decimal fee)
        {
            if (0 > fee)
            {
                throw new ArgumentException("Invalid fee: " + fee);
            }

            Fee = fee;
        }

    }
}
