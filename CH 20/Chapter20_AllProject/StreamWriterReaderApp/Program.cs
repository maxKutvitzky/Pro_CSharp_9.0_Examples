using System;
using System.IO;
using System.Text;
Console.WriteLine("***** Fun with StreamWriter / StreamReader *****\n");
string path = @"D:\UNIVER\#\Pro C# 9.0\CH 20\Chapter20_AllProject\StreamWriterReaderApp\reminders.txt";
// Get a StreamWriter and write string data.
using (StreamWriter writer = File.CreateText(path))
{
    writer.WriteLine("Don't forget Mother's Day this year...");
    writer.WriteLine("Don't forget Father's Day this year...");
    writer.WriteLine("Don't forget these numbers:");
    for (int i = 0; i < 10; i++)
    {
        writer.Write(i + " ");
    }
    // Insert a new line.
    writer.Write(writer.NewLine);
}
Console.WriteLine("Created file and wrote some thoughts...");
Console.ReadLine();
// Now read data from file.
Console.WriteLine("Here are your thoughts:\n");
using (StreamReader sr = File.OpenText(path))
{
    string input = null;
    while ((input = sr.ReadLine()) != null)
    {
        Console.WriteLine(input);
    }
}
Console.ReadLine();
File.Delete("path");
