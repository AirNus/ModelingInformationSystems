using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelingInformationSystems
{
    class Normal
    {
        static Random random = new Random();
        static public double[] GenerateNumberStandartNormal(int kol,int n)
        {

            double sum;
            double[] dotes = new double[kol];
            double tmp = Math.Sqrt(12.0 / n);
            for(int i = 0; i < kol; i++)
            {
                sum = 0;
                for (int j = 0; j < n; j++)
                {
                    sum += random.NextDouble()  - n/2;
                }
                dotes[i] = tmp * Math.Abs(sum);
            }

            return dotes;
        }

        static public double[] GenerateNumberArbitraryNormal(int kol,int M,int deviation)
        {

            double[] dotes = new double[kol];
            for (int i = 0; i < kol; i++)
            {
                double z1 = 1.0 - random.NextDouble(); 
                double z2 = 1.0 - random.NextDouble();
                double randNormal = Math.Sqrt(-2.0 * Math.Log(z1)) *
                             Math.Sin(2.0 * Math.PI * z2); 
                dotes[i] = M + deviation * (randNormal); 
            }
            return dotes;
        }
    }
}
