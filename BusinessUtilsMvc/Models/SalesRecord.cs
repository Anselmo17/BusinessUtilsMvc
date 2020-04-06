using System;
using BusinessUtilsMvc.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BusinessUtilsMvc.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }

        [Display(Name = "Sale Status")]
        public SaleStatus SaleStatus { get; set; }
        public Seller Seller { get; set; }

        // construtores
        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus saleStatus, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            SaleStatus = saleStatus;
            Seller = seller;
        }



        //metodos

    }
}
