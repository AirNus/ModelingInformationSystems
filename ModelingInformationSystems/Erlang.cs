using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingInformationSystems
{
    class Erlang
    {
        static Random random = new Random();
        static public double[] GenerateNumberErlang(int kol, int lambda, int order)
        {

            double[] dotes = new double[kol];
            double tmp;
            for (int i = 0; i < kol; i++)
            {
                tmp = 0;
                for(int j = 0; j < order; j++)
                {
                    tmp += -1.0 / lambda * Math.Log(random.NextDouble());
                }
                dotes[i] = tmp;
            }


            return dotes;
        }
    }
}
