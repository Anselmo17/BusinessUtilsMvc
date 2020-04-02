using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessUtilsMvc.Models;
using BusinessUtilsMvc.Services.Exceptions;
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
        public async Task <List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        // inseri os dados no banco
        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChangesAsync();
        }

        //filtra os dados por id 
        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }


        //remove os dados por id 
        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
           await  _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = !_context.Seller.Any(x => x.Id == obj.Id);
            if (hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
