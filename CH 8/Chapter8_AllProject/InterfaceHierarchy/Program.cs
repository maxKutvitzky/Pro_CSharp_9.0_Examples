using System;
using InterfaceHierarchy;

Console.WriteLine("***** Simple Interface Hierarchy *****");
// Call from object level.
BitmapImage myBitmap = new BitmapImage();
myBitmap.Draw();
myBitmap.DrawInBoundingBox(10, 10, 100, 150);
myBitmap.DrawUpsideDown();
// Get IAdvancedDraw explicitly.
if (myBitmap is IAdvancedDraw iAdvDraw)
{
    iAdvDraw.DrawUpsideDown();
}

if (myBitmap is IAdvancedDraw iAdvDraw1)
{
    iAdvDraw1.DrawUpsideDown();
    Console.WriteLine($"Time to draw: {iAdvDraw1.TimeToDraw()}");
}
//Always calls method on instance:
Console.WriteLine("***** Calling Implemented TimeToDraw *****");
Console.WriteLine($"Time to draw: {myBitmap.TimeToDraw()}");
Console.WriteLine($"Time to draw: {((IDrawable)myBitmap).TimeToDraw()}");
Console.WriteLine($"Time to draw: {((IAdvancedDraw)myBitmap).TimeToDraw()}");

Console.ReadLine();
