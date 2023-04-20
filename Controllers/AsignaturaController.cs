using Microsoft.AspNetCore.Mvc;
using holaMundoMVC.Models;

namespace holaMundoMVC.Controllers
{
	public class AsignaturaController : Controller
	{

		[Route("Asignatura/Index/{asignatureId}")]
		public IActionResult Index(string asignatureId)
		{
			var asignatura = from asig in _context.Asignaturas
											 where asig.Id == asignatureId
											 select asig;

			return View(asignatura.SingleOrDefault());
		}
		public IActionResult MultiAsignatura()
		{
			var comunicación = new Asignatura();
			comunicación.Nombre = "Comunicación";
			var listaAsignaturas = _context.Asignaturas;

			return View("MultiIndex", listaAsignaturas);
		}

		private EscuelaContext _context;
		public AsignaturaController(EscuelaContext context)
		{
			_context = context;
		}
	}
}
