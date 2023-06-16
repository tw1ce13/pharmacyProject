using System;
namespace PharmacyProject.DAL.Interfaces
{
	public interface IBaseRepository<T>
	{
		Task<IEnumerable<T>> GetAll();
		Task<T> GetById(int id);
		void Add(T data);
		void Delete(T data);
		Task<T> GetbyName(string name);
		Task Update(T data);
	}
}

