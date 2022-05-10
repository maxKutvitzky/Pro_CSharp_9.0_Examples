using IssuesWithNonGenericCollections;
using System;
using System.Collections;
using System.Collections.Generic;

static void SimpleBoxUnboxOperation()
{
    // Make a ValueType (int) variable.
    int myInt = 25;
    // Box the int into an object reference.
    object boxedInt = myInt;
    // Unbox the reference back into a corresponding int.
    int unboxedInt = (int)boxedInt;
}
static void ArrayListOfRandomObjects()
{
    // The ArrayList can hold anything at all.
    ArrayList allMyObjects = new ArrayList();
    allMyObjects.Add(true);
    allMyObjects.Add(new OperatingSystem(PlatformID.MacOSX, new Version(10, 0)));
    allMyObjects.Add(66);
    allMyObjects.Add(3.14);
}
static void UseGenericList()
{
    Console.WriteLine("***** Fun with Generics *****\n");
    // This List<> can hold only Person objects.
    List<Person> morePeople = new List<Person>();
    morePeople.Add(new Person("Frank", "Black", 50));
    Console.WriteLine(morePeople[0]);
    // This List<> can hold only integers.
    List<int> moreInts = new List<int>();
    moreInts.Add(10);
    moreInts.Add(2);
    int sum = moreInts[0] + moreInts[1];
    // Compile-time error! Can't add Person object
    // to a list of ints!
    // moreInts.Add(new Person());
}