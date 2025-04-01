namespace Observer;

public class ConcreteSubject : Subject
{
    private string subjectState;
    
    public string SubjectState
    {
        get => subjectState;
        set => subjectState = value ?? throw new ArgumentNullException(nameof(value));
    }
}