using Microsoft.AspNetCore.Mvc;
using holaMundoMVC.Models;

namespace holaMundoMVC.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
            var escuela = new Escuela();
            escuela.AñoDeCreación = 2005;
            escuela.Nombre = "Platzi school";

            return View(escuela);
        }
    }
}
