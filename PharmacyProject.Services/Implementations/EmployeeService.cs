using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Enum;
using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Interfaces;
using PharmacyProject.Services.Response;

namespace PharmacyProject.Services.Implementations;

public class EmployeeService : IEmployeeService
{
    private readonly IBaseRepository<Employee> _employeeRepository;
    public EmployeeService(IBaseRepository<Employee> employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }


    public async Task<IBaseResponse<Employee>> Add(Employee employee)
    {
        await _employeeRepository.Add(employee);
        var baseResponse = new BaseResponse<Employee>("Success", StatusCode.OK, employee);
        return baseResponse;
    }


    public async Task<IBaseResponse<Employee>> Delete(int id)
    {
        var employee = new Employee() { Id = id };
        await _employeeRepository.Delete(employee);
        var baseResponse = new BaseResponse<Employee>("Success", StatusCode.OK, employee);
        return baseResponse;
    }


    public async Task<IBaseResponse<Employee>> Delete(Employee employee)
    {
        await _employeeRepository.Delete(employee);
        var baseResponse = new BaseResponse<Employee>("Success", StatusCode.OK, employee);
        return baseResponse;
    }


    public async Task<IBaseResponse<Employee>> Get(int id, CancellationToken token)
    {
        var baseResponse = new BaseResponse<Employee>();
        var employee = await _employeeRepository.GetById(id, token);
        if (employee == null)
        {
            baseResponse.Description = "Не найдено";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        baseResponse.Data = employee;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }


    public async Task<IBaseResponse<IEnumerable<Employee>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<Employee>>();
        var employee = await _employeeRepository.GetAll();
        if (employee == null)
        {
            baseResponse.Description = "Найдено 0 элементов";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        baseResponse.Data = employee;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }


    public async Task<IBaseResponse<Employee>> Update(Employee obj)
    {
        var baseResponse = new BaseResponse<Employee>();
        if (obj == null)
        {
            baseResponse.Description = "Объект не найден";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }


        await _employeeRepository.Update(obj);

        baseResponse.Data = obj;
        baseResponse.Description = "успешно";
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }
}

