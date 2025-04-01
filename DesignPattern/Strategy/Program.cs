
using Strategy;

Context contextA = new Context(new ConcreteStrategyA());
Context contextB = new Context(new ConcreteStrategyB());
Context contextC = new Context(new ConcreteStrategyC());

contextA.Operation();
contextB.Operation();
contextC.Operation();