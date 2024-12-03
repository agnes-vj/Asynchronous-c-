using System.Diagnostics;

namespace Asynchronous_cSharp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {    
           //await Exercises.findFactorialOfNumbers();


             //await mainTasks();



            await sayHelloWorld();
            await Task.Delay(5000);


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
                await Task.Delay(4000);
                Console.WriteLine("Hello ");
            });
            var sayWorld = Task.Run(async () =>
            {
                await Task.Delay(1000);
                Console.WriteLine("World");
            });

            
               // await Task.WhenAll([sayHello, sayWorld]);
           
                stopwatch.Stop();
                Console.WriteLine("Time taken : " + stopwatch.ElapsedMilliseconds);
            
        }
            static async Task sayHelloWorldWithToken()
        {
            var tokenSource = new CancellationTokenSource(3000);
            var token = tokenSource.Token;
           
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            var sayHello = Task.Run(async () =>
            {                
                await Task.Delay(5000,token);
                Console.WriteLine("Hello ");
            },token);
            var sayWorld = Task.Run(async () =>
            {                
                await Task.Delay(1000,token);
                Console.WriteLine("World");
            },token);

            try
            {
                //tokenSource.CancelAfter(100);
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


