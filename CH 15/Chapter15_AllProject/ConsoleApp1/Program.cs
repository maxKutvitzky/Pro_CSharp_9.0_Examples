using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(" Fun With Async ===>");
            //Console.WriteLine(DoWork());
            string message = await DoWorkAsync();
            Console.WriteLine(message);
            Console.WriteLine("Completed");
        }
        static string DoWork()
        {
            Thread.Sleep(5_000);
            return "Done with work!";
        }
        static async Task<string> DoWorkAsync()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(5_000);
                return "Done with work!";
            });
        }
    }
}
