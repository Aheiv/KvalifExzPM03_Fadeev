using System;
using System.IO;

namespace ConsoleApp1
{
    struct Tour
    {
        public string direction { get; set; }
        public double time { get; set; }
        public int price { get; set; }
    }

    public class TouristicAgency
    {

        public int n;
        Tour[] tour;
        public void Create()
        {
            Console.Write("Введите число турпоездок: ");
            while (!int.TryParse(Console.ReadLine(), out n) && n <= 0)
            {
                Console.WriteLine("Формат ввода неверен! Попробуйте ещё раз!");
                Console.Write("\nВведите число турпоездок: ");
            }
            Tour[] t = new Tour[n];
            
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Элемент №{i+1}");
                Console.Write("Введите направление поездки: ");
                t[i].direction = Console.ReadLine();
                Console.Write("\nВведите продолжительность поездки(в часах): ");
                double temp1;
                while (!double.TryParse(Console.ReadLine(), out temp1) && temp1 > 0)
                {
                    Console.WriteLine("Формат ввода неверен! Попробуйте ещё раз!");
                    Console.Write("\nВведите продолжительность поездки(в часах): ");
                }
                t[i].time = temp1;
                Console.Write("\nВведите цену поездки(в рублях): ");
                int temp2;
                while (!int.TryParse(Console.ReadLine(), out temp2) && temp2 <= 0)
                {
                    Console.WriteLine("Формат ввода неверен! Попробуйте ещё раз!");
                    Console.Write("\nВведите цену поездки(в рублях): ");
                }
                t[i].price = temp2;
            }
            tour = new Tour[n];
            for (int i = 0; i < n; i++)
            {
                tour[i] = t[i];
            }
        }

        public void Print()
        {
            Console.WriteLine("Текущие турпоездки: \n");
            for (int i = 0; i < tour.Length; i++)
            {
                Console.WriteLine($"Поездка №{i+1}");
                Console.WriteLine($"Направление: {tour[i].direction}");
                Console.WriteLine($"Продолжительность: {tour[i].time}");
                Console.WriteLine($"Цена: {tour[i].price}\n");
            }
        }
        
    }
    class Program
    {     
        static void Main(string[] args)
        {
            TouristicAgency tourAgency = new TouristicAgency();
            tourAgency.Create();
            tourAgency.Print();
        }
    }
}
