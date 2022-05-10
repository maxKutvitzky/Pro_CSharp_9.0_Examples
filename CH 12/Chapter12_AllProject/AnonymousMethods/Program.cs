using System;
using AnonymousMethods;
Console.WriteLine("***** Anonymous Methods *****\n");
int aboutToBlowCounter = 0;
// Make a car as usual.
Car c1 = new Car("SlugBug", 100, 10);
// Register event handlers as anonymous methods.
c1.AboutToBlow += delegate
{
    aboutToBlowCounter++;
    Console.WriteLine("Eek! Going too fast!");
};
c1.AboutToBlow += delegate (object sender, CarEventArgs e)
{
    aboutToBlowCounter++;
    Console.WriteLine("Critical Message from Car: {0}", e.msg);
};

// This will eventually trigger the events.
for (int i = 0; i < 6; i++)
{
    c1.Accelerate(20);
}
Console.WriteLine("AboutToBlow event was fired {0} times.", aboutToBlowCounter);
Console.ReadLine();