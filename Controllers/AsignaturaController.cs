using Microsoft.AspNetCore.Mvc;
using holaMundoMVC.Models;

namespace holaMundoMVC.Controllers
{
    public class AsignaturaController : Controller
    {
        [Route("Asignatura/Index")]
        [Route("Asignatura/Index/{asignatureId}")]

        public IActionResult Index(string asignatureId)
        {
            if (string.IsNullOrWhiteSpace(asignatureId))
            {
                return View("MultiIndex", _context.Asignaturas);
            }
            else
            {
                var asignatura = from asig in _context.Asignaturas
                                 where asig.Id == asignatureId
                                 select asig;

                return View(asignatura.SingleOrDefault());
            }
        }

        private EscuelaContext _context;
        public AsignaturaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}
