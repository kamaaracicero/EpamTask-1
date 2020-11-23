using Bakery.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace Bakery.StandartMethods
{
    internal class StandartSaver : IBakerySaver
    {
        public void Save(List<Product> products, FileStream file, Bakery.MessageHandler handler)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    foreach (Product product in products)
                    {
                        string fullcost = string.Format("{0:f3}", product.FullCost);
                        string cost = string.Format("{0:f3}", product.Cost);
                        writer.WriteLine("Name - " + product.Name + "; \n\tAmount: " + product.Amount + "; \n\tCost: " + cost + "; \n\tCalories: " + product.Calories + "; \n\tFullCost: " + fullcost + "\n");
                        writer.WriteLine(product);
                    }
                }
            }
            catch (Exception ex)
            {
                handler(ex.Message);
            }
        }
    }
}
