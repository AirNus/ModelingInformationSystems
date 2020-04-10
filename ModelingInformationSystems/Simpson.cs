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
            

            double half = Convert.ToInt32((startNumber + endNumber) / 8);
            int sum = startNumber + endNumber;
            int Up = (int)half * 2;
            int Low = (int)half;
          

            double[] dotes = new double[kol];
            
            for(int i = 0; i < kol; i ++)
            {
                double firstPart = random.Next(startNumber, Up);
                double secondPart = random.Next(Low, endNumber);
                dotes[i] = firstPart + secondPart;
            }
            return dotes;
        }

        static public double[] GenerateNumberTriangle(int kol, int startNumber, int endNumber)
        {
            
            double[] dotes = new double[kol];
            int sigma = Convert.ToInt32((startNumber + endNumber) / 2);
            for (int i = 0; i < kol; i++)
            {
                double firstNum = (random.Next(startNumber, sigma));
                double secondNum = (random.Next(startNumber, sigma));
               dotes[i] = firstNum + secondNum;
            }

            return dotes;
        }
    }
}
