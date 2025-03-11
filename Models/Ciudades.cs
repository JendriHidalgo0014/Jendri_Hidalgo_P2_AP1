using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jendri_Hidalgo_P2_AP1.Models
{
	public class Ciudades
	{

		[Key]

		public int CiudadId { get; set; }

		public string Nombre { get; set; }

		public decimal Monto { get; set; }


		[ForeignKey("CiudadId")]
		public ICollection<CiudadesDetalle> CiudadesDetalle { get; set; } = new List<CiudadesDetalle>();

	}
}



