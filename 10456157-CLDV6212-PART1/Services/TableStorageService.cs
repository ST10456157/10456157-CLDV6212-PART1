using _10456157_CLDV6212_PART1.Models;
using Azure.Data.Tables;
using Azure;

namespace _10456157_CLDV6212_PART1.Services
{
    public class TableStorageService
    {
        private readonly TableClient _tableClient;

        public TableStorageService(string connectionString)
        {
            var serviceClient = new TableServiceClient(connectionString);
            _tableClient = serviceClient.GetTableClient("Customers");
            _tableClient.CreateIfNotExists();
        }

        public async Task AddCustomerAsync(CustomerEntity customer)
        {
            await _tableClient.AddEntityAsync(customer);
        }

        public Pageable<CustomerEntity> GetCustomers()
        {
            return _tableClient.Query<CustomerEntity>();
        }
    }
}
