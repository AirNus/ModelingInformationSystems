using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ByMarin
{
    class OutputInTextBox
    {
        internal Label ChangeMinKol;
        internal Label ChangeProcurementSize;
        internal TextBox OutputPurchase;
        internal TextBox OutputInfoGoods;
        internal TextBox OutputStatistic;
    }
    class ParamForModeling
    {
        internal int days;
        // Количество товаров
        internal int kolTypesGoods;
        // Минимальное количество товаров на складе до закупки
        internal int minimumQuantity;
        // Количество единиц закупаемых товаров
        internal int procurementSize;
        // Количество клиентов
        internal int countCustomer;
        // Максимальное количество товаро которое может купить 1 клиент
        internal int kolPurchaseCustomer;
        // Стартовое количество единиц товаров
        internal int startKolGoods;
    }
    class Waterhouse
    {
        static Random random = new Random();
       
        static void OutputInTextBoxDays(TextBox OutputPurchase,int currDays)
        {
            OutputPurchase.Text += $"День {currDays + 1}." + Environment.NewLine;
        }    
        static internal Task AsyncModelingWork(object Param, object Output)
        {
            return Task.Run(() =>
            {              
                Dictionary<int, int> goods = new Dictionary<int, int>();

                ParamForModeling forModeling = (ParamForModeling) Param;
                OutputInTextBox output = (OutputInTextBox) Output;

                TextBox OutputPurchase = output.OutputPurchase;
                TextBox OutputInfoGoods = output.OutputInfoGoods;
                TextBox OutputStatistic = output.OutputStatistic;
                Label ChangeMinKol = output.ChangeMinKol;
                Label ChangeProcurementSize = output.ChangeProcurementSize;
                int days = forModeling.days;
                // Количество товаров
                int kolTypesGoods = forModeling.kolTypesGoods;
                // Минимальное количество товаров на складе до закупки
                int minimumQuantity = forModeling.minimumQuantity;
                // Количество единиц закупаемых товаров
                int procurementSize = forModeling.procurementSize;
                // Количество клиентов
                int countCustomer = forModeling.countCustomer;
                // Максимальное количество товаро которое может купить 1 клиент
                int kolPurchaseCustomer = forModeling.kolPurchaseCustomer;
                // Стартовое количество единиц товаров
                int startKolGoods = forModeling.startKolGoods;
                // Количество отмененных\неполностью удовлетворенных заказов по дням
                Dictionary<int, int> CanceledOrders = new Dictionary<int, int>();
                // Коллиество неудовлетворенных заказов в текущий день
                int countCanceledOrders = 0;

                for (int i = 0; i < kolTypesGoods; i++)
                {
                    goods.Add(i, startKolGoods);
                }
                //
                // Количество товаров которое клиент закупит сегодня
                int currQuantity;
                // Номер товара который клиент сегодня купит
                int currGood;
                //
                // Информация о покупке, закупке из завода, непроданных товарах в шт.          
                int[,] infoGoods = new int[kolTypesGoods, 3];

                //
                for (int currDays = 0; currDays < days; currDays++)
                {
                    OutputPurchase.Invoke((MethodInvoker)(() =>
                    {
                        OutputPurchase.Text += $"День {currDays + 1}." + Environment.NewLine;
                    }));
                    // Пополнение скалада
                    for (int i = 0; i < goods.Count; i++)
                    {
                        if (goods[i] < minimumQuantity)
                        {
                            goods[i] += procurementSize;
                            infoGoods[i, 1] += procurementSize;
                        }
                    }

                    countCanceledOrders = 0;
                    for (int i = 0; i < countCustomer; i++)
                    {
                        currGood = random.Next(kolTypesGoods);
                        currQuantity = random.Next(kolPurchaseCustomer);
                        if (currQuantity == 0)
                            continue;
                        if (currQuantity > goods[currGood])
                        {
                            countCanceledOrders++;
                            infoGoods[currGood, 2] += currQuantity + goods[currGood];
                            OutputPurchase.Invoke((MethodInvoker)(() =>
                            {
                                OutputPurchase.Text += $"Товар {currGood + 1} закончился. Купили {goods[currGood]} штук вместо {currQuantity}." + Environment.NewLine;
                            }));
                            infoGoods[currGood, 0] += goods[currGood];
                            goods[currGood] = 0;
                            continue;
                        }
                        goods[currGood] -= currQuantity;
                        infoGoods[currGood, 0] += currQuantity;
                        OutputPurchase.Invoke((MethodInvoker)(() =>
                        {
                            OutputPurchase.Text += $"Куплен товар {currGood + 1} в количестве {currQuantity}  штук." + Environment.NewLine;
                        }));
                    }
                    CanceledOrders.Add(currDays, countCanceledOrders);
                    OutputPurchase.Invoke((MethodInvoker)(() =>
                    {
                        OutputStatistic.Text += $"День {currDays + 1}. Отмененных заказов: {countCanceledOrders}" + Environment.NewLine;
                    }));

                    if (countCanceledOrders > (countCustomer * 0.3))
                    {
                        minimumQuantity = Convert.ToInt32(minimumQuantity * 1.3);
                        procurementSize = Convert.ToInt32(procurementSize * 1.3);
                        ChangeProcurementSize.Invoke((MethodInvoker)(() =>
                        {
                            ChangeProcurementSize.Text = procurementSize.ToString();
                        }));
                        ChangeMinKol.Invoke((MethodInvoker)(() =>
                        {
                            ChangeMinKol.Text = minimumQuantity.ToString();
                        }));
                    }


                    var rezult = goods.FirstOrDefault(x => x.Value > minimumQuantity * 2);
                    if (rezult.Value != 0)
                    {
                        minimumQuantity = Convert.ToInt32(minimumQuantity * 0.9);
                        procurementSize = Convert.ToInt32(procurementSize * 0.9);
                        ChangeProcurementSize.Invoke((MethodInvoker)(() =>
                        {
                            ChangeProcurementSize.Text = procurementSize.ToString();
                        }));
                        ChangeMinKol.Invoke((MethodInvoker)(() =>
                        {
                            ChangeMinKol.Text = minimumQuantity.ToString();
                        }));
                    }
                }             

                int TotalPurchase = 0;
                int TotalUnredeemed = 0;
                for (int i = 0; i < kolTypesGoods; i++)
                {
                    TotalPurchase += infoGoods[i, 0];
                    TotalUnredeemed += infoGoods[i, 2];
                    OutputInfoGoods.Invoke((MethodInvoker)(() =>
                    {
                        OutputInfoGoods.Text += $"Товар {i + 1}" + Environment.NewLine;
                        OutputInfoGoods.Text += $"Продано {infoGoods[i, 0]} шт." + Environment.NewLine;
                        OutputInfoGoods.Text += $"Заказано {infoGoods[i, 1]} шт." + Environment.NewLine;
                        OutputInfoGoods.Text += $"Отменено {infoGoods[i, 2]} шт." + Environment.NewLine;
                    }));
                }
                double percentageOfSales = (double)TotalPurchase / (TotalUnredeemed + TotalPurchase);  
                OutputPurchase.Invoke((MethodInvoker)(() =>
                {
                    OutputInfoGoods.Text += $"Обеспечено процентов заявок: {percentageOfSales}" + Environment.NewLine;
                }));
            });

        }

    }
}
