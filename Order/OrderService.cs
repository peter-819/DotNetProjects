using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

namespace OrderProject
{
    public class OrderService
    {
        public List<Order> OrderList;
        static private OrderService instance;
        public OrderService()
        {
            OrderList = new List<Order>();
        }
        static public ref OrderService Instance()
        {
            if(instance == null)
            {
                instance = new OrderService();
            }
            return ref instance;
        }
        public void AddOrder(Order order)
        {
            OrderList.Add(order);
        }
        public void RemoveOrder(Order order)
        {
            QueryOrder(order);
            OrderList.Remove(order);
        }
        public void ModifyOrder(Order order,Order newOrder)
        {
            int index = OrderList.IndexOf(order);
            if(index == -1)
            {
                throw new Exception("There's no such order");
            }
            else
            {
                OrderList[index] = newOrder;
            }
        }
        public Order QueryOrder(Order order)
        {
            int index = OrderList.IndexOf(order);
            if(index == -1)
            {
                throw new Exception("There's no such order");
            }
            else
            {
                return OrderList[index] as Order;
            }
        }
        public void Sort(Func<Order,Order,int> func = null)
        {
            if (func != null)
            {
                OrderList.Sort();
            }
            else
            {
                OrderList.Sort((x,y)=>func(x,y));
            }
        }
        public void SerializeOrder(string path)
        {
            XmlSerializer serializer = new XmlSerializer(OrderList.GetType());
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fs, OrderList);
            }
        }
        public void DeserilizeOrder(string path)
        {
            XmlSerializer serializer = new XmlSerializer(OrderList.GetType());
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                var orderList = (List<Order>)serializer.Deserialize(fs);
                orderList.ForEach((x) => Console.WriteLine(x.ToString()));
            }
        }
    }
}
