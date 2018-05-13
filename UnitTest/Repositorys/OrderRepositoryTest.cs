using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelsLibrary.DtO_Models;
using ModelsLibrary.Repositorys;

namespace UnitTest.Repositorys
{
   
    [TestClass]
    public class OrderRepositoryTest
    {
        [TestMethod]
        public void TestGetAll()
        {
            var repository = new OrderRepository();
            var order = repository.GetAll();
            Assert.IsTrue(order.Count() > 0);
        }

        [TestMethod]
        public void TestFindById()
        {
            var repository = new OrderRepository();
            var order = repository.FindById("1");
            Assert.IsTrue(order != null);
        }

        [TestMethod]
        public void TestCheckStatus()
        {
            var repository = new OrderRepository();
            var order = repository.CheckStatus("1");
            Assert.IsTrue(order != null);
        }



    }
}
