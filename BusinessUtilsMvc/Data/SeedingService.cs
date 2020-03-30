using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessUtilsMvc.Models;
using BusinessUtilsMvc.Models.Enums;

namespace BusinessUtilsMvc.Data
{
    public class SeedingService
    {

        private BusinessUtilsMvcContext _context;

        public SeedingService(BusinessUtilsMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            // verifica se existe dados na tabela
            if(_context.Department.Any() || 
                _context.Seller.Any() ||
               _context.SalesRecord.Any())
            {
                return;  
            }

            Department d1 = new Department(1,"Departament");
            Department d2 = new Department(2, "Electronics");
   
            Seller s1 = new Seller(1,"Bob Brown", "bob@gmail.com", new DateTime(1998,4,21), 1000.0 , d1);
            Seller s2 = new Seller(2, "Jessia Brown", "jessia@gmail.com", new DateTime(1998, 4, 21), 1000.0, d2);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Billed,s1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Billed, s2);

            // adiciona os dados no banco
            _context.Department.AddRange(d1,d2);
            _context.Seller.AddRange(s1,s2);
            _context.SalesRecord.AddRange(sr1,sr2);

            //salva as alteracoes
            _context.SaveChanges();

        }
    }
}
