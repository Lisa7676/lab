using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_viborov
{
    class OtnositeloeBolshinstvo
    {
        public double golosa, kandidati = 3;


        public int Huski, Shiba, Samoed, result;
        public void Golosovanie()
        {

            Console.WriteLine("Укажите количество голосующих:");
            golosa = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < golosa; i++)
            {
                Console.WriteLine("Проголосуйте за одного из кандидатов:");
                Console.WriteLine("1. Хаски");
                Console.WriteLine("2. Шиба");
                Console.WriteLine("3. Самоед");
                int number = Convert.ToInt32(Console.ReadLine());

                switch (number)
                {
                    case 1:
                        Huski++;
                        break;
                    case 2:
                        Shiba++;
                        break;
                    case 3:
                        Samoed++;
                        break;
                    default:
                        Console.WriteLine("Ошибка");
                        break;
                }
            }
            Console.WriteLine();

            int[] schet = { Huski, Shiba, Samoed };// Все результаты
            int max = schet[0], povtor = 0, sr = schet[0];
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
