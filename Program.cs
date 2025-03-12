
using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); // Починаємо вимірювання часу

            int source = 0;
            int point_count = 12;
            int[,] edge_weights = new int[point_count, point_count];
            for (int i = 0; i < point_count; i++)
            {
                for (int j = 0; j < point_count; j++)
                {
                    edge_weights[i, j] = int.MaxValue;
                }
            }
            edge_weights[0, 7] = 500;
            edge_weights[7, 0] = 500;
            edge_weights[7, 4] = 4600;
            edge_weights[4, 7] = 4600;
            edge_weights[4, 9] = 600;
            edge_weights[9, 4] = 600;
            edge_weights[4, 1] = 900;
            edge_weights[1, 4] = 900;
            edge_weights[1, 8] = 1000;
            edge_weights[8, 1] = 1000;
            edge_weights[8, 5] = 1100;
            edge_weights[5, 8] = 1100;
            edge_weights[1, 5] = 1700;
            edge_weights[5, 1] = 1700;
            edge_weights[9, 5] = 650;
            edge_weights[5, 9] = 650;
            edge_weights[5, 10] = 950;
            edge_weights[10, 5] = 950;
            edge_weights[5, 3] = 500;
            edge_weights[3, 5] = 500;
            edge_weights[2, 5] = 1400;
            edge_weights[5, 2] = 1400;
            edge_weights[5, 11] = 2000;
            edge_weights[11, 5] = 2000;
            edge_weights[11, 2] = 600;
            edge_weights[2, 11] = 600;
            edge_weights[2, 3] = 600;
            edge_weights[3, 2] = 600;
            edge_weights[2, 6] = 600;
            edge_weights[6, 2] = 600;
            edge_weights[6, 10] = 750;
            edge_weights[10, 6] = 750;
            int[] Point_weight = new int[point_count];
            for (int i = 0; i < point_count; i++)
            {
                Point_weight[i] = int.MaxValue;
            }
            Point_weight[0] = 0;

            int[] closest_prev_from_source = new int[point_count];
            for (int i = 0; i < point_count; i++)
            {
                closest_prev_from_source[i] = i;
            }

            bool[] VisitedOrNot = new bool[point_count];
            for (int i = 0; i < point_count; i++)
            {
                VisitedOrNot[i] = false;
            }
            Queue<int> q = new Queue<int>();
            q.Enqueue(source);
            while (q.Count != 0)
            {
                int node = q.Dequeue();
                for (int i = 0; i < point_count; i++)
                {
                    if (edge_weights[node, i] != int.MaxValue)
                    {
                        if (VisitedOrNot[i] == false)
                        {
                            int temp_point_weight;
                            temp_point_weight = Point_weight[node] + edge_weights[node, i];
                            if (temp_point_weight < Point_weight[i])
                            {
                                Point_weight[i] = temp_point_weight;
                                closest_prev_from_source[i] = node;
                            }
                            q.Enqueue(i);
                        }
                    }
                }
                VisitedOrNot[node] = true;
            }

            stopwatch.Stop(); // Зупиняємо вимірювання часу

            Console.WriteLine("Найкоротшi шляхи вiд гуртожитку до кожного з мiсць:");
            for (int i = 0; i < point_count; i++)
            {
                Console.WriteLine(Point_weight[i] + "*10^-3");
            }

            Console.WriteLine("Введiть мiсце, до якого Ви бажаєте дiйти:");
            int dest = int.Parse(Console.ReadLine());

            Console.Write(dest); Console.Write(" -> ");
            while (closest_prev_from_source[dest] != source)
            {
                dest = closest_prev_from_source[dest];
                Console.Write(dest); Console.Write(" -> ");
            }
            Console.WriteLine(source);
            Console.Write("Граф зв’язний, має одну компоненту зв’язностi");

            Console.WriteLine($"\nЧас виконання алгоритму: {stopwatch.Elapsed.TotalMicroseconds} мікросекунд");
        }
        catch (Exception)
        {
            Console.WriteLine("Щось пiшло не так, перевiрте введенi данi");
        }
    }
}
