using System;
using CustomConversions;

Console.WriteLine("***** Fun with Conversions *****\n");
// Make a Rectangle.
Rectangle r = new Rectangle(15, 4);
Console.WriteLine(r.ToString());
r.Draw();
Console.WriteLine();
// Convert r into a Square,
// based on the height of the Rectangle.
Square s = (Square)r;
Console.WriteLine(s.ToString());
s.Draw();
// Convert Rectangle to Square to invoke method.
Rectangle rect = new Rectangle(10, 5);
DrawSquare((Square)rect);
// Converting an int to a Square.
Square sq2 = (Square)90;
Console.WriteLine("sq2 = {0}", sq2);
// Converting a Square to an int.
int side = (int)sq2;
Console.WriteLine("Side length of sq2 = {0}", side);
// Implicit cast OK!
Square s3 = new Square { Length = 7 };
Rectangle rect2 = s3;
Console.WriteLine("rect2 = {0}", rect2);
// Explicit cast syntax still OK!
Square s4 = new Square { Length = 3 };
Rectangle rect3 = (Rectangle)s4;
Console.WriteLine("rect3 = {0}", rect3);
Console.ReadLine();

// This method requires a Square type.
static void DrawSquare(Square sq)
{
    Console.WriteLine(sq.ToString());
    sq.Draw();
}