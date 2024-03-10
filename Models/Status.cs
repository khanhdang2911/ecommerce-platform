using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ecommerce_website.Models
{
    [Table("Status")]
  public class TrangThai
  {
    [Key]
    public int Id{set;get;}
    [Display(Name ="Trạng thái")]
    public string StatusName{set;get;}
    
    

  }
}