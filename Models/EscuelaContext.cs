using Microsoft.EntityFrameworkCore;

namespace holaMundoMVC.Models
{
	public class EscuelaContext : DbContext //Se define la clase que ereda de DbContext
	{
		public DbSet<Escuela> Escuelas { get; set; } //Propiedades públicas que son instancias de DbSet que representam
																								 //tablas de base de datos
		public DbSet<Asignatura> Asignaturas { get; set; }
		public DbSet<Curso> Cursos { get; set; }
		public DbSet<Alumno> Alumnos { get; set; }
		public DbSet<Evaluación> Evaluacións { get; set; }

		public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options) //Constructor
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) //Esto es un método? que se ejecuta cuando la clase
		{
			base.OnModelCreating(modelBuilder);
			var escuela = new Escuela();
			escuela.AñoDeCreación = 2005;
			escuela.Pais = "Perú";
			escuela.Ciudad = "Huaraz";
			escuela.Dirección = "Jr raymondi";
			escuela.TipoEscuela = TiposEscuela.Secundaria;
			escuela.Nombre = "Platzi school";



			//cargar cursos de la escuela

			var cursos = CargarCursos(escuela);

			//x cada curso carga asignaturas

			var asignaturas = CargarAsignaturas(cursos);

			//x cada asignatura se carga alumnos
			var alumnos = CargarAlumnos(cursos);

			modelBuilder.Entity<Escuela>().HasData(escuela);  //Este no es el mecanismo normal de inserción de datos
			modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
			modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
			modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());

		}

		private List<Alumno> CargarAlumnos(List<Curso> cursos)
		{
			var listaAlumnos = new List<Alumno>();

			Random rnd = new Random();
			foreach (var curso in cursos)
			{
				int cantRandom = rnd.Next(5, 20);
				var tmplist = GenerarAlumnosAlAzar(curso, cantRandom);
				listaAlumnos.AddRange(tmplist);
			}
			return listaAlumnos;
		}
		private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
		{
			var listaCompleta = new List<Asignatura>();

			foreach (var curso in cursos)
			{
				var tmpList = new List<Asignatura>(){
								new Asignatura{Nombre="Matemáticas", CursoId = curso.Id},
								new Asignatura{Nombre="Educación", CursoId = curso.Id},
								new Asignatura{Nombre="Castellano", CursoId = curso.Id},
								new Asignatura{Nombre="Ciencias naturales", CursoId = curso.Id}};

				listaCompleta.AddRange(tmpList);
				//curso.Asignaturas = tmpList;
			}

			return listaCompleta;
		}

		private static List<Curso> CargarCursos(Escuela escuela)
		{
			return new List<Curso>(){
				new Curso(){
					EscuelaId = escuela.Id,
					Nombre = "101",
					Jornada = TiposJornada.Mañana
				},
				new Curso(){
					EscuelaId = escuela.Id,
					Nombre = "201",
					Jornada = TiposJornada.Mañana
				},
				new Curso(){
					EscuelaId = escuela.Id,
					Nombre = "301",
					Jornada = TiposJornada.Noche
				},
				new Curso(){
					EscuelaId = escuela.Id,
					Nombre = "401",
					Jornada = TiposJornada.Mañana
				},
				new Curso(){
					EscuelaId = escuela.Id,
					Nombre = "501",
					Jornada = TiposJornada.Tarde
				}
			};
		}
		private List<Alumno> GenerarAlumnosAlAzar(
					Curso curso,
					int cantidad)
		{
			string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
			string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
			string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

			var listaAlumnos = from n1 in nombre1
												 from n2 in nombre2
												 from a1 in apellido1
												 select new Alumno
												 {
													 CursoId = curso.Id,
													 Nombre = $"{n1} {n2} {a1}"
												 };

			return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
		}
	}
}
