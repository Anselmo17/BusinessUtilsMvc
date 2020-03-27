using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessUtilsMvc.Models.ViewModels;
using BusinessUtilsMvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessUtilsMvc.Controllers
{
   
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> list = new List<Department>();

            // adicionando dados
            list.Add(new Department { Id = 1, Name = "Eletronics" });
            list.Add(new Department { Id = 2, Name = "Fashion" });
            list.Add(new Department { Id = 3, Name = "Alimentos" });
            list.Add(new Department { Id = 4, Name = "Utensilios" });


            return View(list);
        }

    }
}