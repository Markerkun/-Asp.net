using Microsoft.AspNetCore.Mvc;
using Shop.Data;

namespace Shop.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            var categoryList = _context.Categories.ToList();

            return View(categoryList);
        }

        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
    }
}
