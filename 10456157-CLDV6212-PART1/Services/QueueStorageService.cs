using Azure.Storage.Queues;

namespace _10456157_CLDV6212_PART1.Services
{
    public class QueueStorageService
    {
        private readonly QueueClient _queueClient;

        public QueueStorageService(string connectionString)
        {
            _queueClient = new QueueClient(connectionString, "orders");
            _queueClient.CreateIfNotExists();
        }

        public async Task SendMessageAsync(string message)
        {
            await _queueClient.SendMessageAsync(message);
        }

        public async Task<List<string>> GetOrdersAsync()
        {
            var messages = await _queueClient.PeekMessagesAsync(maxMessages: 32); 
            List<string> results = new();

            foreach (var msg in messages.Value)
            {
                results.Add(msg.MessageText);
            }

            return results;
        }

    }
}
