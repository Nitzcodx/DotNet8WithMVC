namespace DI_Service_Lifetime.Services
{
    public class SingletonService : ISingletonService
    {
        public Guid Id { get; set; }

        public SingletonService()
        {
            Id = Guid.NewGuid();
        }

        public Guid GetGuid()
        {
            return Id;
        }
    }
}
