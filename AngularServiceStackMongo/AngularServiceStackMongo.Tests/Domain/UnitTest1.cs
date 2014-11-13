namespace Domain.Test
{
    using System;
    using System.Linq;
    using AngularServiceStackMongo.Domain;
    using ServiceStack.Testing;
    using ServiceStack;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SendRequest()
        {
            var client = new JsonServiceClient(@"http://localhost:49581/api/Items");

            var response = client.Post(new AngularServiceStackMongo.ServiceModel.Item { Name = "World!" });
        }

        [TestMethod]
        public void AddItemsToMongo()
        {
            var item = new Item("item1", "andy", DateTime.Now, new SubItem[] { new SubItem("item1", "andy", DateTime.Now) });
            var service = new ItemRepository();
            service.SaveUpdate(item);

            var item2 = service.GetItemDetails(20, 0);

            var item3 = item2.First();
            item3.UserName = "Fin";

            service.Update(item3);
        }
    }
}
