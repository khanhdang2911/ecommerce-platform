using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ecommerce_website.Models
{
    [Table("UserRole")]
  public class UserRole
  {
    public int UserId{set;get;}
    public int RoleId{set;get;}
        
    

  }
}