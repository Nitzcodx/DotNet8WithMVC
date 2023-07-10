namespace DI_Service_Lifetime.Services
{
    public class ScopedService : IScopedService
    {
        public Guid Id { get; set; }

        public ScopedService()
        {
            Id = Guid.NewGuid();
        }

        public Guid GetGuid()
        {
            return Id;
        }
    }
}
