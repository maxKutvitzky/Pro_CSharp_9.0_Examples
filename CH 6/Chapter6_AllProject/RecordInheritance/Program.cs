using System;
using RecordInheritance;
using static RecordInheritance.PositionalRecordTypes;

Console.WriteLine("Record type inheritance!");
Car c = new Car("Honda", "Pilot", "Blue");
MiniVan m = new MiniVan("Honda", "Pilot", "Blue", 10);
Console.WriteLine($"Checking MiniVan is-a Car:{m is Car}");
PositionalCar pc = new PositionalCar("Honda", "Pilot", "Blue");
PositionalMiniVan pm = new PositionalMiniVan("Honda", "Pilot", "Blue");
Console.WriteLine($"Checking PositionalMiniVan is-a PositionalCar:{pm is PositionalCar}");
