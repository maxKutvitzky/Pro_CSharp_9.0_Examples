using System;
using System.Linq;

ForLoopExample();
ForEachLoopExample();
LinqQueryOverInts();
IfElsePatternMatching();
IfElsePatternMatchingUpdatedInCSharp9();
ConditionalRefExample();
SwitchExample();
SwitchOnStringExample();
ExecutePatternMatchingSwitch();


// A basic for loop.
static void ForLoopExample()
{
    Console.WriteLine("\n ForLoopExample() \n");
    // Note! "i" is only visible within the scope of the for loop.
    for (int i = 0; i < 4; i++)
    {
        Console.WriteLine("Number is: {0} ", i);
    }
    // "i" is not visible here.
}

// Iterate array items using foreach.
static void ForEachLoopExample()
{
    Console.WriteLine("\n ForEachLoopExample() \n");
    string[] carTypes = { "Ford", "BMW", "Yugo", "Honda" };
    foreach (string c in carTypes)
    {
        Console.WriteLine(c);
    }
    int[] myInts = { 10, 20, 30, 40 };
    foreach (int i in myInts)
    {
        Console.WriteLine(i);
    }
}

static void LinqQueryOverInts()
{
    Console.WriteLine("\n LinqQueryOverInts() \n");
    int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
    // LINQ query!
    var subset = from i in numbers where i < 10 select i;
    Console.Write("Values in subset: ");
    foreach (var i in subset)
    {
        Console.Write("{0} ", i);
    }
}

static void IfElsePatternMatching()
{
    Console.WriteLine("\n===If Else Pattern Matching ===\n");
    object testItem1 = 123;
    object testItem2 = "Hello";
    if (testItem1 is string myStringValue1)
    {
        Console.WriteLine($"{myStringValue1} is a string");
    }
    if (testItem1 is int myValue1)
    {
        Console.WriteLine($"{myValue1} is an int");
    }
    if (testItem2 is string myStringValue2)
    {
        Console.WriteLine($"{myStringValue2} is a string");
    }
    if (testItem2 is int myValue2)
    {
        Console.WriteLine($"{myValue2} is an int");
    }
    Console.WriteLine();
}

static void IfElsePatternMatchingUpdatedInCSharp9()
{
     Console.WriteLine("\n================ C# 9 If Else Pattern Matching Improvements===============\n");
     object testItem1 = 123;
     Type t = typeof(string);
     char c = 'f';
     //Type patterns
     if (t is Type)
     {
     Console.WriteLine($"{t} is a Type");
     }
     //Relational, Conjuctive, and Disjunctive patterns
     if (c is >= 'a' and <= 'z' or >= 'A' and <= 'Z')
     {
     Console.WriteLine($"{c} is a character");
     };
     //Parenthesized patterns
     if (c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z') or '.' or ',')
     {
     Console.WriteLine($"{c} is a character or separator");
     };
     //Negative patterns
     if (testItem1 is not string)
     {
     Console.WriteLine($"{testItem1} is not a string");
     }
     if (testItem1 is not null)
     {
     Console.WriteLine($"{testItem1} is not null");
     }
     Console.WriteLine();
}

static void ConditionalRefExample()
{
    Console.WriteLine("\nConditionalRefExample()\n");
    var smallArray = new int[] { 1, 2, 3, 4, 5 };
    var largeArray = new int[] { 10, 20, 30, 40, 50 };
    int index = 7;
    ref int refValue = ref ((index < 5) ? ref smallArray[index] : ref largeArray[index - 5]);
    refValue = 0;
    index = 2;
    ((index < 5) ? ref smallArray[index] : ref largeArray[index - 5]) = 100;
    Console.WriteLine(string.Join(" ", smallArray));
    Console.WriteLine(string.Join(" ", largeArray));
}

// Switch on a numerical value.
static void SwitchExample()
{
    Console.WriteLine("\nSwitchExample()\n");
    Console.WriteLine("1 [C#], 2 [VB]");
    Console.Write("Please pick your language preference: ");
    string langChoice = Console.ReadLine();
    int n = int.Parse(langChoice);
    switch (n)
    {
        case 1:
            Console.WriteLine("Good choice, C# is a fine language.");
            break;
        case 2:
            Console.WriteLine("VB: OOP, multithreading, and more!");
            break;
        default:
            Console.WriteLine("Well...good luck with that!");
            break;
    }
}

static void SwitchOnStringExample()
{
    Console.WriteLine("\nSwitchOnStringExample()\n");
    Console.WriteLine("C# or VB");
    Console.Write("Please pick your language preference: ");
    string langChoice = Console.ReadLine();
    switch (langChoice.ToUpper())
    {
        case "C#":
            Console.WriteLine("Good choice, C# is a fine language.");
            break;
        case "VB":
            Console.WriteLine("VB: OOP, multithreading and more!");
            break;
        default:
            Console.WriteLine("Well...good luck with that!");
            break;
    }
}

static void ExecutePatternMatchingSwitch()
{
    Console.WriteLine("\nExecutePatternMatchingSwitch()\n");
    Console.WriteLine("1 [Integer (5)], 2 [String (\"Hi\")], 3 [Decimal (2.5)]");
    Console.Write("Please choose an option: ");
    string userChoice = Console.ReadLine();
    object choice;
    //This is a standard constant pattern switch statement to set up the example
    switch (userChoice)
    {
        case "1":
            choice = 5;
            break;
        case "2":
            choice = "Hi";
            break;
        case "3":
            choice = 2.5;
            break;
        default:
            choice = 5;
            break;
    }
    //This is new the pattern matching switch statement
    switch (choice)
    {
        case int i:
            Console.WriteLine("Your choice is an integer {0}.", i);
            break;
        case string s:
            Console.WriteLine("Your choice is a string. {0}", s);
            break;
        case decimal d:
            Console.WriteLine("Your choice is a decimal. {0}", d);
            break;
        default:
            Console.WriteLine("Your choice is something else");
            break;
    }
    Console.WriteLine();
}