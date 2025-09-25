using Crud_MVC.Data;
using Crud_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_MVC.Services
{
    public class SalesRecordService
    {
        private readonly Crud_MVCContext _context;
        public SalesRecordService(Crud_MVCContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;

            if(minDate.HasValue)
                result = result.Where(x => x.Date >= minDate.Value);

            if(maxDate.HasValue)
                result = result.Where(x => x.Date <= maxDate.Value);

            return await result
                    .Include(x => x.Seller)
                    .Include(x => x.Seller.Department)
                    .OrderByDescending(x => x.Date)
                    .ToListAsync();
        }

        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;

            if(minDate.HasValue)
                result = result.Where(x => x.Date >= minDate.Value);

            if(maxDate.HasValue)
                result = result.Where(x => x.Date <= maxDate.Value);

            return await result
                    .Include(x => x.Seller)
                    .Include(x => x.Seller.Department)
                    .OrderByDescending(x => x.Date)
                    .GroupBy(x => x.Seller.Department)
                    .ToListAsync();
        }
    }
}
