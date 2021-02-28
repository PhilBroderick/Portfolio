using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Core.Interfaces.Repositories
{
    public interface ISubscriberRepository
    {
        Task<IEnumerable<Subscriber>> GetActiveSubscribers();

        Task AddNewSubscriber(string email, bool subscribed);

        Task UnsubscribeEmail(string email);
    }
}