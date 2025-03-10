using Microsoft.EntityFrameworkCore;
using Jendri_Hidalgo_P2_AP1.Models;


namespace Jendri_Hidalgo_P2_AP1.DAL
{
	public class Context : DbContext
	{

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<CiudadesDetalle>().HasData(new List<CiudadesDetalle>());
			{
				new CiudadesDetalle { DetalleId = 1, CiudadId = 1, Nombre = "Santiago" };
				new CiudadesDetalle { DetalleId = 2, CiudadId = 2, Nombre = "Santo Domingo" };
				new CiudadesDetalle { DetalleId = 3, CiudadId = 3, Nombre = "Jarabacoa" };
			}
		}

	}


}
