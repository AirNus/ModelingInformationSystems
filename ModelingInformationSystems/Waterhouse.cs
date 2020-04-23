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
    // Класс для вывода информации в текстбоксы основной формы
    class OutputInTextBox
    {
        // Текстбокс для информации о покупках в течении дня
        internal TextBox OutputPurchase;
        // Текстбокс для итоговой информации о покупках закупках провалах
        internal TextBox OutputInfoGoods;
        // Текстбокс для вывода информации об изменении параметров по товарам
        internal TextBox OutputStatistic;
    }
    // Класс для передачи начальных параметров из основной формы
    class ParamForModeling
    {
        // Принимает в себя заданный способ генерации рандомных чисел
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
    // Класс для хранения информации о продуктах
    class Product
    {
        // Номер продукта - Имя
        internal int number;
        // Количество данного продукта на складе
        internal int kol { set; get; }
        // Объем закупок данного товара с завода
        internal int procurement { get; set; }
        // Минимальное количество данного товара до закупки
        internal int minQuantity { get; set; }
    }
    // Класс для хранении информации о продажах, закупках и отменах для каждого товара
    class InfoProduct
    {
        // Номер товара - Имя
        internal int numberProduct;
        // Количество покупок данного товара
        internal int purchase { get; set; }
        // Количество закупок данного товара с завода
        internal int procurement { get; set; }
        // Количество некупленных товаров
        internal int shortage { get; set; }
    }
    // Класс в котором реализуется моделирование работы оптового склада
    class Waterhouse
    {
        // Моделирование работы оптового склада в заданном периоде (Асинхронный метод)
        static internal Task AsyncModelingWork(object Param, object Output)
        {
            return Task.Run(() =>
            {
                // Принимаем обьект, содержащий в себе стартовые значения
                ParamForModeling startParam = (ParamForModeling) Param;
                // Принимаем объект, содержащий в себе текстбоксы в которые будет происходить вывод
                OutputInTextBox output = (OutputInTextBox) Output;
                // Здесь хранятся объекты класса InfoProduct по каждому товару
                List<InfoProduct> infoProducts = new List<InfoProduct>();
                // Здесь хранятся объекты класса Product для каждого товара по 1
                List<Product> products = new List<Product>();
                // Заполняем обе коллекции под каждый товар
                for (int i = 0; i < startParam.kolTypesGoods; i ++)
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
                // Здесь хранится количество отмененных заказов для каждого товара
                Dictionary<int, int> canceledOrdersProduct = new Dictionary<int, int>();
                for(int i = 0; i < startParam.kolTypesGoods; i++)
                {
                    canceledOrdersProduct.Add(i, 0);
                }

                // Счетчик общего количества отмененных товаров
                int canceledOrder = 0;

                // Цикл для прохода по заданным дням
                for (int currDay = 0; currDay < startParam.days; currDay++)
                {
                    // Выводим на основную форму текущий день
                    output.OutputPurchase.Invoke((MethodInvoker)(() => 
                    {
                        output.OutputPurchase.Text += "День " + (currDay + 1) + Environment.NewLine;
                    }));

                    // Обнуляем количество отмененных заказов для каждого товара
                    for (int i = 0; i < canceledOrdersProduct.Count; i++)
                    {
                        canceledOrdersProduct[i] = 0;
                    }

                    // Привоз нового товара тех позиций где текущее количество меньше параметра: "Минимальное количество на складе"
                    for (int i = 0; i < products.Count; i++)
                    {
                        if(products[i].kol <= products[i].minQuantity)
                        {
                            products[i].kol += products[i].procurement;
                            infoProducts[i].procurement += products[i].procurement;
                        }
                    }
                    // Покупки клиентами товаров
                    for (int i = 0; i < startParam.countCustomer;i++)
                    {
                        // Генерируем число Видов товара который купит данный клиент
                        int kolTypesProduct = (int)startParam.generate.GenerateNumber(maximumTypesProducts);
                        // Если ноль то пропускаем данного клиента
                        if (kolTypesProduct == 0)
                            continue;
                        for(int type = 0; type < kolTypesProduct; type++)
                        {
                            // Генерируем номер продукта который в данный момент купит клиент
                            int currProduct = (int)startParam.generate.GenerateNumber(startParam.kolTypesGoods);
                            // Генерируем количество выбранного товара
                            int currQuantity = (int)startParam.generate.GenerateNumber(startParam.kolPurchaseCustomer);
                            // Если выпало 0 пропускаем данный товар
                            if (currQuantity == 0)
                                continue;
                            // Если клиент хочет купить больше чем у нас есть
                            if (products[currProduct].kol < currQuantity)
                            {
                                // Сохраняем количество недокупленных товаров
                                infoProducts[currProduct].shortage += currQuantity - products[currProduct].kol;
                                // Сохраняем количество которое все таки удалось купить
                                infoProducts[currProduct].purchase += products[currProduct].kol;
                                // Выводи сообщение о неудачной продаже
                                output.OutputPurchase.Invoke((MethodInvoker)( () => 
                                {
                                    output.OutputPurchase.Text += $"Товар {currProduct +1} закончился. Купили {products[currProduct].kol} шт. вместо {currQuantity}" + Environment.NewLine;
                                }));
                                // Этого товара больше нет
                                products[currProduct].kol = 0;
                                // +1 неудовлетворенный заказ
                                canceledOrder++;
                                // Указываем что этот заказ пришелся на данный товар
                                canceledOrdersProduct[currProduct]++;
                                continue;
                            }
                            // Если товара хватает выводим сообщение о покупке
                            output.OutputPurchase.Invoke((MethodInvoker) ( () => 
                            {
                                output.OutputPurchase.Text += $"Куплен товар {currProduct +1} в количестве: {currQuantity} шт. " + Environment.NewLine;
                            }));
                            // Сохраняем количество купленных товаров
                            infoProducts[currProduct].purchase += currQuantity;
                            // Уменьшаем количество текущих товаров
                            products[currProduct].kol -= currQuantity;
                        }
                    }
                    
                    // Изменение параметров: "Мин. количество товара" и "объем закупок"
                    for (int i = 0; i < products.Count; i++)
                    {
                        // Если у данного товара сегодня было 30% неудовлетворенных заказов
                        if (canceledOrdersProduct[i] > (startParam.countCustomer * 0.3))
                        {
                            // Увеличиваем оба параметра на 30%
                            products[i].procurement = Convert.ToInt32(products[i].procurement * 1.3);
                            products[i].minQuantity = Convert.ToInt32(products[i].minQuantity * 1.3);
                        }
                        // Если фактический объем превышает минимальные более чем в два раза
                        else if (products[i].kol > products[i].minQuantity * 2)
                        {
                            // Уменьшаем оба параметра на 5%
                            products[i].procurement = Convert.ToInt32(products[i].procurement * 0.95);
                            products[i].minQuantity = Convert.ToInt32(products[i].minQuantity * 0.95);
                        }
                    }
                    
                }
                // Переменные для подсчета общего количество проданных и непроданных товаров
                int TotalPurchase = 0;
                int TotalShortage = 0;
                for( int i = 0; i < infoProducts.Count; i++)
                {
                    TotalPurchase += infoProducts[i].purchase;
                    TotalShortage += infoProducts[i].shortage;
                    // Выводим информацию по каждому товару
                    output.OutputInfoGoods.Invoke((MethodInvoker)(() => 
                    {
                        output.OutputInfoGoods.Text += $"Товар {i +1}" + Environment.NewLine;
                        output.OutputInfoGoods.Text += $"Купили {infoProducts[i].purchase} шт." + Environment.NewLine;
                        output.OutputInfoGoods.Text += $"Заказали {infoProducts[i].procurement} шт." + Environment.NewLine;
                        output.OutputInfoGoods.Text += $"Недокупили {infoProducts[i].shortage} шт." + Environment.NewLine;
                    }));
                }
                // Вычисляем процент купленных товаров от общего числа заказов
                double percentRealize = (double)TotalPurchase / (TotalPurchase + TotalShortage);
                // Выводим информацию о проценте реализации и общем количестве неудовлетворенных товаров
                output.OutputInfoGoods.Invoke((MethodInvoker)(() =>
                {
                    output.OutputInfoGoods.Text += $"Реализовано {Math.Round(percentRealize,4)}%" + Environment.NewLine;
                    output.OutputInfoGoods.Text += $"Всего неудовлетворительных заказов: {canceledOrder}";
                }));
                // Выводим измененные параметры для каждого товара
                for (int i = 0; i < products.Count; i++)
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
