using System;
using System.IO;

Console.WriteLine("***** Simple I/O with the File Type *****\n");
string path = @"D:\UNIVER\#\Pro C# 9.0\CH 20\Chapter20_AllProject\SimpleFileIOAdditional\tasks.txt";
string[] myTasks = {
 "Fix bathroom sink", "Call Dave",
 "Call Mom and Dad", "Play Xbox One"};
// Write out all data to file on C drive.
File.WriteAllLines(path, myTasks);
// Read it all back and print out.
foreach (string task in File.ReadAllLines(path))
{
    Console.WriteLine("TODO: {0}", task);
}
Console.ReadLine();
File.Delete(path);

