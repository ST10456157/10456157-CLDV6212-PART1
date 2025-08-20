using Azure.Storage.Blobs;
namespace _10456157_CLDV6212_PART1.Services
{
    public class BlobStorageService
    {
        private readonly BlobContainerClient _containerClient;

        public BlobStorageService(string connectionString)
        {
            var blobServiceClient = new BlobServiceClient(connectionString);
            _containerClient = blobServiceClient.GetBlobContainerClient("product-images");
            _containerClient.CreateIfNotExists();
        }

        public async Task UploadFileAsync(Stream fileStream, string fileName)
        {
            BlobClient blobClient = _containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(fileStream, overwrite: true);
        }

        public List<string> ListFiles()
        {
            return _containerClient.GetBlobs().Select(b => b.Name).ToList();
        }

        public string GetFileUrl(string fileName)
        {
            return _containerClient.GetBlobClient(fileName).Uri.ToString();
        }
    }
}
