using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessUtilsMvc.Models;

namespace BusinessUtilsMvc.Services
{
    public class SellersService
    {

        //readonly previni a dependencia para nao ser alterada
        private readonly BusinessUtilsMvcContext _context;

        // construtor
        public SellersService(BusinessUtilsMvcContext context)
        {
            _context = context;
        }

        // metodos 
        // espera o retorno dos dados 
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

    }
}
