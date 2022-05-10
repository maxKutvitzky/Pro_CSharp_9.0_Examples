using System;

Console.WriteLine("**** Fun with Enums *****\n");

EmpTypeEnum emp = EmpTypeEnum.Contractor;
AskForBonus(emp);

Console.WriteLine("EmpTypeEnum uses a {0} for storage", Enum.GetUnderlyingType(emp.GetType()));

// This time use typeof to extract a Type.
Console.WriteLine("EmpTypeEnum uses a {0} for storage", Enum.GetUnderlyingType(typeof(EmpTypeEnum)));

// Prints out "emp is a Contractor".
Console.WriteLine("emp is a {0}.", emp.ToString());

// Prints out "Contractor = 2".
Console.WriteLine("{0} = {1}", emp.ToString(), (byte)emp);

// These types are enums in the System namespace.
EmpTypeEnum e2 = EmpTypeEnum.Contractor;
DayOfWeek day = DayOfWeek.Monday;
ConsoleColor cc = ConsoleColor.Gray;
EvaluateEnum(e2);
EvaluateEnum(day);
EvaluateEnum(cc);

Console.ReadLine();

//local functions go here:
// A custom enumeration.

static void AskForBonus(EmpTypeEnum e)
{
    switch (e)
    {
        case EmpTypeEnum.Manager:
            Console.WriteLine("How about stock options instead?");
            break;
        case EmpTypeEnum.Grunt:
            Console.WriteLine("You have got to be kidding...");
            break;
        case EmpTypeEnum.Contractor:
            Console.WriteLine("You already get enough cash...");
            break;
        case EmpTypeEnum.VicePresident:
            Console.WriteLine("VERY GOOD, Sir!");
            break;
    }
}

// This method will print out the details of any enum.
static void EvaluateEnum(System.Enum e)
{
    Console.WriteLine("=> Information about {0}", e.GetType().Name);
    Console.WriteLine("Underlying storage type: {0}",
    Enum.GetUnderlyingType(e.GetType()));
    // Get all name-value pairs for incoming parameter.
    Array enumData = Enum.GetValues(e.GetType());
    Console.WriteLine("This enum has {0} members.", enumData.Length);
    // Now show the string name and associated value, using the D format
    // flag (see Chapter 3).
    for (int i = 0; i < enumData.Length; i++)
    {
        Console.WriteLine("Name: {0}, Value: {0:D}",
    enumData.GetValue(i));
    }
}
enum EmpTypeEnum
{
    Manager, // = 0
    Grunt, // = 1
    Contractor, // = 2
    VicePresident // = 3
}
