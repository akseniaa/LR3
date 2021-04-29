using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите необходимую задачу");
            Console.WriteLine("1. Вычислить определитель именной матрицы Редхеффера");
            Console.WriteLine("2. Решить квадратную систему линейных уравнений методом Крамера");
            var flag = Convert.ToInt32(Console.ReadLine());
            if (flag == 1)
            {
                Console.WriteLine("Введите размерность матрицы");
                var size = Convert.ToInt32(Console.ReadLine());
                var m = new double[size, size];
                for (var i = 0; i < size; i++)
                    for (var j = 0; j < size; j++)
                    {
                        var a = i + 1;
                        var b = j + 1;
                        if (b % a == 0 || j==0) m[i, j] = 1;                                               
                        else m[i, j] = 0;
                    }
                var det = Matrix.Determ(m);
                Console.WriteLine("Определитель матрицы - " + det);
                Console.Read();
            }
            else
            {
                Console.WriteLine("Введите количество переменных");
                var n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите уравнения, после каждого нажимая enter");
                var list = new string[n];
                for (var i = 0;i < n; i++)
                {
                    list[i] = Console.ReadLine();
                }
                Matrix.ConvertToMatrix(list);
                Console.Read();
            }
        }
    }
}
