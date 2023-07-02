using System;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTests
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var child = new Child("123");

            //var lockObj = new object();
            //lock (lockObj)
            //{
            //    Task.Run(() =>
            //    {
            //        lock (lockObj)
            //        {
            //            Console.WriteLine("internal lock");
            //        }

            //    }).Wait();
            //}


            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            await (new CustomTask());
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            var a = Test().Result;
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }

        static async Task<int> Test()
        {
            await Task.Yield();
            await Task.Delay(1000).ConfigureAwait(false);
            //GetDeadlock().Wait();
            return 1;
        }

        static async Task GetDeadlock()
        {
            await Task.Yield();
            var z = Test().Result;
        }
    }

    class CustomTask : INotifyCompletion
    {
        public void OnCompleted(Action continuation)
        {
            Task.Run(continuation);
        }

        public bool IsCompleted => false;
        public CustomTask GetAwaiter() => this;

        public void GetResult()
        {
            Console.WriteLine("get result");
        }
    }

    abstract class Parent
    {
        public bool Active { get; set; } = true;
    }

    class Child : Parent
    {
        public string Data  { get; set; }

        public Child(string data)
        {
            Data = data;
        }

        private Child()
        {
            
        }
    }
}
