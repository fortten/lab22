using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab22
{
    /*Сформировать массив случайных целых чисел (размер задается пользователем).
     *Вычислить сумму чисел массива и максимальное число в массиве.
     *Реализовать решение задачи с использованием механизма задач продолжения.*/
    class Program
    {
        static int n;
        static int[] t;

        static void Main(string[] args)
        {
            Console.Write("Введите размер массива: ");
            n = Convert.ToInt32(Console.ReadLine());            
            t = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                t[i] = random.Next(0, 50);
                Console.Write($"{t[i]} ");
            }
            Console.WriteLine();
            Task task1 = new Task(CalcSum);
            Task task2 = task1.ContinueWith(FindMax);
            task1.Start();
            task2.Wait();
            Console.WriteLine("Для завершения нажмите любую клавишу");
            Console.ReadKey();
        }
        static void CalcSum()
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += t[i];
            }
            Console.WriteLine($"Сумма чисел в массиве = {sum}");
        }
        static void FindMax(Task task)
        {
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                if (t[i] > max)
                {
                    max = t[i];
                }
            }
            Console.WriteLine($"Максимальное число в массиве = {max}");
        }
    }
}
