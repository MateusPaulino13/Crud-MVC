using Crud_MVC.Data;
using Crud_MVC.Models;

namespace Crud_MVC.Services
{
    public class DepartmentService
    {
        private readonly Crud_MVCContext _context;

        public DepartmentService(Crud_MVCContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(d => d.Name).ToList();
        }
    }
}
