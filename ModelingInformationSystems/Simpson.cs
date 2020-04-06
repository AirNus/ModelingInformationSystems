using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingInformationSystems
{
    class Simpson
    {
        static Random random = new Random();
        static public double[] GenerateNumberTrapezoidal(int kol, int startNumber, int endNumber)
        {
            double firstPart, secondPart;
            double[] dotes = new double[kol];
            int half = (startNumber + endNumber) / 8;
            for(int i = 0; i < kol; i ++)
            {
                firstPart = random.Next(startNumber, half * 2);
                secondPart = random.Next(half, endNumber);
                dotes[i] = firstPart + secondPart;
            }
            return dotes;
        }
    }
}
