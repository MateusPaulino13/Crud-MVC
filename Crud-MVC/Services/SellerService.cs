using Crud_MVC.Data;
using Crud_MVC.Models;
using Crud_MVC.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Crud_MVC.Services
{
    public class SellerService
    {
        private readonly Crud_MVCContext _context;

        public SellerService(Crud_MVCContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller seller)
        {
            _context.Add(seller);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(d => d.Department).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var seller = _context.Seller.Find(id);

                _context.Seller.Remove(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(Seller seller)
        {
            if (!await _context.Seller.AnyAsync(s => s.Id == seller.Id))
                throw new NotFoundException("Id not found");

            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }
        }
    }
}
