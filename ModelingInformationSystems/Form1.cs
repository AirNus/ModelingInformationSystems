using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ByMarin
{
    public partial class Form1 : Form
    {
        double[] dotes;
        public Form1()
        {
            InitializeComponent();
            
        }
        public void DrawGrafics(int intervals, double[] dotes)
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
            chartGrafics.ChartAreas.Add(new ChartArea("UniformRasp"));
            chartGrafics.ChartAreas[0].AxisX.Maximum = 1;
            Series mySeries = new Series("Uniform")
            {
                ChartType = SeriesChartType.Column,
                ChartArea = "UniformRasp"             
            };

            double durInterval = (double)1 / intervals;
            double tempInterval = durInterval;
            int countDotesInInterval;
            int currDotes = dotes.Length;
            while (tempInterval <= 1)
            {
                countDotesInInterval = 0;
                do
                {
                    countDotesInInterval++;
                    currDotes--;
                }
                while (dotes[currDotes] < tempInterval && currDotes > 0);
                mySeries.Points.AddXY(tempInterval, countDotesInInterval);
                tempInterval += durInterval;

            }
            chartGrafics.Series.Add(mySeries);

        }

        public double[] GenerateRandNumber(int kol)
        {                   
            double[] dotes = new double[kol];
            Random random = new Random();
            for(int i = 0; i < kol; i ++)
            {
                dotes[i] = random.NextDouble();
            }
            return dotes;
        }

        private void buttonStartDrawGrafics_Click(object sender, EventArgs e)
        {
            chartGrafics.ChartAreas.Clear();
            chartGrafics.Series.Clear();
            if( textBoxKolNumber.TextLength < 1 || textBoxIntervals.TextLength < 1)
            {
                MessageBox.Show("Проверьте введены ли нужные данные\n(количество значений,количество интервалов)","Ошибка!");
                return;
            }
            int kol = Convert.ToInt32(textBoxKolNumber.Text);
            int intervals = Convert.ToInt32(textBoxIntervals.Text);

            if (radioButtonDefaultGeneration.Checked)
            {
                dotes = GenerateRandNumber(kol);
            }
            else if(radioButtonKongryen.Checked)
            {
                MessageBox.Show("TestK");
            }
            else if(radioButtonMethodLemera.Checked)
            {
                MessageBox.Show("TestL");
            }
            else
            {
                MessageBox.Show("Вы не выбрали метод генерации чисел", "Ошибка!");
                return;
            }
            DrawGrafics(intervals, dotes);
        }
    }
}
