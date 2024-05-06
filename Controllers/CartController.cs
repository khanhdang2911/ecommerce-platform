using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ecommerce_website.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ecommerce_website.Controllers
{
    // [Route("[controller]")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private readonly AppDbContext _context;
        public CartController(ILogger<CartController> logger,AppDbContext context)
        {
            _logger = logger;
            _context=context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AddProduct([FromQuery]int productId,int ProductQuantity=1)
        {
            if(User.Identity.IsAuthenticated==false)
            {
                return RedirectToAction("Login","User");
            }
            int UserId=int.Parse(User.Claims.FirstOrDefault(c=>c.Type=="Id").Value);
            ProductUsers productUser=new ProductUsers();
            var kq=_context.productUsers.Where(p=>p.UsersId==UserId&&p.ProductId==productId).FirstOrDefault();
            if(kq==null)
            {
                productUser.UsersId=UserId;
                productUser.ProductId=productId;
                productUser.ProductQuantity=ProductQuantity;
                await _context.productUsers.AddAsync(productUser);
            }
            else{
                _context.Entry(kq).State = EntityState.Modified;
                kq.ProductQuantity+=ProductQuantity;
            }
            await _context.SaveChangesAsync();

            

            return RedirectToAction("Home","Category");
        }
        public IActionResult Detail()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Checkout(int UsersId, string Address,decimal TotalMoney, string DeliveryMethod)
        {
            Order order=new Order();
            order.UsersId=UsersId;
            order.Address=Address;
            order.TotalMoney=TotalMoney;
            order.DeliveryMethod=DeliveryMethod;
            order.DateBuy=DateTime.Now;
            await _context.orders.AddAsync(order);
            var removeItems=_context.productUsers.Where(p=>p.UsersId==UsersId).ToList();
            _context.productUsers.RemoveRange(removeItems);
            await _context.SaveChangesAsync();
            return RedirectToAction("Home","Category");
        }
        [HttpGet]
        public async Task<IActionResult> RemoveItem(int productId)
        {
            var UserId=User.Claims.FirstOrDefault(c=>c.Type=="Id").Value;
            if(_context.productUsers.Any(p=>p.UsersId==int.Parse(UserId)&&p.ProductId==productId))
            {
                var removeItem=await _context.productUsers.Where(p=>p.UsersId==int.Parse(UserId)&&p.ProductId==productId).FirstAsync();
                _context.productUsers.Remove(removeItem);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Detail");
        }

    }
}