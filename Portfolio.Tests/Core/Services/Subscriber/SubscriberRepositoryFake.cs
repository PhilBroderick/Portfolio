using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Core.Interfaces.Repositories;

namespace Portfolio.Tests.Core.Services.Subscriber
{
    public class SubscriberRepositoryFake : ISubscriberRepository
    {
        public Task<IEnumerable<Portfolio.Core.ServiceModels.Subscriber>> GetActiveSubscribers()
        {
            return Task.FromResult(new[]
            {
                new Portfolio.Core.ServiceModels.Subscriber
                {
                    Email = "test1@test.com",
                    Subscribed = true
                }
            }.AsEnumerable());
        }

        public Task AddNewSubscriber(string email, bool subscribed)
        {
            throw new System.NotImplementedException();
        }

        public Task UnsubscribeEmail(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}