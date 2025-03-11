using Microsoft.EntityFrameworkCore;
using Jendri_Hidalgo_P2_AP1.Models;
using System.Linq.Expressions;
using Jendri_Hidalgo_P2_AP1.DAL;

namespace Jendri_Hidalgo_P2_AP1.Services
{
	public class CiudadesDetalleService(IDbContextFactory<Context> DbContextFactory)
	{

		private async Task<bool> Existe(int DetalleId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.CiudadesDetalle.AnyAsync(p => p.DetalleId == DetalleId);
		}
		private async Task<bool> Insertar(CiudadesDetalle CiudadesDetalle)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			context.CiudadesDetalle.Add(CiudadesDetalle);
			return await context.SaveChangesAsync() > 0;
		}

		public async Task<bool> Guardar(CiudadesDetalle CiudadesDetalle)
		{
			if (!await Existe(CiudadesDetalle.DetalleId))
			{
				return await Insertar(CiudadesDetalle);
			}
			else
			{
				return await Modificar(CiudadesDetalle);
			}
		}

		private async Task<bool> Modificar(CiudadesDetalle CiudadesDetalle)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			context.Update(CiudadesDetalle);
			return await context.SaveChangesAsync() > 0;
		}

		public async Task<CiudadesDetalle?> Buscar(int DetalleId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.CiudadesDetalle
				.FirstOrDefaultAsync(p => p.DetalleId == DetalleId);
		}

		public async Task<bool> Eliminar(int DetalleId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.CiudadesDetalle.Where(p => p.DetalleId == DetalleId)
				.ExecuteDeleteAsync() > 0;
		}

		public async Task<List<CiudadesDetalle>> Listar(Expression<Func<CiudadesDetalle, bool>> criterio)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.CiudadesDetalle.Where(criterio).ToListAsync();
		}


	}

}
