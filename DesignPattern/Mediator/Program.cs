using Mediator;

ConcreteMediator mediator = new ConcreteMediator();

ConcreteColleague1 colleague1 = new ConcreteColleague1(mediator);
ConcreteColleague2 colleague2 = new ConcreteColleague2(mediator);

mediator.Colleague1 = colleague1;
mediator.Colleague2 = colleague2;

colleague1.Send("message1");
colleague2.Send("message2");