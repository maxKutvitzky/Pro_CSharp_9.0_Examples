using System;


        
// Display a simple message to the user.
Console.WriteLine("***** My First C# App *****");
Console.WriteLine("Hello World!");
Console.WriteLine();
// Process any incoming args.
Console.WriteLine("\nProcess any incoming args\n");
for (int i = 0; i < args.Length; i++)
{
    Console.WriteLine("Arg: {0}", args[i]);
}
// Get arguments using System.Environment.
Console.WriteLine("\nGet arguments using System.Environment.\n");
string[] theArgs = Environment.GetCommandLineArgs();
foreach (string arg in theArgs)
{
    Console.WriteLine("Arg: {0}", arg);
}
// Local method within the Top-level statements.
Console.WriteLine("\nShowEnvironmentDetails\n");
ShowEnvironmentDetails();
// Wait for Enter key to be pressed before shutting down.
Console.ReadLine();
return 0;

static void ShowEnvironmentDetails()
{
    // Print out the drives on this machine,
    // and other interesting details.
    foreach (string drive in Environment.GetLogicalDrives())
    {
        Console.WriteLine("Drive: {0}", drive);
    }
    Console.WriteLine("OS: {0}", Environment.OSVersion);
    Console.WriteLine("Number of processors: {0}", Environment.ProcessorCount);
    Console.WriteLine(".NET Core Version: {0}", Environment.Version);
}



