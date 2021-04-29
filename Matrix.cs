using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR3
{
    class Matrix
    {

        public static double Determ(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) throw new Exception("Матрица не квадратная");
            double det = 0;
            var num = matrix.GetLength(0);
            if (num == 1) det = matrix[0, 0];
            if (num == 2) det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            if (num > 2)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    det += Math.Pow(-1, 0 + j) * matrix[0, j] * Determ(GetMinor(matrix, 0, j));
                }
            }
            return det;
        }

        public static double[,] GetMinor(double[,] matrix, int row, int column)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) throw new Exception("Матрица не квадратная");
            var arr = new double[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
            for (var i = 0; i < matrix.GetLength(0); i++)
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i != row) || (j != column))
                    {
                        if (i > row && j < column) arr[i - 1, j] = matrix[i, j];
                        if (i < row && j > column) arr[i, j - 1] = matrix[i, j];
                        if (i > row && j > column) arr[i - 1, j - 1] = matrix[i, j];
                        if (i < row && j < column) arr[i, j] = matrix[i, j];
                    }
                }
            return arr;
        }

        static double[] result;
        public static void ConvertToMatrix(string[] input)
        {
            double num;
            var n = input.Length;
            var A = new double[n, n];
            var b = new double[n];
            var x = new double[n];
            var flag = true;
            for (var i = 0; i < n; i++)
            {
                var j = 0;
                var s = input[i].Split('=');
                b[i] = Convert.ToDouble(s[1]);
                foreach(var item in s[0])
                {
                    if (item == '-') flag = false;
                    if (double.TryParse(item.ToString(), out num))
                    {
                        if (flag)
                            A[i, j] = Convert.ToDouble(item.ToString());
                        else
                        {
                            A[i, j] = -Convert.ToDouble(item.ToString());
                            flag = true;
                        }                             
                        j++;
                    }                        
                }
            }
            if (SLAU_Kramer(n, A, b, x) == 1)
            {
                Console.WriteLine("Система не имеет решений или имеет бесконечно много решений");
                Console.Read();
                return;
            }
            else
            {
                for (int i = 0; i < n; i++)
                    Console.WriteLine("x" + i + " = " + result[i]);
                Console.Read();
            }                
        }    

        public static int SLAU_Kramer(int n, double[,] A, double[] b, double[] x)
        {
            double[,] An = new double[n, n];
            double det1 = Determ(A);
            if (det1 == 0) return 1;
            for (int i = 0; i < n; i++)
            {
                Equal(n, An, A);
                Change(n, i, An, b);
                x[i] = Determ(An) / det1;
            }
            result = x;
            return 0;
        }
        static void Equal(int n, double[,] A, double[,] B)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    A[i, j] = B[i, j];
        }
        static void Change(int n, int N, double[,] A, double[] b)
        {
            for (int i = 0; i < n; i++)
                A[i, N] = b[i];
        }
    }
}
