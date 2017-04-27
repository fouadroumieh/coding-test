using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlattenArrays
{
    class Program
    {
        /// <summary>
        /// Write a program that will take a nested array and flatten it
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var nestedArray = new[] { new object[] { 1, 2, new[] { 3, 4 }, 5, 6 } };

            var flattenedArray = nestedArray.Flatten();

            foreach (var item in flattenedArray)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();

            /*
            Expected output: 
            1
            2
            3
            4
            5
            6
            */
        }
    }
    public static class EnumberableExtensions
    {
        /// <summary>
        /// Since arrays in .net implement IEnumerable I've used it instead, as its iteration operation mainly.
        /// The function iterates recursively whenever it finds an element of type array util the 
        /// last level is reached.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns>IEnuerable object</returns>
        public static IEnumerable Flatten(this IEnumerable enumerable)
        {
            foreach (var itm in enumerable)
                if (itm is Array)
                    foreach (var nestedItem in Flatten((IEnumerable)itm))
                        yield return nestedItem;
                else
                    yield return itm;
        }
    }
}
