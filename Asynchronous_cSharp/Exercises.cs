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
            string data = "56 6 7089 9103";
            List<BigInteger> intList = data.Split(' ').Select(str => BigInteger.Parse(str)).ToList();
            List<Task> tasks = new List<Task>();
            List<BigInteger> resultList = new();
            foreach (BigInteger integer in intList)
            {
               // tasks.Add(Task.Run(() =>  CalculateFactorial(integer)));
                //resultList.Add(Task.Run(() => CalculateFactorial(integer)));
            }
            string story = "Mary had a little lamb, its fleece was white as snow.";
            List<string> words = story.Split(' ').ToList();
            List<Task> tasksPrintWords = new List<Task>();
            
            foreach (string word in words)
            {
                await Task.Run(() => PrintWord(word));
                //tasksPrintWords.Add(Task.Run(() => PrintWord(word)));
            }
            //await Task.WhenAll(tasksPrintWords);
        }

        public  async static Task PrintWord(string word)
        {
           Console.WriteLine(word);
         Task.Delay(1000);
          Console.WriteLine(new string('-',word.Length));
           

        }

        public static BigInteger CalculateFactorial(BigInteger num)
        {
            BigInteger result = BigInteger.One;
            for (BigInteger i = BigInteger.One; i.CompareTo(num) <= 0; i = BigInteger.Add(i, BigInteger.One))
            {
                result = BigInteger.Multiply(result, i);
            }
            //Console.WriteLine($"Factorial of {num} is {result}");
            return result;
        }


    }
}
