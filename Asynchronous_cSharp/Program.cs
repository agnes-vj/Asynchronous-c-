namespace Asynchronous_cSharp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
           
               await mainTasks();

        }
            static async Task mainTasks()
            {
                await Task.Delay(2000);
                Console.WriteLine("Hello, World!");
                await Task.Delay(2000);
                Console.WriteLine("Hello, World!");
          
            }

                //await Task.WhenAll([printToConsole,printToConsole2]);
    }
}


