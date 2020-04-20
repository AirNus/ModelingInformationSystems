using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingInformationSystems
{
    class Exponential
    {
        static Random random = new Random();
        static public double[] GenerateNumberExponential(int kol, int lambda)
        {
            
            double[] dotes = new double[kol];            
            for (int i = 0; i < kol; i++)
            {
                dotes[i] = -1.0 / lambda * Math.Log(random.NextDouble());
            }

            return dotes;
        }

        static public double[] GenerateNumberHyperExponential(int kol, int lambda, int lambda2, double probability)
        {

            double[] dotes = new double[kol];

            double e = Math.E;

            for(int i = 0; i < kol; i++)
            {
                double x = random.NextDouble();
                dotes[i] = probability * lambda * Math.Pow(e, -lambda * x) + (1 - probability) * lambda2 * Math.Pow(e, -lambda2 * x);
            }
            //for (int i = 0; i < kol; i++)
            //{
            //    double x = random.NextDouble();
            //    dotes[i] = probability * (1.0 - Math.Pow(e, -1.0 * lambda * x))
            //        + (1.0 - probability) * (1.0 - Math.Pow(e, -1.0 * lambda2 * x));
            //}

            return dotes;
        }
    }
}
