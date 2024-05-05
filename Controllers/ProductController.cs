using Ecommerce_website.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace Ecommerce_website.Controllers
{
    [Authorize(Roles="Admin")]
    public class ProductController:Controller
    {
        private readonly IWebHostEnvironment _environment;

        private readonly AppDbContext _Context;
        public ProductController(AppDbContext Context,IWebHostEnvironment environment)
        {
            _Context=Context;
            _environment=environment;
        }
        public IActionResult Index()
        {
            var kq=(from p in _Context.products select p).ToList();
            return View(kq);
        }
        [AllowAnonymous]
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
            SelectList listCategory=new SelectList(_Context.categories,"Id","Title");
            ViewData["listCategory"]=listCategory;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Price,linkImage,Status,CategoryId,Introduce,ImageFile")] Product product)
        {
            if(!ModelState.IsValid)
            {
                SelectList listCategory=new SelectList(_Context.categories,"Id","Title");
                ViewData["listCategory"]=listCategory;
                ModelState.AddModelError("","Các nội dung bạn nhập chưa đúng quy định");
            }
            if(product.ImageFile!=null)
            {
                Console.WriteLine("dasdsad  go to here");
                var filepath=Path.Combine(_environment.WebRootPath,"uploads",product.ImageFile.FileName);
                if(!System.IO.File.Exists(filepath))
                {
                    using FileStream fileStream=new FileStream(filepath,FileMode.Create);
                    product.ImageFile.CopyTo(fileStream);
                }
                product.linkImage=$"uploads/{product.ImageFile.FileName}";
            }
            await _Context.products.AddAsync(product);
            await _Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var kq=(from p in _Context.products where p.Id==id select p).FirstOrDefault();
            
            return View(kq);
        }
        [HttpGet]
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product=_Context.products.Find(id);
            if(product==null)
            {
                return NotFound();
            }
            SelectList listCategory=new SelectList(_Context.categories,"Id","Title");
            ViewData["listCategory"]=listCategory;
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute]int id,[Bind("Name,Price,linkImage,Status,CategoryId,Introduce,ImageFile")] Product product)
        {
            if(!ModelState.IsValid)
            {
                 SelectList listCategory=new SelectList(_Context.categories,"Id","Title");
                 ViewData["listCategory"]=listCategory;
                return View();
            }
            var kq=_Context.products.Find(id);
            if(kq==null)
            {
                return NotFound();
            }
            if(product.ImageFile!=null)
            {
                var filepath=Path.Combine(_environment.WebRootPath,"uploads",product.ImageFile.FileName);
                if(!System.IO.File.Exists(filepath))
                {
                    using FileStream fileStream=new FileStream(filepath,FileMode.Create);
                    product.ImageFile.CopyTo(fileStream);
                }
                product.linkImage=$"uploads/{product.ImageFile.FileName}";
            }
            _Context.Entry(kq).State=EntityState.Modified;
            kq.Name=product.Name;
            kq.Price=product.Price;
            kq.linkImage=product.linkImage;
            kq.Status=product.Status;
            kq.CategoryId=product.CategoryId;
            kq.Introduce=product.Introduce;
            await _Context.SaveChangesAsync();
            return RedirectToAction("Home","Category");
        }
        
    }
}