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

        public async Task Add(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Order>> GetAll()=>
            await _context.Orders.ToListAsync();

        public async Task<Order> GetById(int id, CancellationToken token)
        {
            var obj = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id, token);
            return obj!;
        }

        public async Task<Order> GetbyName(string name)
        {
            var obj = await _context.Orders.FindAsync(name);
            return obj!;
        }

        public async Task Update(Order order)
        {
            if (order != null)
            {
                _context.Orders.Update(order);
            }
            await _context.SaveChangesAsync();
        }
    }
}

