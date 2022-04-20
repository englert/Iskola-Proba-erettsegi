using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Iskola
{
    class C {
       
        public int date,nh;
        public string ch, nev;
        public C(string sor)
        {
            var s = sor.Split(';');
            date = int.Parse(s[0]);
            ch =s[1];
            nev =s[2];
            for (int i = 0; i < nev.Length; i++)
            {
                if (nev[i]==' ')
                {

                }
                else
                {
                    nh++;
                }
            }
           
        }
    }
    class Program
    {
       static string azonosto(string nev,string ch, int date)
        {

            var szo = nev.Split(' ');
            string azonosit = date.ToString().Substring(3, 1) + ch + szo[0].Substring(0, 3) + szo[1].Substring(0, 3);
            return azonosit;
        }
        static void Main(string[] args)
        {
            var sr = new StreamReader("nevek.txt");
            var lista = new List<C>();
            while (!sr.EndOfStream)
            {
                lista.Add(new C(sr.ReadLine()));
            }
            Console.WriteLine($"3. feladat: Az iskolába {lista.Count()} tanuló jár.");
            var max = (from sor in lista orderby sor.nh select sor).Last();
            Console.WriteLine($"4. feladat: A leghosszabb ({max.nh} karakter) nevű tanuló(k):");
            Console.WriteLine($"\t{max.nev}");
            var sad = (from sor in lista  select sor);
            Console.WriteLine(azonosto(sad.First().nev, sad.First().ch, sad.First().date));
            Console.WriteLine(azonosto(sad.Last().nev, sad.Last().ch, sad.Last().date));
            Console.WriteLine("6. feladat?be azonosito");
            var ez = Console.ReadLine().ToString().ToLower();
            var vane = (from sor in lista where ez == azonosto(sor.nev, sor.ch, sor.date).ToLower() select sor);
            if (vane.Any())
            {
                Console.WriteLine($"\t{vane.First().date} {vane.First().ch} {vane.First().nev}");
            }
            else
            {
                Console.WriteLine("nincs");
            }
            Console.ReadKey();
        }
    }
}
