using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessUtilsMvc.Models;
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

        public IActionResult Create()
        {
            return View();
        }

        // anotacao para o metodo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);

            //redireciona a pagina
            return RedirectToAction(nameof(Index));
        }

    }
}