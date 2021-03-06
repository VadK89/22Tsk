using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22Tsk
{
    class Program
    {
        /*1.	Сформировать массив случайных целых чисел (размер  задается пользователем). 
         * Вычислить сумму чисел массива и максимальное число в массиве. 
         * Реализовать  решение  задачи  с  использованием  механизма  задач продолжения.
         */
        //Объявляем переменные
        static int r;
        static int g1;       
        static int g2;       
        static int[] array;
        static int sum=0;
        static int max=0;
        //Метод сумирования массива с помощью LINQ
        static void Array()
        {
            array = new int[r];
            Random random = new Random();
            for (int i = 0; i < r; i++)
            {
                array[i] = random.Next(g1, g2);
                Console.Write(array[i] + "  ");
            }
        }
        static void Summ(Task task1)
        {
            sum += array.Sum();
        }
        //Метод поиска максимального числа в массивес помощью LINQ
        static void Maxx(Task task2)
        {
            max = array.Max();
        }
   
        static void Main(string[] args)
        {
            //Задаем исхоные параметры
            Console.WriteLine("Введите размер массива");
            r = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите границу 1 рандомизации");
            g1 = Convert.ToInt32(Console.ReadLine()); 
            Console.WriteLine("Введите границу 2 рандомизации");
            g2 = Convert.ToInt32(Console.ReadLine());
            //Задача на генерацию и вывод массива
            Task tsk0 = new Task(Array);
            tsk0.Start();
            //Создание и вывод массива случайных чисел
            /*array = new int[r];
            Random random = new Random();
            for (int i = 0; i < r; i++)
            {
                array[i] = random.Next(g1, g2);
                Console.Write(array[i] + "  ");
            }*/
            //Задаем задачи на выполнение
            Action<Task> act1 = new Action<Task>(Summ);
            Task tsk1 = tsk0.ContinueWith(act1);
            Action<Task> act2 = new Action<Task>(Maxx);
            Task tsk2 = tsk1.ContinueWith(act2);
            tsk1.Wait();
            tsk2.Wait();
            Console.WriteLine();
            Console.WriteLine("Сумма элементов массива {0}", sum);
            Console.WriteLine("Максимальное число в массиве {0}", max);
            Console.ReadKey();
        }
    }
}
