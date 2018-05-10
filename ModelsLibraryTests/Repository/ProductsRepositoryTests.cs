using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelsLibrary.DtO_Models;
using ModelsLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Repository.Tests
{
    [TestClass()]
    public class ProductsRepositoryTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            ProductsRepository products = new ProductsRepository();
            var list=products.GetAll();
            Assert.IsTrue(list.Count()>0);
        }

        [TestMethod()]
        public void FindByIDTest()
        {
            ProductsRepository products = new ProductsRepository();
            var list = products.FindByID("1");

            Assert.IsTrue(list!=null);
        }

        [TestMethod()]
        public void FindByID2Test()
        {
            ProductsRepository products = new ProductsRepository();
            var list = products.FindByID("3");

            Assert.IsTrue(list == null);
        }

        [TestMethod()]
        public void CreateTest()
        {
            Products model = new Products()
            {
                ProductID = 3,
                ProductName = "高腰開岔長裙",
                UnitPrice = 200,
                UnitsInStock = 50,
                CategoryID = 3,
                Size = "M,L",
                Uptime = new DateTime(2018,05,10),
            };
            ProductsRepository products = new ProductsRepository(); 
            products.Create(model);
            var list = products.FindByID("3");

            Assert.IsTrue(list!=null);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Products model = new Products()
            {
                ProductID = 4,
                ProductName = "高腰開岔長裙",
                UnitPrice = 180,
                UnitsInStock = 50,
                CategoryID = 3,
                Size = "M,L",
                Uptime = new DateTime(2018, 05, 10),
                Downtime = new DateTime(2018, 05, 10)
            };
            ProductsRepository products = new ProductsRepository();
            products.Update(model);
            var list = products.FindByID("4");

            Assert.IsTrue(list != null);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Products model = new Products()
            {
                ProductID = 3
            };
            ProductsRepository products = new ProductsRepository();
            products.Delete(model);
            var list = products.FindByID("3");

            Assert.IsTrue(list == null);
        }
    }
}