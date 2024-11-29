using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SchoolExam.Application.Interfaces.Repositories.Base;
using SchoolExam.Domain.Entities.Base;
using SchoolExam.Persistence.Context;
using System;
using System.Linq.Expressions;

namespace SchoolExam.Infrastructure.Repositories
{
	public class Repository<T> : IRepository<T> where T : BaseEntity
    {
		private readonly AppDbContext _context;

		public Repository(AppDbContext context)
		{
			_context = context;
		}
		public DbSet<T> Table => _context.Set<T>();



		public IQueryable<T> GetAll(bool tracking = true)
		{
			var query = Table.AsQueryable();
			if (!tracking)
				query = query.AsNoTracking();
			return query;
		}

		public async Task<T> GetByIdAsync(int id, bool tracking = true)
		{
			var query = Table.AsQueryable();
			if (!tracking)
				query = Table.AsNoTracking();
			return await query.FirstOrDefaultAsync(data => data.Id == id);
		}

		public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
		{
			var query = Table.AsQueryable();
			if (!tracking)
				query = Table.AsNoTracking();
			return await query.FirstOrDefaultAsync(method);
		}

		public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
		{
			var query = Table.Where(method);
			if (!tracking)
				query = query.AsNoTracking();
			return query;
		}



		public async Task<bool> AddAsync(T model)
		{
			EntityEntry<T> entityEntry = await Table.AddAsync(model);

			return entityEntry.State == EntityState.Added;

		}

		public bool Add(T model)
		{
			EntityEntry<T> entityEntry =  Table.Add(model);

			return entityEntry.State == EntityState.Added;

		}

		public bool Remove(T model)
		{
			EntityEntry<T> entityEntry = Table.Remove(model);
			return entityEntry.State == EntityState.Deleted;
		}

		public async Task<bool> RemoveAsync(int id)
		{
			T model = await Table.FirstOrDefaultAsync(data => data.Id == id);
			return Remove(model);
		}

		public bool Update(T model)
		{
			EntityEntry entityEntry = Table.Update(model);
			return entityEntry.State == EntityState.Modified;
		}


		public async Task<bool> SaveAsync()
			 => await _context.SaveChangesAsync() > 0;

		public  bool Save()
			 =>  _context.SaveChanges() > 0;
	}
}
