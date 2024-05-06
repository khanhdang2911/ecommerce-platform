using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ecommerce_website.Models
{
    [Table("Order")]
  public class Order
  {
    [Key]
    public int Id{set;get;}
    public int UsersId{set;get;}
    public DateTime DateBuy{set;get;}
    [Required(ErrorMessage ="Bạn chưa nhập địa chỉ giao hàng")]
    public string Address{set;get;}=string.Empty;
    [DataType(DataType.Currency)]
    public decimal TotalMoney{set;get;}
    public string DeliveryMethod{set;get;}=string.Empty;
  }
}