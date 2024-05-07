using System.ComponentModel.DataAnnotations.Schema;
namespace Ecommerce_website.Models
{
  [Table("ProductUsers")]
  public class ProductUsers
  {
    public int UsersId{set;get;}
    public int ProductId{set;get;}
    public int ProductQuantity{set;get;}
    public bool Status{set;get;}=false;


  }
}