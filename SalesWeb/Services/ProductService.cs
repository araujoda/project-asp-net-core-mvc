using Microsoft.EntityFrameworkCore;
using SalesWeb.Data;
using SalesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWeb.Services
{
    public class ProductService
    {
        private readonly SalesWebContext _context;

        public ProductService(SalesWebContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(Product obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Product>> FindAllAsync()
        {
            return await _context.Product.ToListAsync();
        }
    }
}
