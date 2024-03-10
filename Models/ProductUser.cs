using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ecommerce_website.Models
{
    [Table("ProductUser")]
  public class ProductUser
  {
    public int UserId{set;get;}
    public int ProductId{set;get;}
    public int ProductQuantity{set;get;}
    

  }
}