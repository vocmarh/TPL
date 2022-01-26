using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab22
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.Write("Введите размер массива: ");
            int n = Int32.Parse(Console.ReadLine());
            int[] array = new int[n];

            Task task1 = new Task(() => CreateArray(n, ref array));

            Action<Task, object> action1 = new Action<Task, object>(GetArraySum);
            Action<Task, object> action2 = new Action<Task, object>(GetArrayMax);
            Task task2 = task1.ContinueWith(action1, array);
            Task task3 = task1.ContinueWith(action2, array);

            task1.Start();
            Console.ReadKey();
        }
        static void CreateArray(int n, ref int[] array)
        {
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(-50, 50);
            }
            Console.WriteLine("Массив: ");
            foreach (int a in array)
            {
                Console.Write($" {a} ");
            }
            Console.WriteLine("\n");
        }
        static void GetArraySum(Task task, object arr)
        {
            int[] array = (int[])arr;
            Console.WriteLine($"Сумма элементов массива: {array.Sum()}");
        }
        static void GetArrayMax(Task task, object arr)
        {
            int[] array = (int[])arr;
            Console.WriteLine($"Максимальное значение в массиве: {array.Max()}");
        }
    }
}