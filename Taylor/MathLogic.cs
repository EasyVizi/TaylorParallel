﻿using System;
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

    class Cosinus
    {
        const int start = 0;

        public long mainCalc(int n, int x, int firstParam, int xCoef)
        {
            long result = 0;
            for (int i = start; i <= n; i++)
            {
                result = (((-1) ^ (n)) / (MathLogic.Factorial(2 * n))) * (xCoef * x ^ n);
            }
            return firstParam * result;
        }
    }

    public enum FunctionType
    {
        cos,
        sin,
    }
}
