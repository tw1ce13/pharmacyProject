using System;
using PharmacyProject.Domain.Models;
using PharmacyProject.Domain.Response;

namespace PharmacyProject.Services.Interfaces
{
	public interface IEmployeeService
	{
        Task<IBaseResponse<IEnumerable<Employee>>> GetAll();
        Task<IBaseResponse<Employee>> Get(int id);
        IBaseResponse<Employee> Delete(int id);
        IBaseResponse<Employee> Delete(Employee obj);
        IBaseResponse<Employee> Add(Employee obj);
        IBaseResponse<Employee> Update(Employee obj);
    }
}

