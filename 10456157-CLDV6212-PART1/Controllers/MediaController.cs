using _10456157_CLDV6212_PART1.Services;
using Microsoft.AspNetCore.Mvc;

namespace _10456157_CLDV6212_PART1.Controllers
{
    public class MediaController : Controller
    {
        private readonly BlobStorageService _blobService;

        public MediaController(BlobStorageService blobService)
        {
            _blobService = blobService;
        }

        public IActionResult Index()
        {
            var files = _blobService.ListFiles();
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
                await _blobService.UploadFileAsync(stream, file.FileName);
            }
            return RedirectToAction("Index");
        }
    }
}
