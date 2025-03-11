using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace Jendri_Hidalgo_P2_AP1.Models
{
	public class CiudadesDetalle
	{		
			
		[Key]
			public int DetalleId { get; set; }

			[ForeignKey("Encuesta")]
			public int EncuestaId { get; set; }  

			[ForeignKey("Ciudades")]
			public int CiudadId { get; set; }

			public string Nombre { get; set; }

			public decimal Monto { get; set; }		

	}

}
