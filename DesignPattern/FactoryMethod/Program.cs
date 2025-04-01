using FactoryMethod;

// ISampleService sampleService1 = new SampleService1(); 
// ISampleService sampleService2 = new SampleService2();
//
// sampleService1.Execute();
// sampleService2.Execute();

/////////////////////////////////////////////////////////////

ISampleService sampleService3;
ISampleService sampleService4;

Creator creator = new ConcreteCreator();

sampleService3 = creator.GetInstance(5);
sampleService3.Execute();


sampleService4 = creator.GetInstance(-5);
sampleService4.Execute();