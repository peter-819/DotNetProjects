using System;
using System.Collections.Generic;
using System.Text;

namespace OrderProject
{
    public class OrderDetail
    {
        public string ItemName { get; set; }
        public UInt32 Value { get; set; }

        public OrderDetail(string name,UInt32 value)
        {
            ItemName = name;
            Value = value;
        }
        public override bool Equals(object obj)
        {
            if(obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.ItemName == ((OrderDetail)obj).ItemName &&
                this.Value == ((OrderDetail)obj).Value;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(ItemName.GetHashCode(), Value.GetHashCode());
        }
        public override string ToString()
        {
            return base.ToString() + $"Name = \"{ItemName}\", Value = \"{Value}\" ";
        }
    }
}
