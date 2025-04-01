using Builder;

Director director = new Director();

var builder1 = new ConcreteProductBuilder1();
var builder2 = new ConcreteProductBuilder2();

director.SetProductBuilder(builder1);
director.Construct();

var product1 = builder1.GetResult();
product1.ShowResult();

director.SetProductBuilder(builder2);
director.Construct();

var product2 = builder2.GetResult();
product2.ShowResult();
