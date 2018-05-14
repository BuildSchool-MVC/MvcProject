using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelsLibrary.DtO_Models;
using ModelsLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Repositories.Tests
{
    [TestClass()]
    public class ProductsRepositoryTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            ProductsRepository repository = new ProductsRepository();
            var list=repository.GetAll();
            Assert.IsTrue(list.Count()>0);
        }

        [TestMethod()]
        public void FindByIDTest()
        {
            ProductsRepository products = new ProductsRepository();
            var list = products.FindByID("2");

            Assert.IsTrue(list != null);
        }

        [TestMethod()]
        public void FindByID2Test()
        {
            ProductsRepository products = new ProductsRepository();
            var list = products.FindByID("10");

            Assert.IsTrue(list == null);
        }

        [TestMethod()]
        public void CreateTest()
        {
            Products model = new Products()
            {
                ProductID = 2,
                ProductName = "高腰開岔長裙",
                UnitPrice = 200,
                UnitsInStock = 50,
                CategoryID = 3,
                Size = "S",
                Color="Red",
                Uptime = new DateTime(2018, 05, 10)
            };
            ProductsRepository products = new ProductsRepository();
            products.Create(model);
            var list = products.FindByID(model.ProductID.ToString());

            Assert.IsTrue(list != null);
        }

        [TestMethod()]
        public void UpdateUnitPriceTest()
        {
            Products model = new Products()
            {
                ProductID = 4,
                UnitPrice = 180
            };
            ProductsRepository products = new ProductsRepository();
            products.UpdateUnitPrice(model);
            var list = products.FindByID("4");

            Assert.IsTrue(list.UnitPrice==model.UnitPrice);
        }

        [TestMethod()]
        public void UpdateStockTest()
        {
            Products model = new Products()
            {
                ProductID = 4,
                UnitsInStock=30
            };
            ProductsRepository products = new ProductsRepository();
            products.UpdateStock(model);
            var list = products.FindByID("4");

            Assert.IsTrue(list.UnitsInStock==model.UnitsInStock);
        }

        [TestMethod()]
        public void UpdateDowntimeTest()
        {
            Products model = new Products()
            {
                ProductID = 4,
                Downtime=new DateTime(2018,05,10)
            };
            ProductsRepository products = new ProductsRepository();
            products.UpdateDowntime(model);
            var list = products.FindByID("4");

            Assert.IsTrue(list.Downtime == model.Downtime);
        }

        //[TestMethod()]
        //public void DeleteTest()
        //{
        //    Products model = new Products()
        //    {
        //        ProductID = 3
        //    };
        //    ProductsRepository products = new ProductsRepository();
        //    products.Delete(model);
        //    var list = products.FindByID("3");

        //    Assert.IsTrue(list == null);
        //}
    }
}