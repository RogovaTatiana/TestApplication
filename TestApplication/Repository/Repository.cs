using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestApplication.Models;

namespace TestApplication
{
	public class Repository<T> : IRepository<T> where T : TEntity
	{
		protected DbContext DBContext;
		public Repository(DbContext dataContext)
		{
			DBContext = dataContext;
		}
		public void Insert(T entity)
		{
			DBContext.Set<T>().Add(entity);
		}
		public void Delete(T entity)
		{
			DBContext.Set<T>().Remove(entity);
		}
		public void Update(T entity, T newValue)
		{
			var entry = DBContext.Entry<T>(entity);
			entry.CurrentValues.SetValues(newValue);
			entry.State = EntityState.Modified;
		}
		public IQueryable<T> SelectAll()
		{
			return DBContext.Set<T>();
		}
		public void SubmitAll()
		{
			DBContext.SaveChanges();
		}

		public T Select(int id)
		{
			var res = from d in DBContext.Set<T>()
					  where d.Id.Equals(id)
					  select d;
			if (res.Count<T>() > 0)
			{
				return res.ToList<T>()[0];
			}
			else
			{
				return null;
			}
		}

	}
}