using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

Console.WriteLine(" Fun With Async ===>");
//Console.WriteLine(DoWork());
DoDik();
Console.WriteLine("Completed");
Console.ReadLine();
/*string message1 = await DoWorkAsync().ConfigureAwait(false);
Console.WriteLine(message1);
MethodReturningVoidAsync();
Console.WriteLine("Void method complete1");
await MethodReturningTaskOfVoidAsync();
Console.WriteLine("Void method complete2");
await MultipleAwaits();
await MultipleAwaitsWhenAll();*/

static async void DoDik()
{
    string message = await DoWorkAsync();
    Console.WriteLine(message);
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
        //Task.Delay(5000);
        Thread.Sleep(5_000);
        return "Done with work!";
    });
}

static async Task MethodReturningTaskOfVoidAsync()
{
    await Task.Run(() => { /* Do some work here... */
        Thread.Sleep(4_000);
    });
    Console.WriteLine("Void method completed");
}

static async void MethodReturningVoidAsync()
{
    await Task.Run(() => { /* Do some work here... */
        Thread.Sleep(4_000);
    });
    Console.WriteLine("Fire and forget void method completed");
}

static async Task MultipleAwaits()
{
    await Task.Run(() => { Thread.Sleep(2_000); });
    Console.WriteLine("Done with first task!");
    await Task.Run(() => { Thread.Sleep(2_000); });
    Console.WriteLine("Done with second task!");
    await Task.Run(() => { Thread.Sleep(2_000); });
    Console.WriteLine("Done with third task!");
}

static async Task MultipleAwaitsWhenAll()
{
    var task1 = Task.Run(() =>
    {
        Thread.Sleep(2_000);
        Console.WriteLine("Done with first task!");
    });
    var task2 = Task.Run(() =>
    {
        Thread.Sleep(1_000);
        Console.WriteLine("Done with second task!");
    }); 
    var task3 = Task.Run(() =>
    {
        Thread.Sleep(1_000);
        Console.WriteLine("Done with third task!");
    });
    await Task.WhenAll(task1, task2, task3);
}

static async Task MethodWithProblems(int firstParam, int secondParam)
{
    Console.WriteLine("Enter");
    if (secondParam < 0)
    {
        Console.WriteLine("Bad data");
        return;
    }
    await actualImplementation();
    async Task actualImplementation()
    {
        await Task.Run(() =>
        {
            //Call long running method
            Thread.Sleep(4_000);
            Console.WriteLine("First Complete");
            //Call another long running method that fails because
            //the second parameter is out of range
            Console.WriteLine("Something bad happened");
        });
    }
}
