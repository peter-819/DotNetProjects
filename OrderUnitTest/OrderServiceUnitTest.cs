using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderProject;
using System;
using System.Collections.Generic;

namespace OrderServiceUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private Order order1 = new Order()
        {
            ID = 1000001,
            CustomerName = "Jerome",
            OrderDetails = new List<OrderDetail>()
                {
                    new OrderDetail("phone",1000),
                    new OrderDetail("PC",8000)
                }
        };
        private Order order2 = new Order()
        {
            ID = 1000002,
            CustomerName = "Peter",
            OrderDetails = new List<OrderDetail>()
                {
                    new OrderDetail("phone",2000),
                    new OrderDetail("PC",10000)
                }
        };
        private Order order3 = new Order()
        {
            ID = 1000003,
            CustomerName = "Kold",
            OrderDetails = new List<OrderDetail>()
                {
                    new OrderDetail("PC",20000)
                }
        };
        private OrderService service;

        [TestInitialize]
        public void InitializeOrderList()
        { 
            service = OrderService.Instance();
            service.OrderList.Clear();
            service.AddOrder(order1);
            service.AddOrder(order2);
        }

        [TestMethod]
        public void QueryOrderTest()
        {
            try
            {
                var order = service.QueryOrder(order1);
                Console.WriteLine(order.ToString());

                order = service.QueryOrder(order3);
                Console.WriteLine(order.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        [TestMethod]
        public void SortTest()
        {
            service.AddOrder(order3);
            service.Sort();
            var correct = new List<Order>
            {
                order1,order2,order3
            };
            CollectionAssert.Equals(service.OrderList, correct);

            service.Sort((a, b) => string.Compare(a.CustomerName, b.CustomerName));
            correct = new List<Order>
            {
                order1,order3,order2
            };
            CollectionAssert.Equals(service.OrderList, correct);
        }
        
        [TestMethod]
        public void SerializerTest()
        {
            service.SerializeOrder("order.xml");
            service.DeserilizeOrder("order.xml");
        }
    }
}
