using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_viborov
{
    internal class Koplend //Модель Кондорсе по правилу Копленда
    {
        public double golosa, kandidati = 3;
        public long[] Varianti = { 123, 132, 213, 231, 312, 321 };//Комбинации возможные при голосовании

        public double Huski, Shiba, Samoed, result, komb;//Количество голосов у кандидатов, результат, номер комбинации
        public double HSh, ShH, HS, SH, ShS, SSh; //Очки по сравнениям
        public void Golosovanie()
        {

            Console.WriteLine("Укажите количество голосующих:");
            golosa = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < golosa; i++)
            {
                Console.WriteLine("Голосующий номер "+(i+1));
                Console.WriteLine("Кто лучше? Выберите число:");
                Console.WriteLine("1. Хаски");
                Console.WriteLine("2. Шиба");
                int vibor = Convert.ToInt32(Console.ReadLine());
                if(vibor == 1) { HSh++; }
                else if(vibor == 2) { ShH++; }
                Console.WriteLine("Кто лучше? Выберите число:");
                Console.WriteLine("1. Шиба");
                Console.WriteLine("2. Самоед");
                vibor = Convert.ToInt32(Console.ReadLine());
                if (vibor == 1) { ShS++; }
                else if (vibor == 2) { SSh++; }
                Console.WriteLine("Кто лучше? Выберите число:");
                Console.WriteLine("1. Хаски");
                Console.WriteLine("2. Самоед");
                vibor = Convert.ToInt32(Console.ReadLine());
                if (vibor == 1) { HS++; }
                else if (vibor == 2) { SH++; }
                Console.WriteLine(ShH);
            }

            Console.WriteLine();

            //Начисление результатов по набранным очкам
            if (HSh > ShH) { Huski++;Shiba--; }
            if (ShH > HSh) { Shiba++; Huski--; }
            if (ShS > SSh) { Shiba++; Samoed--; }
            if (SSh > ShS) { Samoed++; Shiba--; }
            if (HS > SH) { Huski++; Samoed--; }
            if (SH > HS) { Samoed++; Huski--; }

            Console.WriteLine(Huski);

            double[] schet = { Huski, Shiba, Samoed };// Все результаты
            double max = schet[0], povtor = 0, sr = schet[0];
            bool r = false;


            for (int i = 1; i < schet.Length; i++) { if (schet[i] > max) { max = schet[i]; } }

            for (int i = 1; i < schet.Length; i++) { if (schet[i] == sr) { r = true; povtor = i; } sr = schet[i]; }

            Console.WriteLine("Хаски = " + Huski + "\t" + "Шиба-ину = " + Shiba + "\t" + " Самоед = " + Samoed);

            Console.WriteLine();
            if (r == false)
            {
                Console.Write("После анализа ответов семье предлагается взять собаку породы ");
                if (max == Huski)
                {
                    Console.WriteLine(" Хаски.");
                }
                if (max == Shiba)
                {
                    Console.WriteLine(" Шиба.");
                }
                if (max == Samoed)
                {
                    Console.WriteLine(" Самоед.");
                }
            }
            else
            {
                if (povtor > 0) { Console.Write("После подсчета голосов несколько пород набрали максимальное количество, рекомендуется проголосвать заново."); }
            }
        }
    }
}
