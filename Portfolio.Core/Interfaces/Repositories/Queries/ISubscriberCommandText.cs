namespace Portfolio.Core.Interfaces.Repositories.Queries
{
    public interface ISubscriberCommandText
    {
        string GetActiveSubscribers { get; }
        string AddNewSubscriber { get; }
        string UnsubscribeEmail { get; }
    }
}