namespace ProductMS.Domain.DomainEvents
{
    public abstract class Event
    {
        public DateTime TimeStamp { get; protected set; }

        public Guid Guid { get; protected set; }
        protected Event()
        {
            TimeStamp = DateTime.Now;
            Guid = Guid.NewGuid();  
        }
    }
}
