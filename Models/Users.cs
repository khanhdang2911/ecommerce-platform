using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ecommerce_website.Models
{
    [Table("Users")]
  public class Users
  {
        [Key]
        public int Id{set;get;}
        [EmailAddress(ErrorMessage ="Bạn nhập email sai định dạng")]
        [Required(ErrorMessage ="Bạn chưa nhập email")]
        public string Email{set;get;}=string.Empty;
        [Required(ErrorMessage ="Bạn chưa nhập tên")]
        public string Name{set;get;}=string.Empty;
        [Required(ErrorMessage ="Bạn chưa nhập số điện thoại")]
        [Phone(ErrorMessage ="Nhập số điện thoại sai định dạng")]
        public string Phone{set;get;}=string.Empty;
        public string Password{set;get;}=string.Empty;

        public ICollection<UsersRole>? usersRoles{set;get;}
    

  }
}