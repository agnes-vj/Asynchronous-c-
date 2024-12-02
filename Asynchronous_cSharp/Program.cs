using System.Diagnostics;

namespace Asynchronous_cSharp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
             //await mainTasks();
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            //try
            //{
                tokenSource.CancelAfter(1000);
                await Task.WhenAll([sayHelloWorld(token)]);
            //}
            //catch
            //{
            //    Console.WriteLine("operation timed out");
            //}
           
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
        static async Task sayHelloWorld(CancellationToken token)
        {
         
            Random random = new Random();
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            var sayHello = Task.Run(async () =>
            {
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();
                await Task.Delay(random.Next(1, 10001));
                Console.WriteLine("Hello ");
            },token);
            var sayWorld = Task.Run(async () =>
            {
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();
                await Task.Delay(random.Next(1,10001));
                Console.WriteLine("World");
            },token);

            try
            {
                await Task.WhenAll([sayHello, sayWorld]);
                token.ThrowIfCancellationRequested();
            }
            catch
            {
                Console.WriteLine("timed out");
                stopwatch.Stop();
            }

            
            Console.WriteLine("Time taken : "+ stopwatch.ElapsedMilliseconds);

        }
    }
}


