using System.Linq;
using System.Threading.Tasks;
using Portfolio.Core.Interfaces.Repositories;
using Portfolio.Core.Services;
using Xunit;

namespace Portfolio.Tests.Core.Services.Subscriber
{
    public class SubscriberServiceTests
    {
        private readonly SubscriberService _subscriberService;

        public SubscriberServiceTests()
        {
            ISubscriberRepository repository = new SubscriberRepositoryFake();
            _subscriberService = new SubscriberService(repository);
        }

        [Fact]
        public async Task AddNewSubscriber_WhenCalled_ReturnsOnlyActiveSubscribers()
        {
            var result = await _subscriberService.GetActiveSubscribers();
            
            Assert.True(result.All(r => r.Subscribed));
        }
    }
}