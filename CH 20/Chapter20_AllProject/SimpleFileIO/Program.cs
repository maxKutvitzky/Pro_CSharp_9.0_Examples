using System;
using System.IO;

Console.WriteLine("***** Simple IO with the File Type *****\n");
//Change to a folder on your machine that you have read/write access to, or run as administrator
var fileName = $@"D:\UNIVER\#\Pro C# 9.0\CH 20\Chapter20_AllProject\SimpleFileIO\Test.dat";
// Make a new file on the C drive.
FileInfo f = new FileInfo(fileName);
FileStream fs = f.Create();
// Use the FileStream object...
// Close down file stream.
fs.Close();
// Make a new file via FileInfo.Open().
var fileName1 = $@"D:\UNIVER\#\Pro C# 9.0\CH 20\Chapter20_AllProject\SimpleFileIO\Test.dat";
FileInfo f2 = new FileInfo(fileName1);
using (FileStream fs2 = f2.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
{
    // Use the FileStream object...
}
f2.Delete();

