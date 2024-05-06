using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_website.Dtos
{
    public class ProductInCartDto
    {
        public int Id { get; set;}
        public string Name{set;get;}=string.Empty;
        [DataType(DataType.Currency)]
        public decimal Price{set;get;}
        public int Quantity{set;get;}
        public string? linkImage{set;get;}
    }
}