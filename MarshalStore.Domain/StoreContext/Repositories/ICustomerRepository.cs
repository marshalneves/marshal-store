using System;
using System.Collections.Generic;
using MarshalStore.Domain.StoreContext.Entities;
using MarshalStore.Domain.StoreContext.Queries;

namespace MarshalStore.Domain.StoreContext.Repositories {

    public interface ICustomerRepository
    {
        
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
        //CustomerOrderCountResult GetCustomerOrdersCount(string document)

        IEnumerable<ListCustomerQueryResult> Get();
        GetCustomerQueryResult Get(Guid Id);
        IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id);



    }
}
