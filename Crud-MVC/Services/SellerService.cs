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

        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.FirstOrDefault(s => s.Id == id);
        }

        public void Remove(int id)
        {
            var seller = _context.Seller.Find(id);
            
            _context.Seller.Remove(seller);
            _context.SaveChanges();
        }
    }
}
