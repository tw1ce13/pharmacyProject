using System;
using Microsoft.EntityFrameworkCore;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Models;
namespace PharmacyProject.DAL.Repositories
{
	public class PatientRepository : IBaseRepository<Patient>
	{
		private readonly PharmacyContext _context;
		public PatientRepository(PharmacyContext context)
		{
			_context = context;
		}

        public void Add(Patient data)
        {
            _context.Patients.Add(data);
            _context.SaveChangesAsync();
        }

        public void Delete(Patient data)
        {
            _context.Patients.Remove(data);
            _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Patient>> GetAll()
        {
            var list = await _context.Patients.ToListAsync();
            return list;
        }

        public async Task<Patient> GetById(int id)
        {
            var obj = await _context.Patients.FindAsync(id);
            return obj!;
        }

        public async Task<Patient> GetbyName(string name)
        {
            var obj = await _context.Patients.FindAsync(name);
            return obj!;
        }

        public async Task Update(Patient data)
        {
            if (data != null)
                _context.Patients.Update(data);
            await _context.SaveChangesAsync();
        }
    }
}

