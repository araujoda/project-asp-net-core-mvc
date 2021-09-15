using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SalesWeb.Models
{
    public class Seller
    {
        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Departament departament)
        {
            Id = id;
            Name = name;
            Email = email;
            this.birthDate = birthDate;
            BaseSalary = baseSalary;
            Departament = departament;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime birthDate { get; set; }
        public double BaseSalary { get; set; }
        public Departament Departament { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public void AddSales(SalesRecord sr)
        {
            if (sr != null)
                Sales.Add(sr);
        }
        public void RemoveSale(SalesRecord sr)
        {
            if (sr != null)
                Sales.Remove(sr);
        }
        public double totalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(a => a.Date >= initial && a.Date <= final).Sum(a => a.Amount);
        }
    }

}
