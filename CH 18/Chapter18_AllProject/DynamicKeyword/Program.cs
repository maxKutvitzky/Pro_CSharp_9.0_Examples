using System;
using System.Collections.Generic;

static void ImplicitlyTypedVariable()
{
    // a is of type List<int>.
    var a = new List<int> { 90 };
    // This would be a compile-time error!
    // a = "Hello";
}

static void ChangeDynamicDataType()
{
    // Declare a single dynamic data point
    // named "t".
    dynamic t = "Hello!";
    Console.WriteLine("t is of type: {0}", t.GetType());
    t = false;
    Console.WriteLine("t is of type: {0}", t.GetType());
    t = new List<int>();
    Console.WriteLine("t is of type: {0}", t.GetType());
}

static void InvokeMembersOnDynamicData()
{
    dynamic textData1 = "Hello";
    Console.WriteLine(textData1.ToUpper());
    // You would expect compiler errors here!
    // But they compile just fine.
    Console.WriteLine(textData1.toupper());
    Console.WriteLine(textData1.Foo(10, "ee", DateTime.Now));
}

static void InvokeMembersOnDynamicData1()
{
    dynamic textData1 = "Hello";
    try
    {
        Console.WriteLine(textData1.ToUpper());
        Console.WriteLine(textData1.toupper());
        Console.WriteLine(textData1.Foo(10, "ee", DateTime.Now));
    }
    catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
    {
        Console.WriteLine(ex.Message);
    }
}