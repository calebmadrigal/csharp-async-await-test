using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main start");
            Task<string> t = GetData();
            Console.WriteLine("Main after call");
            t.Wait();
            string result = t.Result;
            Console.WriteLine("Main end; result: " + result);
            Console.ReadLine();
        }

        static async Task<string> GetData()
        {
            Console.WriteLine("\tBefore long operation");

            await Task.Run(() =>
            {
                Console.WriteLine("\t\tTask before");
                Thread.Sleep(3000);
                Console.WriteLine("\t\tTask after");
            });

            Console.WriteLine("\tAfter long operation");

            return "Hello world";
        }
    }
}
