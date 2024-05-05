using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ecommerce_website.Models
{
  [Table("UsersRole")]
  public class UsersRole
  {
    public int UsersId{set;get;}
    public int RoleId{set;get;}
  }
}