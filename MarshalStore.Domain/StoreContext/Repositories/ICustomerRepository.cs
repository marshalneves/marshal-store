using MarshalStore.Domain.StoreContext.Entities;

namespace MarshalStore.Domain.StoreContext.Repositories {

    public interface ICustomerRepository
    {
        
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);

    }
}