using Jendri_Hidalgo_P2_AP1.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Jendri_Hidalgo_P2_AP1.Models;

namespace Jendri_Hidalgo_P2_AP1.Services
{
	public class EncuestaService(IDbContextFactory<Context> DbContextFactory)
	{

		private async Task<bool> Existe (int EncuestaId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Encuesta.AnyAsync(p => p.EncuestaId == EncuestaId);
		}

		private async Task<bool> Insertar(Encuesta Encuesta)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			context.Encuesta.Add(Encuesta);
			return await context.SaveChangesAsync() > 0;
		}

		public async Task<bool> Guardar(Encuesta Encuesta)
		{
			if (!await Existe(Encuesta.EncuestaId))
			{
				return await Insertar(Encuesta);
			}
			else
			{
				return await Modificar(Encuesta);
			}
		}


		private async Task<bool> Modificar(Encuesta Encuesta)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			context.Update(Encuesta);
			return await context.SaveChangesAsync() > 0;

		}

		public async Task<Encuesta?> Buscar(int EncuestaId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Encuesta
				.FirstOrDefaultAsync(p => p.EncuestaId == EncuestaId);
		}


		public async Task<bool> Eliminar(int EncuestaId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Encuesta.Where(p => p.EncuestaId == EncuestaId)
				.ExecuteDeleteAsync() > 0;
		}

		public async Task<List<Encuesta>> Listar(Expression<Func<Encuesta, bool>> criterio)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Encuesta.Where(criterio).ToListAsync();

		}


	}
}
