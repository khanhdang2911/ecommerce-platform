using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ecommerce_website.Models
{
    [Table("Users")]
  public class User
  {
    [Key]
    public int Id{set;get;}
    public string Name{set;get;}
    [EmailAddress]
    public string Email{set;get;}
    public string UserAddress{set;get;}
    [Phone]
    public string PhoneNumber{set;get;}
    public string PassWord{set;get;}
    

  }
}