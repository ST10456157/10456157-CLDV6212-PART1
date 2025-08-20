using Microsoft.AspNetCore.Mvc;
using _10456157_CLDV6212_PART1.Services;

namespace _10456157_CLDV6212_PART1.Controllers
{
    public class OrdersController : Controller
    {
        private readonly QueueStorageService _queueService;

        public OrdersController(QueueStorageService queueService)
        {
            _queueService = queueService;
        }

        public async Task<IActionResult> Index()
        {
            var messages = await _queueService.ReceiveMessagesAsync();
            return View(messages);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(string message)
        {
            if (!string.IsNullOrEmpty(message))
                await _queueService.SendMessageAsync(message);

            return RedirectToAction("Index");
        }
    }
}
