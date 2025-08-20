using _10456157_CLDV6212_PART1.Controllers;
using Microsoft.AspNetCore.Mvc;
using _10456157_CLDV6212_PART1.Models;
using _10456157_CLDV6212_PART1.Services;

namespace _10456157_CLDV6212_PART1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly TableStorageService _tableService;

        public CustomerController(TableStorageService tableService)
        {
            _tableService = tableService;
        }

        public IActionResult Index()
        {
            var customers = _tableService.GetCustomers().ToList();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CustomerEntity customer)
        {
            if (ModelState.IsValid)
            {
                await _tableService.AddCustomerAsync(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }
    }
}
