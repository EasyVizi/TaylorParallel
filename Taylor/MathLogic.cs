using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Taylor
{
    static class MathLogic
    {
        static public long Factorial(int a)
        {
            if (a == 0)
                return 1;
            if (a == 1)
                return a * 1;
            return a * Factorial(a - 1);
            
        }
    }

    static class Cosinus
    {
        static public long mainCalc(int n, int x, int firstParam, int xCoef)
        {
            long result = 0;
            for (int i = 0; i <= n; i++)
            {
                result = (((-1) ^ (n)) / (MathLogic.Factorial(2 * n))) * (xCoef * x ^ n);
            }
            return firstParam * result;
        }
    }

    public class MyMatrix
    {
        int[,] matrixArray;

        public int[,] MatrixArray { get => matrixArray; set => matrixArray = value; }

        public MyMatrix(int[,] m)
        {
            MatrixArray = m;
        }

        public override string ToString()
        {
            string result = "";

            for (int i = 0; i < matrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < matrixArray.GetLength(1); j++)
                {
                    result += matrixArray[i, j].ToString();
                    result += "  ";
                }
                result += "\n";
            }

            return result;
        }
    }

    public enum FunctionType
    {
        cos,
    }
}
