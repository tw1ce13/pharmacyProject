using System;
using Microsoft.EntityFrameworkCore;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Models;
namespace PharmacyProject.DAL.Repositories
{
	public class OrderRepository : IBaseRepository<Order>
	{
        private readonly PharmacyContext _context;
		public OrderRepository(PharmacyContext context)
		{
            _context = context;
		}

        public void Add(Order data)
        {
            _context.Orders.Add(data);
            _context.SaveChangesAsync();
        }

        public void Delete(Order data)
        {
            _context.Orders.Remove(data);
            _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Order>> GetAll()
        {
            var list = await _context.Orders.ToListAsync();
            return list;
        }

        public async Task<Order> GetById(int id)
        {
            var obj = await _context.Orders.FindAsync(id);
            return obj!;
        }

        public async Task<Order> GetbyName(string name)
        {
            var obj = await _context.Orders.FindAsync(name);
            return obj!;
        }

        public async Task Update(Order data)
        {
            if (data != null)
            {
                _context.Orders.Update(data);
            }
            await _context.SaveChangesAsync();
        }
    }
}

