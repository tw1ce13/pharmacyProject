﻿using System;
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

        public void Add(Employee data)
        {
            _context.Employees.Add(data);
            _context.SaveChangesAsync();
        }

        public void Delete(Employee data)
        {
            _context.Employees.Remove(data);
            _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Employee>> GetAll()
        {
            var list = await _context.Employees.ToListAsync();
            return list;
        }

        public async Task<Employee> GetById(int id, CancellationToken token)
        {
            var obj = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id, token);
            return obj!;
        }

        public async Task<Employee> GetbyName(string name)
        {
            var obj = await _context.Employees.FindAsync(name);
            return obj!;
        }

        public async Task Update(Employee data)
        {
            if (data != null)
                _context.Employees.Update(data);
            await _context.SaveChangesAsync();
        }
    }
}

