using Crud_MVC.Models;
using Crud_MVC.Models.Enums;

namespace Crud_MVC.Data
{
    public class SeedingService
    {
        private readonly Crud_MVCContext _context;
        public SeedingService(Crud_MVCContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
                return;

            Department d1 = new Department("Computers");
            Department d2 = new Department("Electronics");
            Department d3 = new Department("Fashion");
            Department d4 = new Department("Books");

            Seller s1 = new Seller("Bob Brown", "bobBrown@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller("Maria Green", "mariaGreen@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
            Seller s3 = new Seller("Alex Grey", "alexGrey@outlook.com", new DateTime(1988, 1, 15), 2200.0, d1);
            Seller s4 = new Seller("Mateus Paulino", "mateusgpaulino@gmail.com", new DateTime(2006, 1, 12), 1000.0, d4);
            Seller s5 = new Seller("LuizaPimenta", "luizapimenta2006@gmail.com", new DateTime(1987, 12, 31), 7500.0, d2);
            Seller s6 = new Seller("Fernando Alvaro", "fernandoAlvaro@outlook.com", new DateTime(1993, 10, 21), 8700.0, d3);

            SalesRecord r1 = new SalesRecord(new DateTime(2023, 09, 25), 11000.0, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(new DateTime(2023, 09, 4), 7000.0, SaleStatus.Billed, s5);
            SalesRecord r3 = new SalesRecord(new DateTime(2023, 09, 13), 4000.0, SaleStatus.Canceled, s4);
            SalesRecord r4 = new SalesRecord(new DateTime(2023, 09, 1), 8000.0, SaleStatus.Billed, s1);
            SalesRecord r5 = new SalesRecord(new DateTime(2023, 09, 21), 3000.0, SaleStatus.Billed, s3);
            SalesRecord r6 = new SalesRecord(new DateTime(2023, 09, 15), 2000.0, SaleStatus.Billed, s1);
            SalesRecord r7 = new SalesRecord(new DateTime(2023, 09, 28), 13000.0, SaleStatus.Billed, s2);
            SalesRecord r8 = new SalesRecord(new DateTime(2023, 09, 11), 4000.0, SaleStatus.Billed, s4);
            SalesRecord r9 = new SalesRecord(new DateTime(2023, 09, 14), 11000.0, SaleStatus.Pending, s6);
            SalesRecord r10 = new SalesRecord(new DateTime(2023, 09, 7), 9000.0, SaleStatus.Billed, s6);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10);

            _context.SaveChanges();
        }
    }
}
