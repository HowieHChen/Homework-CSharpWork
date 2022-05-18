using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework10
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public int QTY { get; set; }

    }
    public class Order
    {

        public int Id { get; set; }
        public string? Client { get; set; }
        //public DateTime CreationDate { get; set; }
        public double TotalPrice { get; set; }
    }
}
