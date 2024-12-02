namespace Asynchronous_cSharp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {           
              // await mainTasks();
            await sayHelloWorld();

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
            var sayHello = Task.Run(async () =>
            {              
                //await Task.Delay(3000);
                Console.WriteLine("Hello ");
            });
            var sayWorld = Task.Run(async () =>
            {
                await Task.Delay(3000);
                Console.WriteLine("Word");
            });

            await Task.WhenAll([sayHello, sayWorld]);

        }
    }
}


