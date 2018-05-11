using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelsLibrary.Repository;

namespace UnitTest
{
    [TestClass]
    public class OrderDetailsRepositoryTest
    {
        [TestMethod]
        public void TestGetAll()
        {
            var repository = new OrderDetailsRepository();
            var orderdetails = repository.GetAll();
            Assert.IsTrue(orderdetails.Count() == 0);
        }

        [TestMethod]
        public void FindById()
        {
            var repository = new OrderDetailsRepository();
            var orderdetails = repository.FindById("null");
            Assert.IsTrue(orderdetails.Count() == 0);
        }
    }
    
}
