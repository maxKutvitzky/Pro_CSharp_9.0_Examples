using System;
using System.IO;
using System.Text;
// Don't forget to import the System.Text and System.IO namespaces.
Console.WriteLine("***** Fun with FileStreams *****\n");
string path = @"D:\UNIVER\#\Pro C# 9.0\CH 20\Chapter20_AllProject\FileStreamApp\myMessage.dat";
// Obtain a FileStream object.
using (FileStream fStream = File.Open(path, FileMode.Create))
{
    // Encode a string as an array of bytes.
    string msg = "Hello!";
    byte[] msgAsByteArray = Encoding.Default.GetBytes(msg);
    // Write byte[] to file.
    fStream.Write(msgAsByteArray, 0, msgAsByteArray.Length);
    // Reset internal position of stream.
    fStream.Position = 0;
    // Read the types from file and display to console.
    Console.Write("Your message as an array of bytes: ");
    byte[] bytesFromFile = new byte[msgAsByteArray.Length];
    for (int i = 0; i < msgAsByteArray.Length; i++)
    {
        bytesFromFile[i] = (byte)fStream.ReadByte();
        Console.Write(bytesFromFile[i]);
    }
    // Display decoded messages.
    Console.Write("\nDecoded Message: ");
    Console.WriteLine(Encoding.Default.GetString(bytesFromFile));
    Console.ReadLine();
}
File.Delete(path);
