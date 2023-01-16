using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_viborov
{
    internal class Kollektiv
    {
        public double CoefFather = 0.3, CoefMother = 0.5, CoefChild = 0.2; //Коэффициенты выборщиков
        double CoefUhod = 0.15, CoefPrice = 0.2, CoefFood = 0.1, CoefCharacter = 0.15, CoefVneshniy = 0.4; //Коэффициенты характеристик

        //Таблица ответов папы
        public double[] FatherAnswer1 = { 2, 3, 1, 2, 1 };
        public double[] FatherAnswer2 = { 5, 2, 4, 3, 2 };
        public double[] FatherAnswer3 = { 4, 4, 2, 3, 3 };
        public double[] FatherAnswer4 = { 3, 2, 3, 4, 3 };
        public double[] FatherAnswer5 = { 5, 5, 3, 4, 5 };

        //Таблица ответов мамы
        public double[] MotherAnswer1 = { 1, 3, 1, 2, 1 };
        public double[] MotherAnswer2 = { 4, 1, 3, 2, 1 };
        public double[] MotherAnswer3 = { 3, 4, 1, 2, 2 };
        public double[] MotherAnswer4 = { 2, 3, 3, 4, 5 };
        public double[] MotherAnswer5 = { 5, 5, 3, 4, 5 };

        //Таблица ответов ребенка
        public double[] ChildAnswer1 = { 3, 5, 3, 3, 3 };
        public double[] ChildAnswer2 = { 5, 4, 4, 5, 4 };
        public double[] ChildAnswer3 = { 4, 5, 3, 4, 4 };
        public double[] ChildAnswer4 = { 5, 3, 3, 5, 5 };
        public double[] ChildAnswer5 = { 5, 5, 5, 5, 5 };

        //Таблицы для подсчета ответов с коэффициентами
        public double[,] TableFather = new double[5, 6];
        public double[,] TableMother = new double[5, 6];
        public double[,] TableChild = new double[5, 6];

        //Оценки по породам
        public double[] THuski = new double[3];
        public double[] TShiba = new double[3];
        public double[] TAkita = new double[3];
        public double[] TRetriver = new double[3];
        public double[] TSamoed = new double[3];


        public double Huski, Shiba, Akita, Retriver, Samoed, result;
        public void Table()
        {
            for (int i = 0; i < 5; i++)
            {
                TableFather[i, 0] = FatherAnswer1[i] * CoefUhod;
                TableFather[i, 1] = FatherAnswer2[i] * CoefPrice;
                TableFather[i, 2] = FatherAnswer3[i] * CoefFood;
                TableFather[i, 3] = FatherAnswer4[i] * CoefCharacter;
                TableFather[i, 4] = FatherAnswer5[i] * CoefVneshniy;

                TableMother[i, 0] = MotherAnswer1[i] * CoefUhod;
                TableMother[i, 1] = MotherAnswer2[i] * CoefPrice;
                TableMother[i, 2] = MotherAnswer3[i] * CoefFood;
                TableMother[i, 3] = MotherAnswer4[i] * CoefCharacter;
                TableMother[i, 4] = MotherAnswer5[i] * CoefVneshniy;

                TableChild[i, 0] = ChildAnswer1[i] * CoefUhod;
                TableChild[i, 1] = ChildAnswer2[i] * CoefPrice;
                TableChild[i, 2] = ChildAnswer3[i] * CoefFood;
                TableChild[i, 3] = ChildAnswer4[i] * CoefCharacter;
                TableChild[i, 4] = ChildAnswer5[i] * CoefVneshniy;

            }
            for (int i = 0; i < 5; i++)
            {
                THuski[0] = THuski[0] + TableFather[0, i];
                THuski[1] = THuski[1] + TableMother[0, i];
                THuski[2] = THuski[2] + TableChild[0, i];
                TableFather[0, 5] = THuski[0];
                TableMother[0, 5] = THuski[1];
                TableChild[0, 5] = THuski[2];

                TShiba[0] = TShiba[0] + TableFather[1, i];
                TShiba[1] = TShiba[1] + TableMother[1, i];
                TShiba[2] = TShiba[2] + TableChild[1, i];
                TableFather[1, 5] = TShiba[0];
                TableMother[1, 5] = TShiba[1];
                TableChild[1, 5] = TShiba[2];

                TAkita[0] = TAkita[0] + TableFather[2, i];
                TAkita[1] = TAkita[1] + TableMother[2, i];
                TAkita[2] = TAkita[2] + TableChild[2, i];
                TableFather[2, 5] = TAkita[0];
                TableMother[2, 5] = TAkita[1];
                TableChild[2, 5] = TAkita[2];

                TRetriver[0] = TRetriver[0] + TableFather[3, i];
                TRetriver[1] = TRetriver[1] + TableMother[3, i];
                TRetriver[2] = TRetriver[2] + TableChild[3, i];
                TableFather[3, 5] = TRetriver[0];
                TableMother[3, 5] = TRetriver[1];
                TableChild[3, 5] = TRetriver[2];

                TSamoed[0] = TSamoed[0] + TableFather[4, i];
                TSamoed[1] = TSamoed[1] + TableMother[4, i];
                TSamoed[2] = TSamoed[2] + TableChild[4, i];
                TableFather[4, 5] = TSamoed[0];
                TableMother[4, 5] = TSamoed[1];
                TableChild[4, 5] = TSamoed[2];
            }

            Huski = THuski[0] * CoefFather + THuski[1] * CoefMother + THuski[2] * CoefChild;
            Shiba = TShiba[0] * CoefFather + TShiba[1] * CoefMother + TShiba[2] * CoefChild;
            Akita = TAkita[0] * CoefFather + TAkita[1] * CoefMother + TAkita[2] * CoefChild;
            Retriver = TRetriver[0] * CoefFather + TRetriver[1] * CoefMother + TRetriver[2] * CoefChild;
            Samoed = TSamoed[0] * CoefFather + TSamoed[1] * CoefMother + TSamoed[2] * CoefChild;

            Console.WriteLine("Таблица папы");
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {

                    Console.Write("| " + TableFather[i, j] + "\t" + "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Таблица мамы");
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {

                    Console.Write("| " + TableMother[i, j] + "\t" + "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Таблица ребенка");
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {

                    Console.Write("| " + TableChild[i, j] + "\t" + "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            result = Math.Max(Huski, Math.Max(Shiba, Math.Max(Akita, Math.Max(Retriver, Samoed))));
            Console.WriteLine("Хаски = " + Huski + "\t" + "Шиба-ину = " + Shiba + "\t" + " Акита-ину = " + Akita + "\t" + " Золотистый ретривер = " + Retriver + "\t" + " Самоед = " + Samoed);

            Console.WriteLine();
            Console.Write("После анализа таблиц ответов семье предлагается взять собаку породы ");
            if (result == Huski)
            {
                Console.WriteLine(" Хаски.");
            }
            if (result == Shiba)
            {
                Console.WriteLine(" Шиба.");
            }
            if (result == Akita)
            {
                Console.WriteLine(" Акита.");
            }
            if (result == Retriver)
            {
                Console.WriteLine(" Золотистый ретривер.");
            }
            if (result == Samoed)
            {
                Console.WriteLine(" Самоед.");
            }
        }
    }
}
