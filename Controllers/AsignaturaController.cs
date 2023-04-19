using Microsoft.AspNetCore.Mvc;
using holaMundoMVC.Models;

namespace holaMundoMVC.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            var comunicación = new Asignatura();
            comunicación.Nombre = "Comunicación";
            var listaAsignaturas = new List<Asignatura>(){
                new Asignatura{Nombre="Matemáticas"},
                new Asignatura{Nombre="Educación"},
                new Asignatura{Nombre="Castellano"},
                new Asignatura{Nombre="Ciencias naturales"}};

            return View("MultiIndex", listaAsignaturas);
        }
    }
}
