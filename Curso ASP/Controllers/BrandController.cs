using Curso_ASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Curso_ASP.Controllers
{
    public class BrandController : Controller
    {
        //readonly para que no se pueda modificar una vez aceptado.
        private readonly PubContext _context;

        //constructor para asignar la inyeccion que obtenemos del program.
        public BrandController(PubContext context)
        {
            _context = context;
        }

        //Las vistas pueden recibir modelos
        //Los metodos async deben devolver un task
        public async Task<IActionResult> Index()
        {
            //Me trae una lista de objetos de la tabla Brand.
            return View(await _context.Brands.ToListAsync());
        }
    }
}
