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

namespace ModelingInformationSystems
{
    
    class OutputInTextBox
    {      
        internal TextBox OutputPurchase;
        internal TextBox OutputInfoGoods;
        internal TextBox OutputStatistic;
    }
    class ParamForModeling
    {
        internal Uniform generate;

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
    class Product
    {
        internal int number;
        internal int kol { set; get; }
        internal int procurement { get; set; }
        internal int minQuantity { get; set; }
    }
    class InfoProduct
    {
        internal int numberProduct;
        internal int purchase { get; set; }
        internal int procurement { get; set; }
        internal int shortage { get; set; }
    }

    class Waterhouse
    {
        static Random random = new Random();
       
       
        static internal Task AsyncModelingWork(object Param, object Output)
        {
            return Task.Run(() =>
            {
                ParamForModeling startParam = (ParamForModeling) Param;
                OutputInTextBox output = (OutputInTextBox) Output;
                List<InfoProduct> infoProducts = new List<InfoProduct>();
                List<Product> products = new List<Product>();
                for(int i = 0; i < startParam.kolTypesGoods; i ++)
                {
                    products.Add(new Product {
                        number = i, 
                        kol = startParam.startKolGoods,
                        minQuantity = startParam.minimumQuantity,
                        procurement = startParam.procurementSize });
                    infoProducts.Add(new InfoProduct {
                        numberProduct = i,
                        procurement = 0,
                        purchase = 0,
                        shortage = 0});
                }
                // Максимальное количество товаров, которое может купить один клиент
                int maximumTypesProducts = Convert.ToInt32(startParam.kolTypesGoods * 0.7);
                Dictionary<int, int> canceledOrdersProduct = new Dictionary<int, int>();
                for(int i = 0; i < startParam.kolTypesGoods; i++)
                {
                    canceledOrdersProduct.Add(i, 0);
                }
                int canceledOrder = 0;
                for(int currDay = 0; currDay < startParam.days; currDay++)
                {
                    output.OutputPurchase.Invoke((MethodInvoker)(() => 
                    {
                        output.OutputPurchase.Text += "День " + (currDay + 1) + Environment.NewLine;
                    }));
                    for(int i = 0; i < canceledOrdersProduct.Count; i++)
                    {
                        canceledOrdersProduct[i] = 0;
                    }
                    for(int i = 0; i < products.Count; i++)
                    {
                        if(products[i].kol <= products[i].minQuantity)
                        {
                            products[i].kol += products[i].procurement;
                            infoProducts[i].procurement += products[i].procurement;
                        }
                    }

                    for(int i = 0; i < startParam.countCustomer;i++)
                    {
                        int kolTypesProduct = (int)startParam.generate.GenerateNumber(maximumTypesProducts);
                        if (kolTypesProduct == 0)
                            continue;
                        for(int type = 0; type < kolTypesProduct; type++)
                        {
                            int currProduct = (int)startParam.generate.GenerateNumber(startParam.kolTypesGoods);
                            int currQuantity = (int)startParam.generate.GenerateNumber(startParam.kolPurchaseCustomer);
                            if (currQuantity == 0)
                                continue;
                            if(products[currProduct].kol < currQuantity)
                            {
                                infoProducts[currProduct].shortage += currQuantity - products[currProduct].kol;
                                infoProducts[currProduct].purchase += products[currProduct].kol;
                                output.OutputPurchase.Invoke((MethodInvoker)( () => 
                                {
                                    output.OutputPurchase.Text += $"Товар {currProduct +1} закончился. Купили {products[currProduct].kol} шт. вместо {currQuantity}" + Environment.NewLine;
                                }));
                                products[currProduct].kol = 0;
                                canceledOrder++;
                                canceledOrdersProduct[currProduct]++;
                                continue;
                            }
                            output.OutputPurchase.Invoke((MethodInvoker) ( () => 
                            {
                                output.OutputPurchase.Text += $"Куплен товар {currProduct +1} в количестве: {currQuantity} шт. " + Environment.NewLine;
                            }));
                            infoProducts[currProduct].purchase += currQuantity;
                            products[currProduct].kol -= currQuantity;
                        }
                    }
                    
                    //
                    for (int i = 0; i < products.Count; i++)
                    {
                        if(canceledOrdersProduct[i] > (startParam.countCustomer * 0.3))
                        {
                            products[i].procurement = Convert.ToInt32(products[i].procurement * 1.3);
                            products[i].minQuantity = Convert.ToInt32(products[i].minQuantity * 1.3);
                        }
                        else if(products[i].kol > products[i].minQuantity * 2)
                        {
                            products[i].procurement = Convert.ToInt32(products[i].procurement * 0.95);
                            products[i].minQuantity = Convert.ToInt32(products[i].minQuantity * 0.95);
                        }
                    }
                    
                }
                int TotalPurchase = 0;
                int TotalShortage = 0;
                for( int i = 0; i < infoProducts.Count; i++)
                {
                    TotalPurchase += infoProducts[i].purchase;
                    TotalShortage += infoProducts[i].shortage;
                    output.OutputInfoGoods.Invoke((MethodInvoker)(() => 
                    {
                        output.OutputInfoGoods.Text += $"Товар {i +1}" + Environment.NewLine;
                        output.OutputInfoGoods.Text += $"Купили {infoProducts[i].purchase} шт." + Environment.NewLine;
                        output.OutputInfoGoods.Text += $"Заказали {infoProducts[i].procurement} шт." + Environment.NewLine;
                        output.OutputInfoGoods.Text += $"Недокупили {infoProducts[i].shortage} шт." + Environment.NewLine;
                    }));
                }
                double percentRealize = (double)TotalPurchase / (TotalPurchase + TotalShortage);
                output.OutputInfoGoods.Invoke((MethodInvoker)(() =>
                {
                    output.OutputInfoGoods.Text += $"Реализовано {Math.Round(percentRealize,4)}%" + Environment.NewLine;
                    output.OutputInfoGoods.Text += $"Всего неудовлетворительных заказов: {canceledOrder}";
                }));
                for(int i = 0; i < products.Count; i++)
                {
                    output.OutputStatistic.Invoke((MethodInvoker)(() =>
                    {
                        output.OutputStatistic.Text += $"Товар {i + 1}" + Environment.NewLine;
                        output.OutputStatistic.Text += $"Минимальное количество на складе {products[i].minQuantity} шт." + Environment.NewLine;
                        output.OutputStatistic.Text += $"Объем закупок {products[i].procurement} шт." + Environment.NewLine;
                    }));
                }


            });
        }

    }
}
