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
        [Required(ErrorMessage ="Bạn chưa nhập tên role")]
        public string RoleName{set;get;}=string.Empty;
        public ICollection<UsersRole>? usersRoles{set;get;}
    }
}