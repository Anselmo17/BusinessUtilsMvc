﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessUtilsMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusinessUtilsMvc.Controllers
{
    public class SalesRecordsController : Controller
    {

        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate , DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                int month = 1 , day = 1;
                int year = DateTime.Now.Year;
                minDate = new DateTime(year, month, day);
            }

            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
          
            var result = await _salesRecordService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}