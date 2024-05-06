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
    [Required(ErrorMessage ="Chưa nhập tên sản phẩm")]

    public string Name{set;get;}=string.Empty;

    [Display(Name = "Giá")]
    [Required(ErrorMessage ="Hãy nhập giá cho sản phẩm")]
    [DataType(DataType.Currency,ErrorMessage ="Nhập sai định dạng cho giá sản phẩm")]
    public decimal Price{set;get;}
    [DataType(DataType.Text)]
    [Required(ErrorMessage ="Hãy nhập giới thiệu cho sản phẩm")]
    [Display(Name = "Giới thiệu")]
    public string Introduce{set;get;}=string.Empty;
    [Display(Name ="Ảnh sản phẩm")]
    [Required(ErrorMessage ="Bạn chưa chọn hình ảnh cho sản phẩm")]
    [NotMapped]
    public IFormFile ImageFile{set;get;}
    public string? linkImage{set;get;}

    [ForeignKey("CategoryId")]
    [Required(ErrorMessage ="Chưa chọn danh mục cho sản phẩm")]
    public int CategoryId{set;get;}
    [Required(ErrorMessage ="Chưa chọn tình trạng cho sản phẩm")]
    public string Status{set;get;}=string.Empty;
    [Required(ErrorMessage ="Chưa nhập giá khuyến mãi cho sản phẩm")]
    [DataType(DataType.Currency,ErrorMessage ="Nhập sai định dạng cho giá khuyến mãi sản phẩm")]

    public decimal DiscountPrice{set;get;}
    public Category? Category{set;get;}
    public ICollection<ProductUsers>? ProductUsers{set;get;}
  }
}