using Azure.Storage.Files.Shares;

namespace _10456157_CLDV6212_PART1.Services
{
    public class FileStorageService
    {
        private readonly ShareClient _shareClient;

        public FileStorageService(string connectionString)
        {
            _shareClient = new ShareClient(connectionString, "contracts");
            _shareClient.CreateIfNotExists();
        }

        public async Task UploadFileAsync(Stream fileStream, string fileName)
        {
            var dirClient = _shareClient.GetRootDirectoryClient();
            var fileClient = dirClient.GetFileClient(fileName);

            await fileClient.CreateAsync(fileStream.Length);
            await fileClient.UploadAsync(fileStream);
        }

        public List<string> ListFiles()
        {
            var dirClient = _shareClient.GetRootDirectoryClient();
            return dirClient.GetFilesAndDirectories().Select(f => f.Name).ToList();
        }
    }

}
