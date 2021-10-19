using Microsoft.AspNetCore.Mvc;
using SalesWeb.Models;
using SalesWeb.Models.ViewModels;
using SalesWeb.Services;
using SalesWeb.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;
        private readonly DepartmentService _departmentService;

        public ProductsController(ProductService productService, DepartmentService departmentService)
        {
            _productService = productService;
            _departmentService = departmentService;

        }

        public async Task<IActionResult> Index()
        {
            var obj = await _productService.FindAllAsync();
            return View(obj);
        }
        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new ProductFormViewModel { Departments = departments };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new ProductFormViewModel { Departments = departments, Product = product };

                return View(viewModel);
            }
            await _productService.InsertAsync(product);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _productService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productService.RemoveAync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel();
            {
                viewModel.Message = message;
                viewModel.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            }
            return View(viewModel);

        }
    }
}
