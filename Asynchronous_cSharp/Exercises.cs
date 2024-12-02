using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous_cSharp
{
    internal class Exercises
    {
        public async static Task findFactorialOfNumbers()
        {
            string data = "5 6 7 1";
            List<BigInteger> intList = data.Split(' ').Select(str => BigInteger.Parse(str)).ToList();
            List<Task<BigInteger>> tasks = new List<Task<BigInteger>>();
            foreach (BigInteger integer in intList)
            {
                tasks.Add(Task.Run(() =>  CalculateFactorial(integer)));
            }
            await Task.WhenAll(tasks).ContinueWith(completedTasks =>
            {
                foreach (BigInteger integer in completedTasks.Result)
                {
                    Console.WriteLine(integer);
                }
            }); 
        }

        public async static Task printWord(string sentence)
        {
            sentence.Split(' ').ToList().ForEach(async word =>
            {
                await Task.Delay(1000);
                Console.WriteLine(word);
            });
             
        }
        
        public static BigInteger CalculateFactorial(BigInteger num)
        {
            BigInteger result = BigInteger.One;
            for (BigInteger i = BigInteger.One; i.CompareTo(num) <= 0; i = BigInteger.Add(i, BigInteger.One))
            {
                result = BigInteger.Multiply(result, i);
            }
            return result;
        }


    }
}
