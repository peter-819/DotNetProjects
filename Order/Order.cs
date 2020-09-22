using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace OrderProject
{
    [Serializable]
    public class Order : IComparer
    {
        public UInt32 ID { get; set; }
        public string CustomerName { get; set; }
        public List<OrderDetail> OrderDetails;
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }
            var order = obj as Order;
            if(order.ID != this.ID ||
                order.CustomerName != this.CustomerName)
            {
                return false;
            }
            return order.OrderDetails == this.OrderDetails;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(ID.GetHashCode(), CustomerName.GetHashCode(), OrderDetails.GetHashCode());
        }
        public override string ToString()
        {
            return base.ToString() + 
                $"ID = {ID}" +
                $"Customer Name = {CustomerName}" +
                OrderDetails.ToString();
        }
        int IComparer.Compare(object x, object y)
        {
            return ((Order)x).ID < ((Order)y).ID ? 1 : 0;
        }
    }
}
