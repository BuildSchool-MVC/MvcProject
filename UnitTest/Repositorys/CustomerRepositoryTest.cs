using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelsLibrary.DtO_Models;
using ModelsLibrary.Repository;

namespace CustomerTest
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        [TestMethod]
        public void CustomerGetAll()
        {
            var repository = new CustomerRepository();
            var customer = repository.GetAll();
            Assert.IsTrue(customer.Count() > 0);
        }
        [TestMethod]
        public void CustomerFindById()
        {
            var repository = new CustomerRepository();
            var customer = repository.FindById(1);
            Assert.IsTrue(customer.CustomerID==1);
        }
        [TestMethod]
        public void CreateCustomer()
        {
            Customer customer = new Customer()
            {
                CustomerID = 2,
                CustomerName = "Coco",
                Birthday = Convert.ToDateTime("1999-12-12"),
                Account = "coco",
                Password = "123",
                Phone="0923456432",
                ShoppingCash = 0               
            };
            CustomerRepository Repository = new CustomerRepository();
            Repository.Cterae(customer);
            var list = Repository.FindById(customer.CustomerID);
            Assert.IsTrue(list != null);
        }
        [TestMethod]
        public void UpdateCustomer()
        {
            Customer customer = new Customer()
            {
                CustomerID = 2,
                CustomerName = "Cococo",
                Birthday = Convert.ToDateTime("1999-1-1"),
                Password = "123456",
                Phone = "09",
                ShoppingCash = 100
            };
            CustomerRepository Repository = new CustomerRepository();
            Repository.Update(customer);
            var list = Repository.FindById(2);
            Assert.IsTrue(list.Password==customer.Password);
        }

    }
}
