
using System.Collections.Generic;
using System;
using System.Linq;

namespace BusinessUtilsMvc.Models
{
    public class Seller
    {

        //atributos
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate  { get; set; }
       public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        // construtores
        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        // metodos
        public void addSeller(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void removeSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        // filtra os dados em um determinado periodo e devolve o total
        public double totalSales(DateTime start , DateTime end)
        {
            return Sales.Where(sr => sr.Date >= start && sr.Date <= end).Sum(sr => sr.Amount);
        }


    }
}
