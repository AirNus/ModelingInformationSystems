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

                Dictionary<int, int> canceledOrdersProduct = new Dictionary<int, int>();
                for(int i = 0; i < startParam.kolTypesGoods; i++)
                {
                    canceledOrdersProduct.Add(i, 0);
                }
                int canceledOrder;
                for(int currDay = 0; currDay < startParam.days; currDay++)
                {
                    canceledOrder = 0;

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
                        int kolTypesProduct = random.Next(startParam.kolTypesGoods);
                        if (kolTypesProduct == 0)
                            continue;
                        for(int type = 0; type < kolTypesProduct; type++)
                        {
                            int currProduct = random.Next(startParam.kolTypesGoods);
                            int currQuantity = random.Next(startParam.kolPurchaseCustomer);
                            if (currQuantity == 0)
                                continue;
                            if(products[currProduct].kol < currQuantity)
                            {
                                infoProducts[currProduct].shortage += currQuantity - products[currProduct].kol;
                                infoProducts[currProduct].purchase += products[currProduct].kol;
                                products[currProduct].kol = 0;
                                canceledOrder++;
                                canceledOrdersProduct[currProduct]++;
                                continue;
                            }
                            infoProducts[currProduct].purchase += currQuantity;
                            products[currProduct].kol -= currQuantity;
                        }
                    }
                    
                    //
                    for (int i = 0; i < products.Count; i++)
                    {
                        if(canceledOrdersProduct[i] > (startParam.countCustomer * 0.3))
                        {

                        }
                    }
                }

            });
        }

    }
}
