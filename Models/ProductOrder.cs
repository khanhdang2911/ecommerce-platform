using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_website.Models
{
    [Table("ProductOrder")]
    public class ProductOrder
    {
        public int ProductId{set;get;}
        public int OrderId{set;get;}
        public int Quantity{set;get;}
        public Order? Order{get;set;}
        public Product? Product{set;get;}
    }
}