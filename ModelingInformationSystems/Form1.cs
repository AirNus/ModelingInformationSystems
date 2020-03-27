using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ModelingInformationSystems
{
    public partial class Form1 : Form
    {
        int PredelAxisX;
        double[] dotes;
        /// Метод простых конгруэнций
        const int P = 140305;
        const int A = 4081;
        /// Распределение Лемераы
        const int a = 45156;
        const int c = 31502;
        const int m = 171545;
        ///
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            
        }

        public double[] SortedArrayToDesc(double[] dotes)
        {
            int last = dotes.Length;
            for (bool sorted = (last == 0); !sorted; last--)
            {
                sorted = true;
                for (int i = 1; i < last; i++)
                {
                    if (dotes[i - 1] < dotes[i])
                    {
                        sorted = false;
                        double buff = dotes[i - 1];
                        dotes[i - 1] = dotes[i];
                        dotes[i] = buff;
                    }
                }
            }
            return dotes;
        }

        public void DrawGrafics(int intervals, double[] dotes, int PredelAxisX)
        {           
            chartGrafics.ChartAreas.Add(new ChartArea("UniformRasp"));
            chartGrafics.ChartAreas[0].AxisX.Maximum = PredelAxisX;
            Series mySeries = new Series("Uniform")
            {
                ChartType = SeriesChartType.Column,
                ChartArea = "UniformRasp"             
            };

            SortedArrayToDesc(dotes);

            double durInterval = (double)PredelAxisX / intervals;
            double tempInterval = durInterval;
            int countDotesInInterval;
            int currDotes = dotes.Length;
            while (tempInterval <= PredelAxisX)
            {
                countDotesInInterval = 0;
                do
                {
                    countDotesInInterval++;
                    currDotes--;
                }
                while (currDotes > 0 && dotes[currDotes] < tempInterval);
                mySeries.Points.AddXY(tempInterval, countDotesInInterval);
                tempInterval += durInterval;

            }
            chartGrafics.Series.Add(mySeries);

        }

        /// <summary>
        /// ///////////
        /// </summary>
        /// <param name="kol"></param>
        /// <returns></returns>
        public double[] GenerateRandNumber(int kol)
        {                   
            double[] dotes = new double[kol];           
            for(int i = 0; i < kol; i ++)
            {
                dotes[i] = random.NextDouble();
            }
            return dotes;
        }

        public double[] GenerateRandNumberMethodCongruence(int kol)
        {
            
            double[] dotes = new double[kol];
            dotes[0] = random.Next() % P;
            for(int i = 1; i < kol; i ++)
            {
                dotes[i] = (A * dotes[i - 1]) % P;
            }
            return dotes;
        }

        public double[] GenerateRandNumberMethodLemera(int kol)
        {
            
            double[] dotes = new double[kol];
            dotes[0] = random.Next() % m;
            for(int i = 1; i < kol; i++)
            {
                dotes[i] = (a * dotes[i - 1] + c) % m;
            }
            return dotes;
        }

        /// <summary>
        /// //
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStartDrawGrafics_Click(object sender, EventArgs e)
        {
            chartGrafics.ChartAreas.Clear();
            chartGrafics.Series.Clear();
            if( textBoxPage1Kol.TextLength < 1 || textBoxPage1Intervals.TextLength < 1)
            {
                MessageBox.Show("Проверьте введены ли нужные данные\n(количество значений,количество интервалов)","Ошибка!");
                return;
            }
            int kol = Convert.ToInt32(textBoxPage1Kol.Text);
            int intervals = Convert.ToInt32(textBoxPage1Intervals.Text);

            if (radioButtonDefaultGeneration.Checked)
            {
                PredelAxisX = 1;
                dotes = GenerateRandNumber(kol);
            }
            else if(radioButtonKongryen.Checked)
            {
                PredelAxisX = P;
                dotes = GenerateRandNumberMethodCongruence(kol);
            }
            else if(radioButtonMethodLemera.Checked)
            {
                PredelAxisX = m;
                dotes = GenerateRandNumberMethodLemera(kol);
            }
            else
            {
                MessageBox.Show("Вы не выбрали метод генерации чисел", "Ошибка!");
                return;
            }
            DrawGrafics(intervals, dotes, PredelAxisX);
        }
        /// 
        /// 2 задание пошло 
        /// 


    }
}
