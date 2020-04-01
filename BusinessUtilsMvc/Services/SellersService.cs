using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessUtilsMvc.Models;
using Microsoft.EntityFrameworkCore;

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

        // inseri os dados no banco
        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        //filtra os dados por id 
        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }


        //remove os dados por id 
        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

    }
}
