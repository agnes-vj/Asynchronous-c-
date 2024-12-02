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

            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            Random random = new Random();
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            var sayHello = Task.Run(async () =>
            {
                if (token.IsCancellationRequested)
                    throw new Exception();
                await Task.Delay(2000,token);
                Console.WriteLine("Hello ");
            },token);
            var sayWorld = Task.Run(async () =>
            {
                if (token.IsCancellationRequested)
                    throw new Exception();
                await Task.Delay(2000,token);
                Console.WriteLine("World");
            },token);

            try
            {
                tokenSource.CancelAfter(100);
                await Task.WhenAll([sayHello, sayWorld]);
            }
            catch
            {
                Console.WriteLine("timed out");
                stopwatch.Stop();
                Console.WriteLine("Time taken : "+ stopwatch.ElapsedMilliseconds);
            }

            

        }
    }
}


