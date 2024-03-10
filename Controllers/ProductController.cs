using Ecommerce_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ecommerce_website.Controllers
{
    public class ProductController:Controller
    {
        private readonly AppDbContext _Context;
        public ProductController(AppDbContext Context)
        {
            _Context=Context;
        }
        public IActionResult Index()
        {
            var kq=(from p in _Context.products select p).ToList();
            return View(kq);
        }
        public IActionResult Detail(int? id)
        {
            if(id==null)
            {   
                return Content("Khong tim thay id");
            }
            var kq=(from p in _Context.products where p.Id==id select p).FirstOrDefault();
            if(kq==null)
            {
                return Content("Khong tim thay san pham co id ="+id);
            }
            return View(kq);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Console.WriteLine(_Context.categories.Count());
            SelectList listCategory=new SelectList(_Context.categories,"Id","Title");
            ViewData["listCategory"]=listCategory;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Price,linkImage,Status,CategoryId,Introduce")] Product product)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("","Các nội dung bạn nhập chưa đúng quy định");
            }
            await _Context.products.AddAsync(product);
            await _Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var kq=(from p in _Context.products where p.Id==id select p).FirstOrDefault();
            
            return View(kq);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            if(id==null)
            {   
                return Content("Khong tim thay id");
            }
            var kq=(from p in _Context.products where p.Id==id select p).FirstOrDefault();
            if(kq==null)
            {
                return Content("Khong tim thay san pham co id ="+id);
            }
            _Context.products.Remove(kq);
            await _Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}