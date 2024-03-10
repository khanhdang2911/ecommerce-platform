using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ecommerce_website.Models
{
    [Table("OrderProduct")]
  public class OrderProduct
  {
    public int ProductId{set;get;}
    public int UserId{set;get;}
    public int ProductQuantity{set;get;}
    

  }
}