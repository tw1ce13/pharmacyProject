using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Response;

namespace PharmacyProject.Services.Interfaces;

public interface IEmployeeService
{
    Task<IBaseResponse<IEnumerable<Employee>>> GetAll();
    Task<IBaseResponse<Employee>> Get(int id, CancellationToken token);
    Task<IBaseResponse<Employee>> Delete(int id);
    Task<IBaseResponse<Employee>> Delete(Employee obj);
    Task<IBaseResponse<Employee>> Add(Employee obj);
    Task<IBaseResponse<Employee>> Update(Employee obj);
}

