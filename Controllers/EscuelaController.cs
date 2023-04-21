using Microsoft.AspNetCore.Mvc;
using holaMundoMVC.Models;

namespace holaMundoMVC.Controllers
{
    public class EscuelaController : Controller
    {

        [Route("Escuela/Index")]
        [Route("Escuela/Index/{escuelaId}")]

        public IActionResult Index(string escuelaId)
        {

            if (string.IsNullOrWhiteSpace(escuelaId))
            {
                return View("MultiIndex", _context.Escuelas);
            }
            else
            {
                var escuelas = from asig in _context.Escuelas
                               where asig.Id == escuelaId
                               select asig;

                return View(escuelas.SingleOrDefault());
            }
        }

        private EscuelaContext _context;
        public EscuelaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}
