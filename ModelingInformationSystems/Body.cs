﻿using ModelingInformationSystems;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ModelingInformationSystems
{
    public partial class Body : Form
    {
        double PredelAxisX;
        double[] dotes;
       
        
        ///
        Random random = new Random();
        public Body()
        {
            InitializeComponent();
            // Page3 Normal
            radioButtonPage3ArbitraryNormal.CheckedChanged += new EventHandler(radioButtonPage3Checked);
            radioButtonPage3StandartNormal.CheckedChanged += new EventHandler(radioButtonPage3Checked);
            // Page4 Exponential
            radioButtonPage4Exponential.CheckedChanged += new EventHandler(radioButtonPage4Checked);
            radioButtonPage4HyperExponential.CheckedChanged += new EventHandler(radioButtonPage4Checked);

            // Waterhouse
            checkBoxSetMethodGenerate.CheckedChanged += new EventHandler(checkBoxSetMethodGenerate_CheckedChange);
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

        public void DrawGrafics(int intervals, double[] dotes, double PredelAxisX)
        {           
            chartGrafics.ChartAreas.Add(new ChartArea("Rasp"));
            if(PredelAxisX == 0)
            {
                MessageBox.Show("PredelAxisX равен нулю! Ахтунг!","Ошибка!");
                return;
            }
            chartGrafics.ChartAreas[0].AxisX.Maximum = dotes.Max();
            chartGrafics.ChartAreas[0].AxisX.Minimum = dotes.Min();
            Series mySeries = new Series("Uniform")
            {
                
                ChartType = SeriesChartType.Column,
                ChartArea = "Rasp"             
            };

            SortedArrayToDesc(dotes);

            double durInterval = (double)(PredelAxisX - dotes.Min()) / intervals;
            double tempInterval = dotes.Min();
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
        private void buttonPage1StartDrawGrafics_Click(object sender, EventArgs e)
        {
            chartGrafics.ChartAreas.Clear();
            chartGrafics.Series.Clear();
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

            int startInterval = Convert.ToInt32(textBoxPage2StartNumberGenerate.Text);
            int endInterval = Convert.ToInt32(textBoxPage2EndNumberGenerate.Text);
            if (radioButtonPage2Trap.Checked)
            {               
                dotes = Simpson.GenerateNumberTrapezoidal(kol,startInterval,endInterval);
                PredelAxisX = dotes.Max();//endInterval * 1.5;
            }
            else if (radioButtonPage2Triangle.Checked)
            {
               dotes = Simpson.GenerateNumberTriangle(kol,startInterval,endInterval);
               PredelAxisX = endInterval * 1.5;
            }          
            else
            {
                MessageBox.Show("Вы не выбрали метод генерации чисел", "Ошибка!");
                return;
            }
            DrawGrafics(intervals, dotes, PredelAxisX);
        }

        private void buttonPage3StartDrawGrafics_Click(object sender, EventArgs e)
        {
            chartGrafics.ChartAreas.Clear();
            chartGrafics.Series.Clear();
            // Если в одном из TextBox'ов не введены данные операция прервется и выведется оповещение
            if (CheckTextOnTextBoxInTabPage(tabPageThirdQuest))
                return;
            int kol = Convert.ToInt32(textBoxPage3Kol.Text);
            int intervals = Convert.ToInt32(textBoxPage3Intervals.Text);
            if (radioButtonPage3StandartNormal.Checked)
            {               
                int n = Convert.ToInt32(textBoxPage3N.Text);
                dotes = Normal.GenerateNumberStandartNormal(kol, n);
                PredelAxisX = dotes.Max();
            }
            else if (radioButtonPage3ArbitraryNormal.Checked)
            {
                int M = Convert.ToInt32(textBoxPage3M.Text);
                int deviation = Convert.ToInt32(textBoxPage3Deviation.Text);
                dotes = Normal.GenerateNumberArbitraryNormal(kol, M, deviation);
                PredelAxisX = dotes.Max();   
            }
            else
            {
                MessageBox.Show("Вы не выбрали метод генерации чисел", "Ошибка!");
                return;
            }
            DrawGrafics(intervals, dotes, PredelAxisX);
        }
        private void radioButtonPage3Checked(object sender, EventArgs e)
        {
            if (radioButtonPage3StandartNormal.Checked)
            {
                textBoxPage3M.Visible = false;
                textBoxPage3M.Text = "erynda";
                labelPage3M.Visible = false;
                textBoxPage3Deviation.Visible = false;
                textBoxPage3Deviation.Text = "erynda";
                labelPage3Deviation.Visible = false;
                labelPage3N.Visible = true;
                textBoxPage3N.Visible = true;
                textBoxPage3N.Text = "";


            }
            else if (radioButtonPage3ArbitraryNormal.Checked)
            {
                labelPage3N.Visible = false;
                textBoxPage3N.Visible = false;
                textBoxPage3N.Text = "erynda";
                textBoxPage3M.Visible = true;
                textBoxPage3M.Text = "";
                labelPage3M.Visible = true;
                textBoxPage3Deviation.Visible = true;
                textBoxPage3Deviation.Text = "";
                labelPage3Deviation.Visible = true;              
            }
        }

        private void buttonPage4StartDrawGrafics_Click(object sender, EventArgs e)
        {
            chartGrafics.ChartAreas.Clear();
            chartGrafics.Series.Clear();
            // Если в одном из TextBox'ов не введены данные операция прервется и выведется оповещение
            if (CheckTextOnTextBoxInTabPage(tabPageFourthQuest))
                return;
            int kol = Convert.ToInt32(textBoxPage4Kol.Text);
            int intervals = Convert.ToInt32(textBoxPage4Intervals.Text);
            if (radioButtonPage4Exponential.Checked)
            {
                int lambda = Convert.ToInt32(textBoxPage4Lambda.Text);
                if(lambda <= 0)
                {
                    MessageBox.Show("Лямбда не может быть равна нулю!","Ошибка!");
                    return;
                }
                dotes = Exponential.GenerateNumberExponential(kol, lambda);
                PredelAxisX = dotes.Max();
            }
            else if (radioButtonPage4HyperExponential.Checked)
            {
                int lambda = Convert.ToInt32(textBoxPage4Lambda.Text);
                int lambda2 = Convert.ToInt32(textBoxPage4Lambda2Hyper.Text);
                double probability = Convert.ToDouble(textBoxPage4Probability.Text,CultureInfo.InvariantCulture);
                if(probability >= 1)
                {
                    MessageBox.Show("Вероятность не может быть больше или равна единице!", "Ошибка!");
                    return;
                }
                if (lambda <= 0)
                {
                    MessageBox.Show("Лямбда не может быть равна нулю!", "Ошибка!");
                    return;
                }
                if (lambda2 <= 0)
                {
                    MessageBox.Show("Лямбда2 не может быть равна нулю!", "Ошибка!");
                    return;
                }
                dotes = Exponential.GenerateNumberHyperExponential(kol, lambda, lambda2, probability);
                PredelAxisX = dotes.Max();
            }
            else
            {
                MessageBox.Show("Вы не выбрали метод генерации чисел", "Ошибка!");
                return;
            }
            DrawGrafics(intervals, dotes, PredelAxisX);
        }

        private void radioButtonPage4Checked(object sender, EventArgs e)
        {
            if (radioButtonPage4Exponential.Checked)
            {
                labelPage4Lambda2Hyper.Visible = false;
                labelPage4Probability.Visible = false;
                textBoxPage4Lambda2Hyper.Visible = false;
                textBoxPage4Lambda2Hyper.Text = "Banana";
                textBoxPage4Probability.Visible = false;
                textBoxPage4Probability.Text = "Banana";
            }
            else if (radioButtonPage4HyperExponential.Checked)
            {
                labelPage4Lambda2Hyper.Visible = true;
                labelPage4Probability.Visible = true;
                textBoxPage4Lambda2Hyper.Visible = true;
                textBoxPage4Lambda2Hyper.Text = "";
                textBoxPage4Probability.Visible = true;
                textBoxPage4Probability.Text = "";
            }
        }

        private void buttonPage5StartDrawGrafics_Click(object sender, EventArgs e)
        {
            chartGrafics.ChartAreas.Clear();
            chartGrafics.Series.Clear();         
            int kol = Convert.ToInt32(textBoxPage5Kol.Text);
            int intervals = Convert.ToInt32(textBoxPage5Intervals.Text);

            int order = Convert.ToInt32(textBoxPage5Order.Text);

            int lambda = Convert.ToInt32(textBoxPage5Lambda.Text);

            dotes = Erlang.GenerateNumberErlang(kol, lambda, order);
            
            PredelAxisX = dotes.Max();
            
            DrawGrafics(intervals, dotes, PredelAxisX);
        }

        private void toolStripButtonRasp_Click(object sender, EventArgs e)
        {
            groupBoxTotalRasp.Visible = true;
            groupBoxWaterhouse.Visible = false; 
            groupBoxCPU.Visible = false;
        }

        private void toolStripButtonWaterhouse_Click(object sender, EventArgs e)
        {
            groupBoxTotalRasp.Visible = false;
            groupBoxWaterhouse.Visible = true;
            groupBoxCPU.Visible = false;
        }

        private void toolStripButtonCPU_Click(object sender, EventArgs e)
        {
            groupBoxTotalRasp.Visible = false;
            groupBoxWaterhouse.Visible = false;
            groupBoxCPU.Visible = true;
        }

        private async void buttonWaterhouseStartModeling_Click(object sender, EventArgs e)
        {          
            textBoxWaterhouseOutputInfoGoods.Text = "";
            textBoxWaterhouseOutputPurchase.Text = "";
            textBoxWaterhouseStatisticForDays.Text = "";          
            OutputInTextBox output = new OutputInTextBox();
            output.OutputPurchase = textBoxWaterhouseOutputPurchase;
            output.OutputInfoGoods = textBoxWaterhouseOutputInfoGoods;
            output.OutputStatistic = textBoxWaterhouseStatisticForDays;         

            ParamForModeling forModeling = new ParamForModeling();
            forModeling.days = (int) numericUpDownWaterhouseDays.Value;
            // Количество товаров
            forModeling.kolTypesGoods = (int)numericUpDownWaterhouseTypesGoods.Value ;
            // Минимальное количество товаров на складе до закупки
            forModeling.minimumQuantity = (int) numericUpDownWaterhouseMinLeft.Value;
            // Количество единиц закупаемых товаров
            forModeling.procurementSize = (int) numericUpDownPurchaseInStorage.Value;
            // Количество клиентов
            forModeling.countCustomer = (int) numericUpDownWaterhouseCustomerCount.Value;
            // Максимальное количество товаро которое может купить 1 клиент
            forModeling.kolPurchaseCustomer = (int) numericUpDownPredelPurchase.Value;
            // Стартовое количество единиц товаров
            forModeling.startKolGoods = (int) numericUpDownWaterhouseStartKolGoods.Value;

            if (radioButtonWaterhouseTriangle.Checked)
            {
                forModeling.generate = new Simpson();
            }
            else if (radioButtonWaterhouseNormal.Checked)
            {
                forModeling.generate = new Normal();
            }
            else
            {
                forModeling.generate = new Uniform();
            }

            await Waterhouse.AsyncModelingWork(forModeling,output);
        }

        private void checkBoxSetMethodGenerate_CheckedChange(object sender, EventArgs e)
        {
            if (checkBoxSetMethodGenerate.Checked)
            {
                groupBoxWaterhouseRasp.Visible = true;
            }
            else
                groupBoxWaterhouseRasp.Visible = false;
        }

        private void buttonCPUStartModeling_Click(object sender, EventArgs e)
        {
            int TotalTime = Convert.ToInt32(numericUpDownCPUAllottedTime.Value);

            Dictionary<string, int> timeParam = new Dictionary<string, int>();
            timeParam.Add("Monitor", Convert.ToInt32(numericUpDownMonitor.Value));
            timeParam.Add("Printer", Convert.ToInt32(numericUpDownPrinter.Value));
            timeParam.Add("Keyboard", Convert.ToInt32(numericUpDownKeyboard.Value));
            timeParam.Add("CPU", Convert.ToInt32(numericUpDownCPU.Value));


            var answer = CPUModel.ModellingWorkCPU(TotalTime,timeParam);
            labelCPUKeyboardValue.Text = answer["Keyboard"].totalTime.ToString();
            labelCPUMonitorValue.Text = answer["Monitor"].totalTime.ToString();
            labelCPUPrinterValue.Text = answer["Printer"].totalTime.ToString();
            labelCPUcpuValue.Text = answer["CPU"].totalTime.ToString();
            labelCPUTotalTimeValue.Text = answer["total"].totalTime.ToString();

            labelCPUMonitorValuePercent.Text =  "- " + (answer["Monitor"].totalTime / (TotalTime * 2 / 100)).ToString() + "%";
            labelCPUPrinterValuePercent.Text = "- " + (answer["Printer"].totalTime / (TotalTime * 2 / 100)).ToString() + "%";
            labelCPUKeyboardValuePercent.Text = "- " + (answer["Keyboard"].totalTime / (TotalTime * 2 / 100)).ToString() + "%";
            labelCPUcpuValuePercent.Text = "- " + (answer["CPU"].totalTime / (TotalTime * 2 / 100)).ToString() + "%";

            labelCPUMaxLengthQuequeMonitor.Text = answer["Monitor"].maxLengthQueque.ToString();
            labelCPUAvgLengthQuequeMonitor.Text = answer["Monitor"].avgLengthQueque.ToString();
            labelCPUMaxLengthQuequePrinter.Text = answer["Printer"].maxLengthQueque.ToString();
            labelCPUAvgLengthQuequePrinter.Text = answer["Printer"].avgLengthQueque.ToString();
            labelCPUMaxLengthQuequeKeyboard.Text = answer["Keyboard"].maxLengthQueque.ToString();
            labelCPUAvgLengthQuequeKeyboard.Text = answer["Keyboard"].avgLengthQueque.ToString();
            labelCPUMaxLengthQuequeCPU.Text = answer["CPU"].maxLengthQueque.ToString();
            labelCPUAvgLengthQuequeCPU.Text = answer["CPU"].avgLengthQueque.ToString();

            labelCPUSpentTimeValue.Text = (TotalTime * 2 - answer["total"].totalTime).ToString();
        }

    }
}
