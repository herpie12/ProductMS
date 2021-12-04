namespace ProductMS.Domain.DomainEvents
{
    public class ProductCreatedEvent : Event
    {
        public string Name { get; private set; }
        public bool IsActive { get; private set; }
        public decimal? Fee { get; private set; }

        public ProductCreatedEvent(string name, bool isActive, decimal? fee)
        {
            Name = name;
            IsActive = isActive;
            Fee = fee;
        }
    }
}
