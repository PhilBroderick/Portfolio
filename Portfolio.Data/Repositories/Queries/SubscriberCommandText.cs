using Portfolio.Core.Interfaces.Repositories.Queries;

namespace Portfolio.Data.Repositories.Queries
{
    public class SubscriberCommandText : ISubscriberCommandText
    {
        public string GetActiveSubscribers => "SELECT Email, Subscribed FROM Subscriber";
        public string AddNewSubscriber => "INSERT INTO Subscriber (Email, Subscribed) VALUES (@Email, @Subscribed)";
        public string UnsubscribeEmail => "UPDATE Subscriber SET Subscribed = 0 WHERE Email = @Email";
    }
}