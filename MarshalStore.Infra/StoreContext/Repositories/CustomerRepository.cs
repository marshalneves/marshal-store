using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MarshalStore.Infra.DataContexts;
using Dapper;
using MarshalStore.Domain.StoreContext.Repositories;
using MarshalStore.Domain.StoreContext.Entities;
using MarshalStore.Domain.StoreContext.Queries;

namespace MarshalStore.Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MarshalDataContext _context;

        public CustomerRepository(MarshalDataContext context)
        {
            _context = context;
        }

        public IEnumerable<ListCustomerQueryResult> Get()
        {
             return
                _context
                .Connection
                .Query<ListCustomerQueryResult>("SELECT [Id], CONCAT([FirstName], ' ', [LastName]) AS [Name], [LastName], [Document], [Email] FROM [Customer]");
        }
        public GetCustomerQueryResult Get(Guid id)
        {
             return
                _context
                .Connection
                .Query<GetCustomerQueryResult>("SELECT [Id], CONCAT([FirstName], ' ', [LastName]) AS [Name], [LastName], [Document], [Email] FROM [Customer] WHERE [Id]=@Id", new {id = id})
                .FirstOrDefault();
        }

        public bool CheckDocument(string document)
        {
            return
                _context
                .Connection
                .Query<bool>(
                    "spCheckDocument",
                    new { Document = document },
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            return _context
                .Connection
                .Query<bool>(
                    "spCheckEmail",
                    new { Email = email },
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            return _context
                .Connection
                .Query<CustomerOrdersCountResult>(
                    "spGetCustomerOrdersCount",
                    new { Document = document },
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {

            var qryString = "SELECT [Id], "
                                + " ,[CreateDate] "
                                + " ,[Status] "
                                + " FROM [Orders]"
                                + " WHERE [CustomerId] = @id";
            return
                _context
                .Connection
                .Query<ListCustomerOrdersQueryResult>(qryString, new { id = id });
        }

        public void Save(Customer customer)
        {
            _context.Connection.Execute("spCreateCustomer",
            new
            {
                Id = customer.Id,
                FirstName = customer.Name.FirstName,
                LastName = customer.Name.LastName,
                Document = customer.Document.Number,
                Email = customer.Email.Address,
                Phone = customer.Phone
            }, commandType: CommandType.StoredProcedure);

            foreach (var address in customer.Addresses)
            {
                _context.Connection.Execute("spCreateAddress",
                new
                {
                    Id = address.Id,
                    CustomerId = customer.Id,
                    Number = address.Number,
                    Complement = address.Complement,
                    District = address.District,
                    City = address.City,
                    State = address.State,
                    Country = address.Country,
                    ZipCode = address.ZipCode,
                    Type = address.Type,
                }, commandType: CommandType.StoredProcedure);
            }
        }

    }
}