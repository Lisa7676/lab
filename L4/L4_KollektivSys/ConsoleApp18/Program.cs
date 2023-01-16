using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_viborov
{
    
    class Program //Выбор породы собаки для семьи
    {
        static void Main(string[] args) //Вызов классов для голосования
        {
            OtnositeloeBolshinstvo V1 = new OtnositeloeBolshinstvo();
            Koplend V2 = new Koplend();
            Bord V3 = new Bord();
            Kollektiv V4 = new Kollektiv();

            Console.WriteLine("Выберите способ голосования");
            Console.WriteLine("1. Относительное большинство");
            Console.WriteLine("2. Модель Кондорсе по правилу Копленда");
            Console.WriteLine("3. Модель Борда");
            Console.WriteLine("4. Коллективный выбор с коэффициентами");
            int number = Convert.ToInt32(Console.ReadLine());

            switch (number)
            {
                case 1:
                    V1.Golosovanie(); //Относительное большинство
                    break;
                case 2:
                    V2.Golosovanie(); //Моддель Кондорсе( правило Копленда)
                    break;
                case 3:
                    V3.Golosovanie(); //Модель Борда
                    break;
                case 4:
                    V4.Table(); //Линейная многокритериальная модель
                    break;
            }

            Console.ReadKey();
            
        }
    }
        
        
    
}
