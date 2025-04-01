namespace Mediator;

internal class ConcreteColleague2 : Colleague
{
    public ConcreteColleague2(Mediator mediator) : base(mediator)
    {
    }
    
    public void Notify(string message)
    {
        Console.WriteLine($"Colleague 2 message: {message}");
    }
    
    public void Send(string message)
    {
        mediator.Send(message, this);
    }
}