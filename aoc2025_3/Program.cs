using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2025_3 {
    internal class Program {
        static void Main(string[] args) {
            long heslo = 0;
            StreamReader vstup = new StreamReader("C:\\aoc2025\\input2.txt");
            string ret = vstup.ReadLine();
            vstup.Close();
            Console.WriteLine(ret); Console.WriteLine();
            //rozklad stringu na prvky v poli
            string[] retPole = ret.Split(',');
            foreach (var str in retPole) {
                string[] minMax = str.Split('-');
                Console.WriteLine($"min {minMax[0]}, max {minMax[1]}");
                long invalid = hledejInvalidId(minMax);
                Console.WriteLine(invalid);
                heslo += invalid;
            }
            Console.WriteLine($"Heslo je {heslo}");
        }
        static long hledejInvalidId(string[] str) {
            long soucetInvaliduVrozsahu = 0;
            long min = Convert.ToInt64(str[0]);
            long max = Convert.ToInt64(str[1]);
            for (long i = min; i <= max; i++) {
                string temp = Convert.ToString(i);
                int delka = temp.Length;
                if (delka % 2 != 0) continue;
                string temp1 = temp.Substring(0, delka/2);
                string temp2 = temp.Substring(delka/2);
                if (temp1 == temp2) soucetInvaliduVrozsahu += Convert.ToInt64(temp);
            }
            return soucetInvaliduVrozsahu;
        }
    }
}
