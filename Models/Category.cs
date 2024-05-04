using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ecommerce_website.Models
{
    [Table("Category")]
  public class Category
  {

      [Key]
      public int Id { get; set; }
      // Tiều đề Category
      [Required(ErrorMessage = "Phải có tên danh mục")]
      [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} dài {2} đến {1}")]
      [Display(Name = "Tên danh mục")]
      public string Title { get; set; }=string.Empty;
      public ICollection<Product>? Products{set;get;}
  }
}