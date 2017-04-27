using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TopN
{
    class Program
    {
        /// <summary>
        /// Write a program, topN, that given an arbitrarily large file and a number, N, containing individual numbers on each line (e.g. 200Gb file), 
        /// will output the largest N numbers, highest first. Tell me about the run time/space complexity of it, and whether you think there's room for improvement in your approach.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var top = TopN("InputFile.txt", 5);
            foreach (var i in top.OrderByDescending(x => x))
                Console.WriteLine(i);

            Console.ReadKey();
        }

        private static IList<double> TopN(string fileName, int top)
        {
            SortedSet<double> result = new SortedSet<double>();
            using (FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                object line;
                while ((line = sr.ReadLine()) != null)
                {
                    double current = Convert.ToDouble(line);
                    if (result.Count() < top)
                        result.Add(current);
                    else
                    {
                        if (current > result.First())
                        {
                            result.Remove(result.First());
                            result.Add(current);
                        }
                    }
                }
            }
            return result.ToList();
        }
    }
}
