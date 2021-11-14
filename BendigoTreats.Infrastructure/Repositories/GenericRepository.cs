using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BendigoTreats.Infrastructure.Repositories
{
	public abstract class GenericRepository<T> : IRepository<T> where T : class
	{
		protected ShoppingContext context;

		public GenericRepository(ShoppingContext context)
		{
			this.context = context;
		}

		public T Add(T entity)
		{
			return context.Add(entity).Entity;
		}

		public IEnumerable<T> All()
		{
			return context.Set<T>().ToList();
		}

		public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
		{
			return context.Set<T>().AsQueryable().Where(predicate).ToList();
		}

		public T Get(Guid id)
		{
			return context.Find<T>(id);
		}

		public void SaveChanges()
		{
			context.SaveChanges();
		}

		public T Update(T entity)
		{
			return context.Update(entity).Entity;
		}
	}
}
