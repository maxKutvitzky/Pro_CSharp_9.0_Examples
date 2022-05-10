using Employees;
using System;

// Create a subclass object and access base class functionality.
Console.WriteLine("***** The Employee Class Hierarchy *****\n");
SalesPerson fred = new SalesPerson
{
    Age = 31,
    Name = "Fred",
    SalesNumber = 50
};
// Assume Manager has a constructor matching this signature:
// (string fullName, int age, int empId,
// float currPay, string ssn, int numbOfOpts)
Manager chucky = new Manager("Chucky", 50, 92, 100000, "333-23-2322", 9000);

double cost = chucky.GetBenefitCost();
Console.WriteLine($"Benefit Cost: {cost}");
// A better bonus system!
Manager chucky1 = new Manager("Chucky", 50, 92, 100000, "333-23-2322", 9000);
chucky1.GiveBonus(300);
chucky1.DisplayStats();
Console.WriteLine();
SalesPerson fran = new SalesPerson("Fran", 43, 93, 3000, "932-32-3232", 31);
fran.GiveBonus(200);
fran.DisplayStats();
Console.WriteLine();
CastingExamples();
Console.ReadLine();

static void CastingExamples()
{
    // A Manager "is-a" System.Object, so we can
    // store a Manager reference in an object variable just fine.
    object frank = new Manager("Frank Zappa", 9, 3000, 40000, "111-11-1111", 5);
    // Error!
    //GivePromotion(frank);
    //(ClassIWantToCastTo)referenceIHave
    // OK!
    GivePromotion((Manager)frank);

    // A Manager "is-an" Employee too.
    Employee moonUnit = new Manager("MoonUnit Zappa", 2, 3001, 20000, "101-11-1321", 1);
    GivePromotion(moonUnit);

    // A PtSalesPerson "is-a" SalesPerson.
    SalesPerson jill = new PtSalesPerson("Jill", 834, 3002, 100000, "111-12-1119", 90);
    GivePromotion(jill);

    // Ack! You can't cast frank to a Hexagon, but this compiles fine!
    /* object frank1 = new Manager();
     Hexagon hex = (Hexagon)frank1; */

    // Catch a possible invalid cast.
    object frank1 = new Manager();
    Hexagon hex;
    try
    {
        hex = (Hexagon)frank1;
    }
    catch (InvalidCastException ex)
    {
        Console.WriteLine(ex.Message);
    }

    // Use "as" to test compatibility.
    object[] things = new object[4];
    things[0] = new Hexagon();
    things[1] = false;
    things[2] = new Manager();
    things[3] = "Last thing";
    foreach (object item in things)
    {
        Hexagon h = item as Hexagon;
        if (h == null)
        {
            Console.WriteLine("Item is not a hexagon");
        }
        else
        {
            h.Draw();
        }
    }
    GivePromotionPatternMatching((Manager)frank);
    GivePromotionPatternMatching(moonUnit);
    GivePromotionPatternMatching(jill);
}
static void GivePromotion(Employee emp)
{
    Console.WriteLine("{0} was promoted!", emp.Name);
    if (emp is SalesPerson)
    {
        Console.WriteLine("{0} made {1} sale(s)!", emp.Name, ((SalesPerson)emp).SalesNumber);
        Console.WriteLine();
    }
    else if (emp is Manager)
    {
        Console.WriteLine("{0} had {1} stock options...", emp.Name, ((Manager)emp).StockOptions);
        Console.WriteLine();
    }
   
    if (emp is not Manager and not SalesPerson)
    {
        Console.WriteLine("Unable to promote {0}. Wrong employee type", emp.Name);
        Console.WriteLine();
    }

    if (emp is SalesPerson s)
    {
        Console.WriteLine("{0} made {1} sale(s)!", s.Name, s.SalesNumber);
        Console.WriteLine();
    }
    //Check if is Manager, if it is, assign to variable m
    else if (emp is Manager m)
    {
        Console.WriteLine("{0} had {1} stock options...", m.Name, m.StockOptions);
        Console.WriteLine();
    }
    else if (emp is var _)
    {
        Console.WriteLine("Unable to promote {0}. Wrong employee type", emp.Name);
        Console.WriteLine();
    }
}

static void GivePromotionPatternMatching(Employee emp)
{
    Console.WriteLine("{0} was promoted!", emp.Name);
    switch (emp)
    {
        case SalesPerson s when s.SalesNumber > 5:
            Console.WriteLine("{0} made {1} sale(s)!", emp.Name,
            s.SalesNumber);
            break;
        case Manager m:
            Console.WriteLine("{0} had {1} stock options...",
            emp.Name, m.StockOptions);
            break;
        case Employee _:
            Console.WriteLine("Unable to promote {0}. Wrong employee type", emp.Name);
            break;
    }
    Console.WriteLine();
}
