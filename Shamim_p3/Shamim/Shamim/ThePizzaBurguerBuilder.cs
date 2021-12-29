using System;
using System.Collections.Generic;
using System.Text;

namespace Shamim
{
    public interface IPizzaBurguerBuilder : IShaminProduct
    { 
        ThePizzaBurguer build();
    }
    public class ThePizzaBurguerBuilder : IPizzaBurguerBuilder
    { 
            private ThePizzaBurguer pb;
            private BasicHamburguer bh;
            private BasicPizza bp;

       public ThePizzaBurguerBuilder(string bread, string meat, string baseDough, string sauce, string cheese, double price)
       {
          bh = new BasicHamburguer(bread, meat, price);
          bh.SetAddition1(new Addition("Extra Cheese", 2.00));
          bh.SetAddition2(new Addition("Drink", 1.81));
          bp = new BasicPizza(baseDough,sauce,cheese,price);

                pb = new ThePizzaBurguer(bh,bp);

       }

       public static IPizzaBurguerBuilder Init(string bread, string meat, string baseDough, string sauce, string cheese, double price)
       {
                return new ThePizzaBurguerBuilder(bread, meat, baseDough,sauce,cheese,price);
       }

        public ThePizzaBurguer build()
        {
            return pb;
        }

    }
}
