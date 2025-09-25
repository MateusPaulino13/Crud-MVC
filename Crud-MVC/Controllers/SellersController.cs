using Crud_MVC.Models;
using Crud_MVC.Models.ViewModels;
using Crud_MVC.Services;
using Crud_MVC.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Crud_MVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private static DepartmentService _departmentService;
        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            var sellers = _sellerService.FindAllAsync();
            return View(sellers);
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }

            _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var seller = await _sellerService.FindByIdAsync(id.Value);

            if (id == null || seller == null)
                return RedirectToAction(nameof(Error), new { Message = "Id not found" });

            return View(seller);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _sellerService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { Message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            var seller = await _sellerService.FindByIdAsync(id.Value);

            if (id == null || seller == null)
                return RedirectToAction(nameof(Error), new { Message = "Id not found" }); ;

            return View(seller);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var seller = await _sellerService.FindByIdAsync(id.Value);

            if (id == null || seller == null)
                return RedirectToAction(nameof(Error), new { Message = "Id not found" }); ;

            List<Department> departments = await _departmentService.FindAllAsync();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }

            if (id != seller.Id)
                return RedirectToAction(nameof(Error), new { Message = "Id mismatch" }); ;

            try
            {
                await _sellerService.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { Message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}
