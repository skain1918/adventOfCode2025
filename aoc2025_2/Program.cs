using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2025_2 {
    internal class Program {
        static void Main(string[] args) {
            int point = 50;
            int nul = 0;
            int pocetRadku = 0;
            StreamReader vstup = new StreamReader("C:\\aoc2025\\input1.txt");
            string ret;
            List<string> list = new List<string>();
            while (!vstup.EndOfStream) {
                ret = vstup.ReadLine();
                list.Add(ret);
                pocetRadku++;
                //Console.WriteLine(ret); Console.WriteLine();
            }
            Console.WriteLine(pocetRadku);
            vstup.Close();
            foreach (string dial in list) {
                string smer = dial.Substring(0, 1);
                //Console.WriteLine(smer);
                int kolik = Convert.ToInt32(dial.Substring(1));
                //Console.WriteLine(kolik);
                int[] vysledek = result(point, smer, kolik);
                point = vysledek[0];
                nul += vysledek[1];
            }
            Console.WriteLine($"Pocet nul: {nul}.");
        }
        public static int[] result(int point, string str, int dial) {
            int temp = point;
            int nul = 0;
            if (str == "R") {
                for (int i = 0; i < dial; i++) {
                    temp++;
                    if (temp == 100) temp = 0;
                    if(temp ==0)nul++;
                }
            }
            else {
                for (int i = 0; i < dial; i++) {
                    temp--;
                    if (temp == 0) nul++;
                    if (temp == -1) temp = 99;
                }
            }
            return new int[] { temp, nul };
            ;
        }
    }
}
