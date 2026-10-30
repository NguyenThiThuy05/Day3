
using Day3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day3.Controllers
{
    public class CategoryController : Controller
    {
        // Gia lap csdl
        private static List<Models.Category> _categories = new List<Models.Category>
        {
            new Models.Category { Id = 1, Name = "Category 1" },
            new Models.Category { Id = 2, Name = "Category 2" },
            new Models.Category { Id = 3, Name = "Category 3" }
        };
        // GET: CategoryController
        public ActionResult Index()
        {
            return View(_categories);
        }

        // GET: CategoryController/Details/5
        public IActionResult Details(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Category category)
        {
            if (ModelState.IsValid)
            {
                // them category vao danh sach
                //Tao id moi cho category = max id hien tai + 1
                int newId =  _categories.Max(c => c.Id) + 1 ;
                category.Id = newId;
                _categories.Add(category);
                return RedirectToAction(nameof(Index));
            }
                return View(category);
            }
        

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            //Tim category theo id
            var category = _categories.FirstOrDefault( c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Edit/5
        // cap nhat sau chinh sua
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
           
            var existingCategory = _categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
               existingCategory.Name = category.Name;
                return RedirectToAction(nameof(Index));
            }
                return View(category);
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            {
                _categories.Remove(category);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
