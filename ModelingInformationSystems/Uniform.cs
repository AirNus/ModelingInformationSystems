using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingInformationSystems
{
    class Uniform
    {
        static Random random = new Random();

        /// Метод простых конгруэнций
        public const int P = 140305;
        const int A = 4081;

        /// Распределение Лемераы
        const int a = 45156;
        const int c = 31502;
        public const int m = 171545;

        static public double[] GenerateRandNumber(int kol)
        {
            double[] dotes = new double[kol];
            for (int i = 0; i < kol; i++)
            {
                dotes[i] = random.NextDouble();
            }
            return dotes;
        }

        static public double[] GenerateRandNumberMethodCongruence(int kol)
        {

            double[] dotes = new double[kol];
            dotes[0] = random.Next() % P;
            for (int i = 1; i < kol; i++)
            {
                dotes[i] = (A * dotes[i - 1]) % P;
            }
            return dotes;
        }

        static public double[] GenerateRandNumberMethodLemera(int kol)
        {

            double[] dotes = new double[kol];
            dotes[0] = random.Next() % m;
            for (int i = 1; i < kol; i++)
            {
                dotes[i] = (a * dotes[i - 1] + c) % m;
            }
            return dotes;
        }
    }
}
