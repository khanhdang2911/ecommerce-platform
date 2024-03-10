using Ecommerce_website.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_website.Components
{
    public class ViewCategoryViewComponent:ViewComponent
    {
        private readonly AppDbContext _Context;
        public ViewCategoryViewComponent(AppDbContext Context)
        {
            _Context=Context;
        }
        public IViewComponentResult Invoke()
        {
            var kq=(from c in _Context.categories select c).ToList();
            return View(kq);
        }
    }
}