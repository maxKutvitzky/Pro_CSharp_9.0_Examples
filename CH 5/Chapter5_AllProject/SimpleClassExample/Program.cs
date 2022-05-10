using System;
using SimpleClassExample;

Console.WriteLine("***** Fun with Class Types *****\n");
// Allocate and configure a Car object.
Car myCar = new Car();
myCar.petName = "Henry";
myCar.currSpeed = 10;
// Speed up the car a few times and print out the
// new state.
for (int i = 0; i <= 10; i++)
{
    myCar.SpeedUp(5);
    myCar.PrintState();
}

Console.WriteLine("\n***** Fun with Class Types *****\n");
// Invoking the default constructor.
Car chuck = new Car();
// Prints "Chuck is going 10 MPH."
chuck.PrintState();

Console.WriteLine("\n***** Fun with Class Types *****\n");
// Make a Car called Chuck going 10 MPH.
Car chuck1 = new Car();
chuck1.PrintState();
// Make a Car called Mary going 0 MPH.
Car mary = new Car("Mary");
mary.PrintState();
// Make a Car called Daisy going 75 MPH.
Car daisy = new Car("Daisy", 75);
daisy.PrintState();

Console.WriteLine("\n***** Fun with Class Types *****\n");
Motorcycle mc = new Motorcycle();
mc.PopAWheely();
// Make a Motorcycle with a rider named Tiny?
Motorcycle c = new Motorcycle(5);
c.SetDriverName("Tiny");
c.PopAWheely();
Console.WriteLine("Rider name is {0}", c.driverName); // Prints an empty name value!

Console.WriteLine("\n***** Fun with class Types *****\n");
// Make a Motorcycle.
Motorcycle c1 = new Motorcycle(5);
c1.SetDriverName("Tiny"); 
c1.PopAWheely();
Console.WriteLine("Rider name is {0}", c1.driverName);
Console.ReadLine();

Console.ReadLine();

