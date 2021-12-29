using System;
using System.Collections.Generic;
using System.Text;

namespace Shamim
{
  
    public class PizzaFactory
    {

        public PizzaFactory() { }


        public IShaminProduct CreatePizza(PizzaType type, string bread, string meat, string baseDough, string sauce, string cheese, double price)
        {
            switch (type)
            {

                case PizzaType.Hawaian:
                    return HawaianPizzaBuilder.Init(baseDough, sauce, cheese, price);
                case PizzaType.Vegetarian:
                    return VegetarianPizzaBuilder.Init(baseDough, sauce, cheese, price);
                case PizzaType.PizzaBurger:
                    return ThePizzaBurguerBuilder.Init(bread, meat, baseDough, sauce, cheese, price);
                default:
                    return null;
            }
        }
    }


}