using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Portfolio.Core.Interfaces.Repositories;
using Portfolio.Core.Interfaces.Repositories.Queries;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Data.Repositories
{
    public class SubscriberRepository : ISubscriberRepository
    {
        private readonly ISubscriberCommandText _subscriberCommandText;
        private readonly string _connectionString;

        public SubscriberRepository(IConfiguration config, ISubscriberCommandText subCommandText)
        {
            _subscriberCommandText = subCommandText;
            _connectionString = config.GetConnectionString("DefaultConnection");
        }
        
        public async Task<IEnumerable<Subscriber>> GetActiveSubscribers()
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            var query = await connection.QueryAsync<Subscriber>(_subscriberCommandText.GetActiveSubscribers);
            return query;
        }

        public async Task AddNewSubscriber(string email, bool subscribed)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(_subscriberCommandText.AddNewSubscriber,
                new {Email = email, Subscribed = subscribed});
        }

        public async Task UnsubscribeEmail(string email)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(_subscriberCommandText.UnsubscribeEmail, new {Email = email});
        }
    }
}