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
            Assert.IsTrue(order.Count() == 1);
        }

        [TestMethod]
        public void TestFindById()
        {
            var repository = new OrderRepository();
            var order = repository.FindById("1");
            Assert.IsTrue(order != null);
        }

        #region 其他測試屬性
        //
        // 您可以使用下列其他屬性撰寫測試: 
        //
        // 執行該類別中第一項測試前，使用 ClassInitialize 執行程式碼
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在類別中的所有測試執行後，使用 ClassCleanup 執行程式碼
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在執行每一項測試之前，先使用 TestInitialize 執行程式碼 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在執行每一項測試之後，使用 TestCleanup 執行程式碼
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

    }
}
