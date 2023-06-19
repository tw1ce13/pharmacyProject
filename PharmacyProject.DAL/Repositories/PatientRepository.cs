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

        public void Add(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChangesAsync();
        }

        public void Delete(Patient patient)
        {
            _context.Patients.Remove(patient);
            _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Patient>> GetAll()=>
            await _context.Patients.ToListAsync();

        public async Task<Patient> GetById(int id, CancellationToken token)
        {
            var obj = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id, token);
            return obj!;
        }

        public async Task<Patient> GetbyName(string name)
        {
            var obj = await _context.Patients.FindAsync(name);
            return obj!;
        }

        public async Task Update(Patient patient)
        {
            if (patient != null)
                _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }
    }
}

