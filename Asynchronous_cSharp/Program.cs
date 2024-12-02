using System.Diagnostics;

namespace Asynchronous_cSharp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
             //await mainTasks();
             
             await sayHelloWorld();
            //Task t = sayHelloWorld();
            //t.Wait();
           // await t;
            //Task.Run(async () => await sayHelloWorld()).Wait(6000);

            //Task.Delay(3000);

        }
            static async Task mainTasks()
            {
                await Task.Delay(2000);
                Console.WriteLine("Hello, World!");
                await Task.Delay(2000);
                Console.WriteLine("Hello, World!");
          
            }
        static async Task sayHelloWorld()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            var sayHello = Task.Run(async () =>
            {              
                await Task.Delay(3000);
                Console.WriteLine("Hello ");
            });
            var sayWorld = Task.Run(async () =>
            {
                await Task.Delay(3000);
                Console.WriteLine("Word");
            });

            await Task.WhenAll([sayHello]);
            stopwatch.Stop();
            Console.WriteLine("Time taken : "+ stopwatch.ElapsedMilliseconds);

        }
    }
}


