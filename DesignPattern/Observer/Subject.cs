namespace Observer;

public abstract class Subject
{
    private List<Observer> observerList = new List<Observer>();

    public void Attach(Observer observer)
    {
        observerList.Add(observer);
    }
    
    public void Detach(Observer observer)
    {
        observerList.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in observerList)
        {
            observer.Update();
        }
    }
}