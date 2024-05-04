using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ecommerce_website.Models
{
    [Table("Role")]
  public class Role
  {
    [Key]
    public int Id{set;get;}
    [Display(Name ="Tên role")]
    public string RoleName{set;get;}=string.Empty;
    
    

  }
}