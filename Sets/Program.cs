using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sets
{
    class Program
    {
        /// <summary>
        /// Given a finite set of unique numbers, find all the runs in the set. Runs are 1 or more consecutive numbers.
        // That is, given {1,59,12,43,4,58,5,13,46,3,6}, the output should be: {1}, {3,4,5,6}, {12,13}, {43}, {46},{58,59}.
        // Note that the size of the set may be very large.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var input = new long[] { 1, 59, 12, 43, 4, 5, 13, 57,46, 3, 6, 58 };

            Array.Sort(input);

            foreach (DictionaryEntry entry in BuildRuns(input))
            {
                Console.WriteLine(string.Join(",", ((List<long>)entry.Value).Select(x => x)));
            }
            Console.ReadLine();
        }
        /// <summary>
        /// let's start first with the array.sort that has the worst case complexity O(n ^ 2) operation and on average O(n log n).
        /// The good thing about array.sort is that it uses different sort algorithms based on the size, more info here:https://msdn.microsoft.com/en-us/library/b0zbh7b6(v=vs.110).aspx
        /// If bootleneck happened one should look for algos like Radix sort, as its worse time complexity is O(nk).
        /// for the rest of the operation it will be O(n log n). The hastable is used since it offers
        /// better performance on lookup operations.
        /// </summary>
        /// <param name="hashTable"></param>
        /// <param name="setItem"></param>
        /// <returns></returns>
        private static Hashtable BuildRuns(long[] input)
        {
            Hashtable hashTable = new Hashtable();
            for (int i = 0; i < input.Length; i++)
            {
                //If the run doesn't exist or current element is not a squence create run, otherwise append.
                if (!hashTable.ContainsKey(input[i] - 1) || (input[i - 1] + 1 != input[i]))
                    CreatNewRun(hashTable, input[i]);
                else
                    UpdateExistingRun(hashTable, input[i - 1], input[i]);
            }
            return hashTable;
        }
        private static void CreatNewRun(Hashtable hashTable, long value)
        {
            List<long> run = new List<long>();
            run.Add(value);
            hashTable[value] = run;
        }
        private static void UpdateExistingRun(Hashtable hashTable,long key, long value)
        {
            List<long> run = (List<long>)hashTable[key];
            run.Add(value);
            hashTable.Remove(key);
            hashTable[value] = run;
        }
    }
}
