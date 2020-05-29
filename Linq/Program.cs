using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var minWeight = 40;
            var maxWeight = 150;
            var minHeight = 1.5;
            var maxHeight = 2.5;

            List<Person> People = new List<Person>
            {
                new Person() { Weight = RandomInt(minWeight, maxWeight), Height = RandomDouble(minHeight, maxHeight), State = "RS"},
                new Person() { Weight = RandomInt(minWeight, maxWeight), Height = RandomDouble(minHeight, maxHeight), State = "SP"},
                new Person() { Weight = RandomInt(minWeight, maxWeight), Height = RandomDouble(minHeight, maxHeight), State = "RJ"},
                new Person() { Weight = RandomInt(minWeight, maxWeight), Height = RandomDouble(minHeight, maxHeight), State = "RJ"},
                new Person() { Weight = RandomInt(minWeight, maxWeight), Height = RandomDouble(minHeight, maxHeight), State = "ES"},
                new Person() { Weight = RandomInt(minWeight, maxWeight), Height = RandomDouble(minHeight, maxHeight), State = "AM"},
                new Person() { Weight = RandomInt(minWeight, maxWeight), Height = RandomDouble(minHeight, maxHeight), State = "MT"},
                new Person() { Weight = RandomInt(minWeight, maxWeight), Height = RandomDouble(minHeight, maxHeight), State = "PR"},
                new Person() { Weight = RandomInt(minWeight, maxWeight), Height = RandomDouble(minHeight, maxHeight), State = "SC"},
                new Person() { Weight = RandomInt(minWeight, maxWeight), Height = RandomDouble(minHeight, maxHeight), State = "DF"},
                new Person() { Weight = RandomInt(minWeight, maxWeight), Height = RandomDouble(minHeight, maxHeight), State = "RJ"},
            };

            var Result = (from x in People
                          where x.Classification() == BMIIndex.HighRisk || x.Classification() == BMIIndex.Heavy || x.Classification() == BMIIndex.Overweight
                          orderby x.Classification(), x.Height 
                          group x by x.State into g
                          select g
                          );

            foreach (var state in Result)
            {
                Console.WriteLine($"--------------------------------------");
                Console.WriteLine($"CLASSIFICATION BY STATE {state.Key}");
                Console.WriteLine($"--------------------------------------");
                foreach (var person in state.ToList()) 
                {
                   Console.WriteLine($"Weight: {person.Weight} | Height: {person.Height} | State: {person.State}"); 
                }  
            }

            //foreach (var person in People)
            //{
            //    Console.WriteLine($"Weight {person.Weight} | Height = {person.Height} | State: {person.Classification()}");
            //}

            //int[] scores = new int[] { 97, 92, 81, 60, 78, 54, 36, 52, 47, 98, 25, 36 };

            //IEnumerable<int> result = (
            //    from x in scores
            //    where x > 50 && x <= 80
            //    orderby x descending
            //    select x
            //);

            //double avg = result.Average();
            //double sum = result.Sum();

            //foreach (var item in result)
            //{
            //    Console.WriteLine($"The selected score is {item}");
            //}
            //Console.WriteLine($"Average = {avg} and Sum = {sum}");
        }

        private static readonly Random random = new Random();
        private static double RandomDouble(double minValue, double maxValue)
        {
            var next = random.NextDouble();
            return Math.Round(minValue + (next * (maxValue - minValue)), 2);
        }

        public static int RandomInt(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
