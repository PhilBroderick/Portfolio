using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Portfolio.Core.Interfaces.Repositories;
using Portfolio.Core.Interfaces.Services;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Core.Services
{
    public class SubscriberService : ISubscriberService
    {
        private readonly ISubscriberRepository _subscriberRepository;

        public SubscriberService(ISubscriberRepository subscriberRepository)
        {
            _subscriberRepository = subscriberRepository;
        }
        
        public async Task<IEnumerable<Subscriber>> GetActiveSubscribers()
        {
            return await _subscriberRepository.GetActiveSubscribers();
        }

        public async Task AddNewSubscriber(CreateSubscriberRequest request)
        {
            var (email, subscribed) = request;
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(email);

            await _subscriberRepository.AddNewSubscriber(email, subscribed);
        }

        public async Task UnsubscribeEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(email);

            await _subscriberRepository.UnsubscribeEmail(email);
        }
    }
}