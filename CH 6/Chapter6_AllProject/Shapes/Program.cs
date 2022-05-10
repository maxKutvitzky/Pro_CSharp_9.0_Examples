using Shapes;
using System;

Console.WriteLine("***** Fun with Polymorphism *****\n");
Hexagon hex = new Hexagon("Beth"); 
hex.Draw();
Circle cir = new Circle("Cindy");
// Calls base class implementation!
cir.Draw();
Console.WriteLine("***** Fun with Polymorphism *****\n");
// Make an array of Shape-compatible objects.
Shape[] myShapes = {new Hexagon(), new Circle(), new Hexagon("Mick"),
 new Circle("Beth"), new Hexagon("Linda")};
// Loop over each item and interact with the
// polymorphic interface.
foreach (Shape s in myShapes)
{
    s.Draw();
}
Console.ReadLine();
