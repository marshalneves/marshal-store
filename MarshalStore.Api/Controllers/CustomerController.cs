using System;
using System.Collections.Generic;
using MarshalStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using MarshalStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using MarshalStore.Domain.StoreContext.Entities;
using MarshalStore.Domain.StoreContext.Handlers;
using MarshalStore.Domain.StoreContext.Queries;
using MarshalStore.Domain.StoreContext.Repositories;
using MarshalStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace MarshalStore.Api.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _handler;

        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }


        [HttpGet]
        [Route("customers")]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _repository.Get(id);

        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {

            return _repository.GetOrders(id);
            // var name = new Name("Kyrk","Douglas");
            // var document = new Document("12345678900000");
            // var email = new Email("hello@email.com.br");
            // var customer = new Customer (name, document, email, "551998978456");

            // var order = new Order(customer);
            // var mouse = new Product("Mouse Gamer", "Mouse Gamer", "mouse.jpg", 100M, 10);
            // var monitor = new Product("Monitor Gamer", "Monitor Gamer", "mouse.jpg", 100M, 10);
            // order.AddItem(monitor,5);
            // order.AddItem(mouse,5);

            // var orders = new List<Order>();
            // orders.Add(order);

            // return orders;


        }

        [HttpPost]
        [Route("customers")]
        public object Post([FromBody]CreateCustomerCommand command){
            
            var result = (CreateCustomerCommandResult)_handler.Handle(command);

            if (_handler.Invalid)
               return BadRequest(_handler.Notifications);

            return result;

        }

        // [HttpPut]
        // [Route("customers/{id}")]
        // public Customer Put([FromBody]CreateCustomerCommand command){

        // }

        // [HttpDelete]
        // [Route("customers/{id}")]
        // public object Delete(){
        //     return new { message = "Cliente removido com sucesso" };
        // }

    }
}