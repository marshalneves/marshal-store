using MarshalStore.Domain.StoreContext.Entities;

namespace MarshalStore.Domain.StoreContext.Services {

    public interface IEmailService
    {
        
        bool Send (string to, string from, string subject, string body);

    }
}