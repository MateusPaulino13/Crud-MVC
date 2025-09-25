using Crud_MVC.Data;
using Crud_MVC.Models;

namespace Crud_MVC.Services
{
    public class SellerService
    {
        private readonly Crud_MVCContext _context;

        public SellerService(Crud_MVCContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
