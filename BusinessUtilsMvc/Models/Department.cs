

using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessUtilsMvc.Models
{
    public class Department
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        // construtores
        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        //metodos
        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSellers(DateTime init , DateTime end)
        {

            return Sellers.Sum(sr => sr.TotalSales(init, end));
        }
    }
}
