using Ecommerce_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Ecommerce_website.Controllers
{
    public class CategoryController:Controller
    {
        private readonly AppDbContext _Context;
        public CategoryController(AppDbContext Context)
        {
            _Context=Context;
        }
        public IActionResult Index(int? id)
        {
            List<Category> categorylist=new List<Category>();
            if(id==null)
            {
                categorylist=(from p in _Context.categories select p).ToList();
                return View(categorylist);
            }
            categorylist=_Context.categories.Where(p=>p.Id==id).ToList();
            if(categorylist.Count==0)
            {
                return Content("Không có danh mục bạn tìm");
            }
            return View(categorylist);
        }
        public IActionResult Home(int?id)
        {
            var productList=from p in _Context.products select p;
            if(id==null)
            {
                return View(productList.ToList());
            }
            productList=productList.Where(p=>p.CategoryId==id);
            if(productList.ToList().Count==0)
            {
                return Content("Không có sản phẩm bạn tìm");
            }
            return View(productList.ToList());
            
        }
        [HttpPost]
        public IActionResult SortByPrice(List<Product> products)
        {
            products=products.OrderBy(p=>p.Price).ToList();
            return View("Home",products);
        }
        [HttpPost]
        public IActionResult SortByName(List<Product> products)
        {
            products=products.OrderBy(p=>p.Name).ToList();
            return View("Home",products);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string Title)
        {
            Category category=new Category();
            category.Title=Title;
            await _Context.categories.AddAsync(category);
            await _Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id==null)
            {   
                return Content("Khong tim thay id");
            }
            var kq=(from p in _Context.categories where p.Id==id select p).FirstOrDefault();
            if(kq==null)
            {
                return Content("Khong tim thay category co id ="+id);
            }
            _Context.categories.Remove(kq);
            await _Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Search(string productName)
        {
            var listProduct=_Context.products.AsQueryable();
            if(string.IsNullOrWhiteSpace(productName)==false)
            {
                listProduct=listProduct.Where(p=>p.Name.Contains(productName));
            }
            return View("Home",listProduct.ToList());
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,string categoryNameEdit)
        {
            var kq=_Context.categories.Find(id);
            if(kq==null)
            {
                return NotFound();
            }
            _Context.Entry(kq).State=EntityState.Modified;
            kq.Title=categoryNameEdit;
            Console.WriteLine("dsad"+categoryNameEdit);
            Console.WriteLine("dasd"+kq.Title);
            await _Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}