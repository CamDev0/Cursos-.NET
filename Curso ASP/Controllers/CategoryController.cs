using Curso_ASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Curso_ASP.Models.View_Model
{
    public class CategoryController : Controller
    {
        //en los controladores primero obtenemos el atributo de la inyeccion en program
        private readonly PubContext _context;

        //Y lo inicializamos dentro del constructor que obtiene el valor o el contexto.
        public CategoryController(PubContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //el incluide esta incluyendo información de otra tabla, como un inner join
            var categories = _context.Categories.Include(b => b.FkbrandldNavigation);
            return View(await categories.ToListAsync());
        }

        
        //no es necesario ponerlo Async porque este metodo no va y viene a la base de datos
        public IActionResult Create()
        {
            //En el form se muestra el nombre, pero a la base de datos se vva el id, la primary key
            ViewData["Brands"] = new SelectList(_context.Brands, "Brandld", "NameBrand");
            return View();
        }

        [HttpPost]
        //Valida que la información venga solo de nuestro dominio
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category()
                {
                    NameCaty = model.NameBrand,
                    Fkbrandld = model.Brandld
                };

                _context.Add(category);
                //con esta instrucción se mandan las consultas a la DB
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            ViewData["Brands"] = new SelectList(_context.Brands, "Brandld", "NameBrand", model.Brandld);
            return View(model);
        }

    }
}
