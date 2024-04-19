using System;
using System.IO;
using System.Text;

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
                while (!double.TryParse(Console.ReadLine(), out temp1) && temp1 <= 0)
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
        public void Sort()
        {
            Console.WriteLine("Сортировка по времени и цене(убывание): \n");
            string t1;
            double t2;
            int t3;
            for (int i = 0; i < tour.Length; i++)
            {
                for (int s = 0; s < tour.Length - 1; s++)
                {
                    if (tour[s].time < tour[s + 1].time)
                    {
                        t1 = tour[s + 1].direction;
                        t2 = tour[s + 1].time;
                        t3 = tour[s + 1].price;
                        tour[s + 1].direction = tour[s].direction;
                        tour[s + 1].time = tour[s].time;
                        tour[s + 1].price = tour[s].price;
                        tour[s].direction = t1;
                        tour[s].time = t2;
                        tour[s].price = t3;
                    }
                    else if (tour[s].time == tour[s + 1].time && tour[s].price < tour[s + 1].price)
                    {
                        t1 = tour[s + 1].direction;
                        t2 = tour[s + 1].time;
                        t3 = tour[s + 1].price;
                        tour[s + 1].direction = tour[s].direction;
                        tour[s + 1].time = tour[s].time;
                        tour[s + 1].price = tour[s].price;
                        tour[s].direction = t1;
                        tour[s].time = t2;
                        tour[s].price = t3;
                    }
                }
            }
        }
        public void FileCreate()
        {
            using (FileStream fs = File.Create("file.txt"))
            { 
                for (int i = 0; i < tour.Length; i++)
                {
                    byte[] tmp1 = Encoding.Default.GetBytes($"Направление №{i+1}: " + tour[i].direction + " ");
                    fs.Write(tmp1);
                    byte[] tmp2 = Encoding.Default.GetBytes($"Продолжительность №{i + 1}: " + tour[i].time.ToString()+ " ");
                    fs.Write(tmp2);
                    byte[] tmp3 = Encoding.Default.GetBytes($"Цена №{i + 1}: " + tour[i].price.ToString() + "\n");
                    fs.Write(tmp3);
                }

                fs.Close();
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
            tourAgency.Sort();
            tourAgency.Print();
            tourAgency.FileCreate();
        }
    }
}
