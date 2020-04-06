using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ModelingInformationSystems
{
    public partial class Body : Form
    {
        int PredelAxisX;
        double[] dotes;
       
        
        ///
        Random random = new Random();
        public Body()
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
            if(PredelAxisX != 0)
            {
                chartGrafics.ChartAreas[0].AxisX.Maximum = PredelAxisX;
            }
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

        ///
        private void buttonStartDrawGrafics_Click(object sender, EventArgs e)
        {

            if (CheckTextOnTextBoxInTabPage(tabPageFirstQuest))
                return;
            int kol = Convert.ToInt32(textBoxPage1Kol.Text);
            int intervals = Convert.ToInt32(textBoxPage1Intervals.Text);

            if (radioButtonDefaultGeneration.Checked)
            {
                PredelAxisX = 1;
                dotes = Uniform.GenerateRandNumber(kol);
            }
            else if(radioButtonKongryen.Checked)
            {
                PredelAxisX = Uniform.P;
                dotes = Uniform.GenerateRandNumberMethodCongruence(kol);
            }
            else if(radioButtonMethodLemera.Checked)
            {
                PredelAxisX = Uniform.m;
                dotes = Uniform.GenerateRandNumberMethodLemera(kol);
            }
            else
            {
                MessageBox.Show("Вы не выбрали метод генерации чисел", "Ошибка!");
                return;
            }
            DrawGrafics(intervals, dotes, PredelAxisX);
        }
        private bool CheckTextOnTextBoxInTabPage(TabPage tabPage)
        {
            foreach(Control control in tabPage.Controls)
            {
                if (control.GetType() == typeof(System.Windows.Forms.TextBox))
                {
                    var tmpTextBox = (TextBox)control;
                    if (tmpTextBox.TextLength < 1)
                    {
                        MessageBox.Show("Проверьте введены ли нужные данные!", "Ошибка!");
                        return true;
                    }
                }
            }
            return false;
        }

        private void buttonPage2StartDrawGrafics_Click(object sender, EventArgs e)
        {
            chartGrafics.ChartAreas.Clear();
            chartGrafics.Series.Clear();
            // Если в одном из TextBox'ов не введены данные операция прервется и выведется оповещение
            if (CheckTextOnTextBoxInTabPage(tabPageSecondQuest))
                return;           
            int kol = Convert.ToInt32(textBoxPage2Kol.Text);
            int intervals = Convert.ToInt32(textBoxPage2Intervals.Text);

            if (radioButtonPage2Trap.Checked)
            {
                int startInterval = Convert.ToInt32(textBoxPage2StartNumberGenerate.Text);
                int endInterval = Convert.ToInt32(textBoxPage2EndNumberGenerate.Text);
                PredelAxisX = 0;
                dotes = Simpson.GenerateNumberTrapezoidal(kol,startInterval,endInterval);
            }
            else if (radioButtonPage2Treangle.Checked)
            {
               
            }          
            else
            {
                MessageBox.Show("Вы не выбрали метод генерации чисел", "Ошибка!");
                return;
            }
            DrawGrafics(intervals, dotes, PredelAxisX);
        }
    }
}
