using System;
using System.IO;
using SimpleDispose;

Console.WriteLine("***** Fun with Dispose *****\n");
// Create a disposable object and call Dispose()
// to free any internal resources.
MyResourceWrapper rw = new MyResourceWrapper();
rw.Dispose();
Console.WriteLine("Demonstrate using declarations");
UsingDeclaration();
Console.ReadLine();
static void UsingDeclaration()
{
    //This variable will be in scope until the end of the method
    using var rw = new MyResourceWrapper();
    //Do something here
    Console.WriteLine("About to dispose.");
    //Variable is disposed at this point.
}

