using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace Jendri_Hidalgo_P2_AP1.Models
{
	public class Encuesta
	{

		[Key]

		public int EncuestaId { get; set; }

		public DateTime Fecha { get; set; }

		public string Asignatura { get; set; }


		public List<CiudadesDetalle> Detalles { get; set; } = new List<CiudadesDetalle>();

	}
}
