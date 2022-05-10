using System;
using System.Collections.Generic;


Console.WriteLine("***** Fun with Lambdas *****\n");
TraditionalDelegateSyntax();
Console.ReadLine();

static void TraditionalDelegateSyntax()
{
    // Make a list of integers.
    List<int> list = new List<int>();
    list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
    // Call FindAll() using traditional delegate syntax.
    Predicate<int> callback = IsEvenNumber;
    List<int> evenNumbers = list.FindAll(callback);
    Console.WriteLine("Here are your even numbers:");
    foreach (int evenNumber in evenNumbers)
    {
        Console.Write("{0}\t", evenNumber);
    }
    Console.WriteLine();
    // Register with delegate as a lambda expression.
    SimpleMath m = new SimpleMath();
    m.SetMathHandler((msg, result) => Console.WriteLine("Message: {0}, Result: {1}", msg, result));

    //Strong typed params
    //m.SetMathHandler((string msg, int result) => Console.WriteLine("Message: {0}, Result: {1}", msg, result));

    // Prints "Enjoy your string!" to the console.
    VerySimpleDelegate d = new VerySimpleDelegate(() => { return "Enjoy your string!"; });
    VerySimpleDelegate d2 = new VerySimpleDelegate(() => "Enjoy your string!");
    VerySimpleDelegate d3 = () => "Enjoy your string!";
    Console.WriteLine(d());

    // This will execute the lambda expression.
    m.Add(10, 10);
    Console.ReadLine();
}

// Target for the Predicate<> delegate.
static bool IsEvenNumber(int i)
{
    // Is it an even number?
    return (i % 2) == 0;
}

static void AnonymousMethodSyntax()
{
    // Make a list of integers.
    List<int> list = new List<int>();
    list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
    // Now, use an anonymous method.
    List<int> evenNumbers =
    list.FindAll(delegate (int i) { return (i % 2) == 0; });
    Console.WriteLine("Here are your even numbers:");
    foreach (int evenNumber in evenNumbers)
    {
        Console.Write("{0}\t", evenNumber);
    }
    Console.WriteLine();
}

static void LambdaExpressionSyntax()
{
    // Make a list of integers.
    List<int> list = new List<int>();
    list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
    // Now, use a C# lambda expression.
    List<int> evenNumbers = list.FindAll((i) => (i % 2) == 0);
    Console.WriteLine("Here are your even numbers:");
    foreach (int evenNumber in evenNumbers)
    {
        Console.Write("{0}\t", evenNumber);
    }
    Console.WriteLine();
}
static void LambdaExpressionSyntax1()
{
    // Make a list of integers.
    List<int> list = new List<int>();
    list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
    // Now process each argument within a group of
    // code statements.
    List<int> evenNumbers = list.FindAll((i) =>
    {
        Console.WriteLine("value of i is currently: {0}", i);
        bool isEven = ((i % 2) == 0);
        return isEven;
    });
    Console.WriteLine("Here are your even numbers:");
    foreach (int evenNumber in evenNumbers)
    {
        Console.Write("{0}\t", evenNumber);
    }
    Console.WriteLine();
}

public class SimpleMath
{
    public delegate void MathMessage(string msg, int result);
    private MathMessage _mmDelegate;
    public void SetMathHandler(MathMessage target)
    {
        _mmDelegate = target;
    }
    public void Add(int x, int y)
    {
        _mmDelegate?.Invoke("Adding has completed!", x + y);
    }
}

public delegate string VerySimpleDelegate();
