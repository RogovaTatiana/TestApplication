using System.Linq;

namespace TestApplication
{
	public interface IRepository<T>
	{
		void Insert(T entity);
		void Delete(T entity);
		void Update(T entity, T newValue);
		IQueryable<T> SelectAll();
		T Select(int id);
		void SubmitAll();
	}
}
