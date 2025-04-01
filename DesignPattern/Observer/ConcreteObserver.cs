namespace Observer;

public class ConcreteObserver : Observer
{
    private string name;
    private string observerState;
    private ConcreteSubject subject;

    public ConcreteObserver(ConcreteSubject subject, string name)
    {
        this.subject = subject;
        this.name = name;
    }
    public override void Update()
    {
        observerState = subject.SubjectState;
        Console.WriteLine($"Observer {name} new state is {observerState}");
    }
    
    public ConcreteSubject Subject
    {
        get => subject;
        set => subject = value;
    }
}