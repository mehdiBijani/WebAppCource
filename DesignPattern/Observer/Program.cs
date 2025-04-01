
using Observer;

ConcreteSubject subject = new ConcreteSubject();

subject.Attach(new ConcreteObserver(subject, "observer1"));
subject.Attach(new ConcreteObserver(subject, "observer2"));
subject.Attach(new ConcreteObserver(subject, "observer3"));

subject.SubjectState = "Updated";
subject.Notify();