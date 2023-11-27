namespace UserNotification
{
    public interface INotification
    {
        Task RecieveNotification(string message);
    }
}
