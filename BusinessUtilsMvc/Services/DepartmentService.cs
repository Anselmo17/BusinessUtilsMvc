using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessUtilsMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessUtilsMvc.Services
{
    public class DepartmentService
    {
        //readonly previni a dependencia para nao ser alterada
        private readonly BusinessUtilsMvcContext _context;

        // construtor
        public DepartmentService(BusinessUtilsMvcContext context)
        {
            _context = context;
        }

        // metodos
        // nao bloqueia a aplicacao
        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }


    }
}
