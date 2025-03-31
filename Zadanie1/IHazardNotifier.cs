namespace Zadanie1;

public interface IHazardNotifier
{
    void notifyAboutHazard(string containerId, string message)
    {
        Console.WriteLine($"[Hazard Notification] Container: {containerId}, Message: {message}");
    }
}