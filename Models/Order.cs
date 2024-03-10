using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Org.BouncyCastle.Bcpg;
namespace Ecommerce_website.Models
{
    [Table("Order")]
  public class Order
  {
    [Key]
    public int Id{set;get;}
    public int UserId{set;get;}
    public DateTime DateBuy{set;get;}
    public int IdTrangTrai{set;get;}
    public string Address{set;get;}

  }
}