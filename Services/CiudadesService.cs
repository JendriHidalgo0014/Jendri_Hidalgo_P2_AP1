using Microsoft.EntityFrameworkCore;
using Jendri_Hidalgo_P2_AP1.Models;
using System.Linq.Expressions;
using Jendri_Hidalgo_P2_AP1.DAL;


namespace Jendri_Hidalgo_P2_AP1.Services
{	
		public class CiudadesService(IDbContextFactory<Context> DbContextFactory)
		{
			private async Task<bool> Existe(int CiudadId)
			{
				await using var context = await DbContextFactory.CreateDbContextAsync();
				return await context.Ciudades.AnyAsync(p => p.CiudadId == CiudadId);

			}

			private async Task<bool> Insertar(Ciudades Ciudades)
			{

				await using var context = await DbContextFactory.CreateDbContextAsync();
				context.Ciudades.Add(Ciudades);
				return await context.SaveChangesAsync() > 0;

			}


			public async Task<bool> Guardar(Ciudades Ciudades)
			{
				if (!await Existe(Ciudades.CiudadId))
				{
					return await Insertar(Ciudades);
				}
				else
				{
					return await Modificar(Ciudades);
				}
			}

			private async Task<bool> Modificar(Ciudades Ciudades)
			{
				await using var context = await DbContextFactory.CreateDbContextAsync();
				context.Update(Ciudades);
				return await context.SaveChangesAsync() > 0;

			}

			public async Task<Ciudades?> Buscar(int CiudadId)
			{
				await using var context = await DbContextFactory.CreateDbContextAsync();
				return await context.Ciudades
					.Include(p => p.CiudadesDetalle) 
					.FirstOrDefaultAsync(p => p.CiudadId == CiudadId);
			}


			public async Task<bool> Eliminar(int CiudadId)
			{
				await using var context = await DbContextFactory.CreateDbContextAsync();
				return await context.Ciudades.Where(p => p.CiudadId == CiudadId)
					.ExecuteDeleteAsync() > 0;
			}

		public async Task<Ciudades?> ObtenerCiudad(Expression<Func<Ciudades, bool>> criterio)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Ciudades.FirstOrDefaultAsync(criterio);
		}

		public async Task<List<Ciudades>> Listar(Expression<Func<Ciudades, bool>> criterio)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Ciudades.Where(criterio).ToListAsync();
		}


		public async Task<bool> Actualizar(Ciudades Ciudades)
			{
				await using var context = await DbContextFactory.CreateDbContextAsync();
				context.Update(Ciudades);
				return await context.SaveChangesAsync() > 0;
			}
		}
		
}








