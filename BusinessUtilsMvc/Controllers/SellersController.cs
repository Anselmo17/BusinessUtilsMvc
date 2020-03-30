using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessUtilsMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusinessUtilsMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellersService _sellerService;


        // construtor
        public SellersController(SellersService sellerService)
        {
            _sellerService = sellerService;
        }


        // metodos 
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            
            //retorna os dados
            return View(list);
        }
    }
}