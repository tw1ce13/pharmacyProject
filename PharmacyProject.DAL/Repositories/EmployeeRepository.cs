using System;
using Microsoft.EntityFrameworkCore;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Models;

namespace PharmacyProject.DAL.Repositories
{
	public class EmployeeRepository : IBaseRepository<Employee>
	{
		private readonly PharmacyContext _context;
		public EmployeeRepository(PharmacyContext context)
		{
			_context = context;
		}

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChangesAsync();
        }

        public void Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Employee>> GetAll() =>
            await _context.Employees.ToListAsync();

        public async Task<Employee> GetById(int id, CancellationToken token)
        {
            var obj = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id, token);
            return obj!;
        }

        public async Task<Employee> GetbyName(string name)
        {
            var obj = await _context.Employees.FirstOrDefaultAsync(x=>x.Name == name);
            return obj!;
        }

        public async Task Update(Employee employee)
        {
            if (employee != null)
                _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}

