namespace Mediator;

internal class ConcreteColleague1 : Colleague
{
    public ConcreteColleague1(Mediator mediator) : base(mediator)
    {
    }

    public void Notify(string message)
    {
        Console.WriteLine($"Colleague 1 message: {message}");
    }

    public void Send(string message)
    {
        mediator.Send(message, this);
    }
}