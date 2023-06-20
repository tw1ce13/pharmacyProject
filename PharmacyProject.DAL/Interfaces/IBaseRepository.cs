using System;
namespace PharmacyProject.DAL.Interfaces
{
	public interface IBaseRepository<T>
	{
		Task<IEnumerable<T>> GetAll();
		Task<T> GetById(int id, CancellationToken token);
        Task Add(T data);
        Task Delete(T data);
		Task Update(T data);
	}
}

