namespace DI_Service_Lifetime.Services
{
    public class TransientService : ITransientService
    {
        public Guid Id { get; set; }

        public TransientService()
        {
            Id = Guid.NewGuid();
        }

        public Guid GetGuid()
        {
            return Id;
        }
    }
}
