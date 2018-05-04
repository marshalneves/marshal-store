using System;
using System.Collections.Generic;
using MarshalStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using MarshalStore.Domain.StoreContext.Entities;
using MarshalStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace MarshalStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("customers")]
        public List<Customer> Get()
        {
            var name = new Name("Kyrk","Douglas");
            var document = new Document("12345678900000");
            var email = new Email("hello@email.com.br");
            var customer = new Customer (name, document, email, "551998978456");
            var customers = new List<Customer>();
            customers.Add(customer);

            return customers;
        }

        [HttpGet]
        [Route("customers/{id}")]
        public Customer GetById(Guid id)
        {
            var name = new Name("Marshal","Neves");
            var document = new Document("12345678900000");
            var email = new Email("marshalneves@email.com.br");
            var customer = new Customer (name, document, email, "551998978456");

            return customer;

        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public List<Order> GetOrders(Guid id)
        {
            var name = new Name("Kyrk","Douglas");
            var document = new Document("12345678900000");
            var email = new Email("hello@email.com.br");
            var customer = new Customer (name, document, email, "551998978456");

            var order = new Order(customer);
            var mouse = new Product("Mouse Gamer", "Mouse Gamer", "mouse.jpg", 100M, 10);
            var monitor = new Product("Monitor Gamer", "Monitor Gamer", "mouse.jpg", 100M, 10);
            order.AddItem(monitor,5);
            order.AddItem(mouse,5);

            var orders = new List<Order>();
            orders.Add(order);

            return orders;


        }

        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody]CreateCustomerCommand command){
            
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer (name, document, email, command.Phone);

            return customer;

        }

        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody]CreateCustomerCommand command){
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer (name, document, email, command.Phone);

            return customer;

        }

        [HttpDelete]
        [Route("customers/{id}")]
        public object Delete(){
            return new { message = "Cliente removido com sucesso" };
        }

    }
}