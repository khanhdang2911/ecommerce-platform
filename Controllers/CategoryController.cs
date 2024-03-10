using Ecommerce_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            List<Product> productList=new List<Product>();
            if(id==null)
            {
                productList=(from p in _Context.products select p).ToList();
                return View(productList);
            }
            productList=_Context.products.Where(p=>p.CategoryId==id).ToList();
            if(productList.Count==0)
            {
                return Content("Không có sản phẩm bạn tìm");
            }
            return View(productList);
            
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title,Content")] Category category)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("","Các nội dung bạn nhập chưa đúng quy định");
            }
            await _Context.categories.AddAsync(category);
            await _Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var kq=(from p in _Context.categories where p.Id==id select p).FirstOrDefault();
            
            return View(kq);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int? id)
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
    }
}