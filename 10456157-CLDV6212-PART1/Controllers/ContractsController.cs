using Microsoft.AspNetCore.Mvc;
using _10456157_CLDV6212_PART1.Services;

namespace _10456157_CLDV6212_PART1.Controllers
{
    public class ContractsController : Controller
    {
        private readonly FileStorageService _fileService;

        public ContractsController(FileStorageService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            var files = _fileService.ListFiles();
            return View(files);
        }

        [HttpGet]
        public IActionResult Upload() => View();

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null)
            {
                using var stream = file.OpenReadStream();
                await _fileService.UploadFileAsync(stream, file.FileName);
            }
            return RedirectToAction("Index");
        }
    }
}
