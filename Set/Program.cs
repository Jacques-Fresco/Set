using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Model.EasySet<int> one = new Model.EasySet<int>(1);
            one.Add(2);
            one.Add(3);
            one.Add(4);
            one.Add(5);

            Model.EasySet<int> two = new Model.EasySet<int>(4);
            two.Add(5);
            two.Add(6);
            two.Add(7);
            two.Add(8);

            Model.EasySet<int> three = one.Union(two);

            foreach(int item in three)
            {
                Console.WriteLine(item);
            }*/

            Model.EasySet<int> easyset1 = new Model.EasySet<int>(new int[] { 1, 2, 3, 4, 5 });
            Model.EasySet<int> easyset2 = new Model.EasySet<int>(new int[] { 4, 5, 6, 7, 8 });
            Model.EasySet<int> easyset3 = new Model.EasySet<int>(new int[] { 3, 4, 5 });

            Console.WriteLine("Union: ");
            foreach(Object item in easyset1.Union(easyset2))
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nIntersection: ");
            foreach (Object item in easyset1.Intersection(easyset2))
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nDifference A \\ B: ");
            foreach (Object item in easyset1.Difference(easyset2))
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nDifference B \\ A: ");
            foreach (Object item in easyset2.Difference(easyset1))
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nA Subset C: ");
            Console.Write(easyset1.Subset(easyset3));
            Console.WriteLine();
            
            Console.WriteLine("\nC Subset A: ");
            Console.Write(easyset3.Subset(easyset1));
            Console.WriteLine();

            Console.WriteLine("\nC Subset B: ");
            Console.Write(easyset3.Subset(easyset2));
            Console.WriteLine();

            Console.WriteLine("\nSymmetricDifference: ");
            foreach (Object item in easyset1.SymmetricDifference(easyset2))
            {
                Console.Write(item + " ");
            }

            Console.ReadLine();
        }
    }
}
