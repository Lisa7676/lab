using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_viborov
{
    internal class Bord
    {
        public double golosa, kandidati = 3;
        public long[] Varianti = { 123, 132, 213, 231, 312, 321 };//Комбинации возможные при голосовании

        public double Huski, Shiba, Samoed, result, komb;//Количество голосов у кандидатов, результат, номер комбинации
        public void Golosovanie()
        {

            Console.WriteLine("Укажите количество голосующих:");
            golosa = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < golosa; i++)
            {
                Console.WriteLine("Расставьте в порядке убывания:");
                Console.WriteLine("1. Хаски");
                Console.WriteLine("2. Шиба");
                Console.WriteLine("3. Самоед");
                Console.WriteLine("Пример: 123 (Если Хаски лучше, чем Шиба, а Шиба лучше, чем Самоед");
                long vibor = Convert.ToInt64(Console.ReadLine());
                for (int j = 0; j < Varianti.Length; j++)
                {
                    if (Varianti[j] == vibor) { komb = j;}
                }
                switch (komb) // Считаем количество набранных очков по комбинацим
                {
                    case 0:
                        Huski++;
                        Samoed-- ;
                        break;
                    case 1:
                        Huski++;
                        Shiba--;
                        break;
                    case 2:
                        Shiba++;
                        Samoed--;
                        break;
                    case 3:
                        Shiba++;
                        Huski--;
                        break;
                    case 4:
                        Samoed++;
                        Shiba--;
                        break;
                    case 5:
                        Samoed++;
                        Huski--;
                        break;
                    default:
                        Console.WriteLine("Ошибка");
                        break;
                }
            }
            Console.WriteLine();

            double[] schet = { Huski, Shiba, Samoed };// Все результаты
            double max = schet[0], povtor = 0, sr = schet[0]; //Переменные для сравнения
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
