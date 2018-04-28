using MarshalStore.Domain.StoreContext.Entities;
using MarshalStore.Domain.StoreContext.Repositories;

namespace MarshalStore.Tests.Fakes
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public void Save(Customer customer)
        {
            
        }
    }
}