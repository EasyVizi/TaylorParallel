using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Taylor
{
    public class MathLogic
    {
        public long Factorial(int a)
        {
            if (a == 0)
                return 1;
            if (a == 1)
                return a * 1;
            return a * Factorial(a - 1);
            
        }
    }

    class Cosinus
    {
        MathLogic ml = new MathLogic();
        public long mainCalc(int n, int x, int firstParam, int xCoef)
        {
            long result = 0;
            for (int i = 1; i <= n; i++)
            {
                result = (((-1) ^ (i)) / (ml.Factorial(2 * i))) * (xCoef * x ^ i);
            }
            return firstParam * result;
        }
    }

    public class Sinus
    {
        public double tailorFactory(double x)
        {
            while (x > Math.PI) x -= Math.PI;
            int z = 1, i = 1;
            ulong factorial = 1;
            double stx = x, sint = 0;

            while (stx / factorial >= 0.0001)
            {
                sint += z * stx / factorial;
                i += 2;
                stx = stx * x * x;
                factorial = factorial * (ulong)(i - 1) * (ulong)i;
                z = z * (-1);
            }
            return sint;
        }
    }

    public class SecondCosinus
    {
        public double tailorFactory(double x)
        {
            while (x > Math.PI) x -= Math.PI;
            int z = -1, i = 2;
            ulong factorial = 2;
            double stx = x * x, cost = 1;

            while (stx / factorial >= 0.0001)
            {
                cost += z * stx / factorial;
                i += 2;
                stx = stx * x * x;
                factorial = factorial * (ulong)(i - 1) * (ulong)i;
                z = z * (-1);
            }
            return cost;
        }
    }

    public class Eps
    {
        public double tailorFactory(double x)
        {
            double eps = 0.0001; //Точность вычисления. 
            double result = 0; //Храним результат 
            double currValue = -1; // Здесь храним каждый елемент ряда. 
            int n = 0; // Степень члена ряда. 

            while (Math.Abs(currValue) > eps) // Если очередной элемент ряда меньше точности - выход. 
            {
                long fact = 1;
                for (int i = 1; i <= n; i++)
                {
                    fact *= i;
                }
                
                currValue = (Math.Pow(-1, n) * Math.Pow(x, n)) / fact;
                result += currValue;
                n++;
            }
            return result;
        }

        private long factorial(int n)
        {
            long result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }

    public class MyMatrix
    {
        public static string ToString(int[,] matrix)
        {
            string result = "";

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result += matrix[i, j].ToString();
                    result += "  ";
                }
                result += "\n";
            }

            return result;
        }

        public static int[,] ParallelPlusMatrix(int[,] matrixArray1, int[,] matrixArray2)
        {
            int[,] result = new int[matrixArray1.GetLength(0), matrixArray2.GetLength(1)];
            Parallel.For(0, result.GetLength(0) * result.GetLength(1), b =>
            {
                int i, j;
                if (b == 1)
                    result[0, 0] = matrixArray1[0, 0] + matrixArray2[0, 0];
                else
                {
                    i = (b / result.GetLength(0));
                    j = (b % result.GetLength(0) == 0) ? result.GetLength(0) - 1 : b % result.GetLength(0) - 1;
                    result[i, j] = matrixArray1[i, j] + matrixArray2[i, j];
                }
            });

            return result;
        }

        public static int[,] PlusMatrix(int[,] matrixArray1, int[,] matrixArray2)
        {
            int[,] result = new int[matrixArray1.GetLength(0), matrixArray2.GetLength(1)];
            for (int i = 1; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = matrixArray1[i, j] + matrixArray2[i, j];
                }
            }
            return result;
        }
    }

    // Думал сделать под несколько видов функций, но времени нет)
    public enum FunctionType
    {
        cos,
    }
}
