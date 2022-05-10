using System;
using GenericEventHandler;

MainClass mainClass = new MainClass("IntialName",0);
Console.WriteLine($"Main class state: {mainClass.Name}, {mainClass.Counter}");
mainClass.NameChangedEvent += NameChangedEventHandler;
mainClass.NameChangedDelegateEvent += NameChangedEvenHandlerDelegate;



void NameChangedEvenHandlerDelegate(object sender,string msg, int counter)
{
    if (sender is MainClass mc)
    {
        mc.Counter = counter;
    }
    Console.WriteLine($"EventHandlerDelegate: {sender.GetType()}, {msg}");
}

mainClass.ChangeName("SecondName",50);
Console.WriteLine($"Main class state: {mainClass.Name}, {mainClass.Counter}");

MainClass mainClassInt = new MainClass("InitialName", 0);
mainClassInt.NameChangedIntEvent += NameChangedIntEventHandler;
mainClassInt.NameChangedIntEvent += NameChangedIntEventHandler1;
mainClassInt.NameChangedIntEvent += NameChangedIntEventHandler2;
Console.WriteLine($"Main class state: {mainClassInt.Name}, {mainClassInt.Counter}");
Console.WriteLine($"ChangeNameWithInt: {mainClassInt.ChangeNameWithInt("newName")}");
foreach (int item in mainClassInt.ListCounter)
{
    Console.WriteLine($"Main class state: {mainClassInt.Name}, {item}");
}


int NameChangedIntEventHandler(object sender, string msg)
{
    Console.WriteLine($"Int EventHandler: {sender.GetType()}, {msg}");
    return 50;
}
int NameChangedIntEventHandler1(object sender, string msg)
{
    Console.WriteLine($"Int EventHandler: {sender.GetType()}, {msg}");
    return 60;
}
int NameChangedIntEventHandler2(object sender, string msg)
{
    Console.WriteLine($"Int EventHandler: {sender.GetType()}, {msg}");
    return 70;
}

static void NameChangedEventHandler(object sender, MainClassEventArgs e)
{
    if(sender is MainClass mc)
    {
        mc.Counter = e.newCounter;
    }
    Console.WriteLine($"EventHandler: {sender.GetType()}, {e.msg}");
}