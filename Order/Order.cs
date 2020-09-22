using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace OrderProject
{
    [Serializable]
    public class Order : IComparable
    {
        public UInt32 ID { get; set; }
        public string CustomerName { get; set; }
        public List<OrderDetail> OrderDetails;
        public Order(){
            OrderDetails = new List<OrderDetail>();
        }
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
        public int CompareTo(object x)
        {
            if(ID == ((Order)x).ID){
                return 0;
            }
            return ID < ((Order)x).ID ? -1 : 1;
        }
    }
}
