using Crud_MVC.Data;
using Crud_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_MVC.Services
{
    public class DepartmentService
    {
        private readonly Crud_MVCContext _context;

        public DepartmentService(Crud_MVCContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(d => d.Name).ToListAsync();
        }
    }
}
