using System;
using System.Threading;
using AddWithThreads;


Console.WriteLine("***** Adding with Thread objects *****");
Console.WriteLine("ID of thread in Main(): {0}", Thread.CurrentThread.ManagedThreadId);
AutoResetEvent _waitHandle = new AutoResetEvent(false);

// Make an AddParams object to pass to the secondary thread.
AddParams ap = new AddParams(10, 10);
Thread t = new Thread(new ParameterizedThreadStart(Add));
t.Start(ap);
// Wait here until you are notified!
_waitHandle.WaitOne();
Console.WriteLine("Other thread is done!");

Console.ReadLine();

void Add(object data)
{
    if (data is AddParams ap)
    {
        Console.WriteLine("ID of thread in Add(): {0}", Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine("{0} + {1} is {2}", ap.a, ap.b, ap.a + ap.b);
        // Tell other thread we are done.
        _waitHandle.Set();
    }
}