using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    internal class OrderDetails
    {
        public OrderDetails()
        {
            ProductID = -1;
            ProductName = "NULL";
            ProductQTY = -1;
            ProductPrice = -1;
            TotalPrice = -1;
        }
        public OrderDetails(int productID, string productName, int productQTY, double productPrice)
        {
            ProductID = productID;
            ProductName = productName;
            ProductQTY = productQTY;
            ProductPrice = productPrice;
            TotalPrice = productQTY * ProductPrice;
        }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductQTY { get; set; }
        public double ProductPrice { get; set; }
        public double TotalPrice { get; set; }

        public override string ToString()
        {
            return ("ProductID:" + ProductID + " Name:" + ProductName + " QTY:" + ProductQTY + " Price:" + ProductPrice + " TotalPrice:" + TotalPrice);
        }

        public override bool Equals(object? obj)
        {
            OrderDetails od = obj as OrderDetails;
            return od != null && (od.ProductID == ProductID || (od.ProductName == ProductName && od.ProductQTY == ProductQTY && od.ProductPrice == ProductPrice && od.TotalPrice == TotalPrice));
        }

        public override int GetHashCode()
        {
            return ProductID.GetHashCode() ^ ProductName.GetHashCode() ^ ProductQTY.GetHashCode() ^ ProductPrice.GetHashCode();
        }
    }
}
