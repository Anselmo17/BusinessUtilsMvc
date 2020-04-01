using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessUtilsMvc.Models;
using BusinessUtilsMvc.Models.ViewModels;
using BusinessUtilsMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusinessUtilsMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellersService _sellerService;
        private readonly DepartmentService _departmentService;


        // construtor
        public SellersController(SellersService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
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
            var departments = _departmentService.FindAll();
            // adiciona os departments a view
            var viewModel = new SellerFormViewModel { Departments = departments};
            return View(viewModel);
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

        public IActionResult Delete(int? id)
        {

            if(id == null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);

            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

    }
}