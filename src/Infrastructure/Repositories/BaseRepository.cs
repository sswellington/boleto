using Infrastructure.ObjectRelationalMapping.PostgreSql;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public abstract class BaseRepository<T> where T : class
{
	protected readonly BoletoContext _context;

	protected BaseRepository(BoletoContext boletoContext) => _context = boletoContext;

	public virtual async Task Add(T entity)
	{
		await _context.Set<T>().AddAsync(entity).ConfigureAwait(false);
		_context.SaveChanges();
	}

	public virtual async Task Delete(string id)
	{
		var entity = await _context.Set<T>().FindAsync(id).ConfigureAwait(false);

		if (entity is not null)
		{
			_context.Set<T>().Remove(entity);
			_context.SaveChanges();
		}
	}

	public virtual async Task<ICollection<T>> GetAll()
	{
		return await _context.Set<T>().ToListAsync().ConfigureAwait(false);
	}

	public virtual async Task<T?> GetById(int id)
	{
		return await _context.Set<T>().FindAsync(id).ConfigureAwait(false);
	}

	public virtual void Update(T entity)
	{
		_context.Set<T>().Update(entity);
		_context.SaveChanges();
	}

	public virtual async Task Update(T entity, string id)
	{
		var existingEntity = await _context.Set<T>().FindAsync(id).ConfigureAwait(false);

		if (existingEntity is null)
			return;

		_context.Entry(existingEntity).State = EntityState.Detached;
		_context.Set<T>().Update(entity);
		_context.SaveChanges();
	}
}