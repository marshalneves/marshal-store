using MarshalStore.Domain.StoreContext.Services;

namespace MarshalStore.Infra.StoreContext.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
            //TODO: Implements
        }
    }
}