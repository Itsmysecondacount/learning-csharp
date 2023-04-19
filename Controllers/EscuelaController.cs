using Microsoft.AspNetCore.Mvc;
using holaMundoMVC.Models;

namespace holaMundoMVC.Controllers
{
	public class EscuelaController : Controller
	{
		public IActionResult Index()
		{
			var escuela = new Escuela();
			escuela.AñoFundación = 2005;
			escuela.EscuelaId = Guid.NewGuid().ToString();
			escuela.Nombre = "Platzi school";

			return View(escuela);
		}
	}
}
