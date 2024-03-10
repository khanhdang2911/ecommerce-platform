using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ecommerce_website.Models
{
    [Table("Product")]
  public class Product
  {

    [Key]
    public int Id{set;get;}
    
    [Display(Name = "Tên sản phẩm")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} dài {2} đến {1}")]

    public string Name{set;get;}

    [Display(Name = "Giá")]
    public decimal Price{set;get;}
    [DataType(DataType.Text)]
    [Display(Name = "Giới thiệu")]
    public string? Introduce{set;get;}
    public string? linkImage{set;get;}

    [ForeignKey("CategoryId")]
    public int CategoryId{set;get;}
    public string? Status{set;get;}
    public Category Category{set;get;}
  }
}