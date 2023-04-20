using System;

namespace holaMundoMVC.Models
{
	public class Asignatura : ObjetoEscuelaBase
	{
		public string Nombre { set; get; }

		public string CursoId { get; set; }

		public Curso Curso { get; set; }

		public List<Evaluación> Evaluaciones { get; set; }
	}
}