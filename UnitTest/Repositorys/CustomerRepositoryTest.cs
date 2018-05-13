using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelsLibrary.Repository;

namespace CustomerTest
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        [TestMethod]
        public void GetAllTest()
        {
            var repository = new CustomerRepository();
            var customer = repository.GetAll();
            Assert.IsTrue(customer.Count() > 0);
        }
        [TestMethod]
        public void FindById()
        {
            var repository = new CustomerRepository();
            var customer = repository.FindById(1);
            Assert.IsTrue(customer.CustomerID==1);
        }
        [TestMethod]
        
    }
}
