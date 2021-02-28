using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Core.Interfaces.Services
{
    public interface ISubscriberService
    {
        Task<IEnumerable<Subscriber>> GetActiveSubscribers();

        Task AddNewSubscriber(CreateSubscriberRequest request);

        Task UnsubscribeEmail(string email);
    }
}