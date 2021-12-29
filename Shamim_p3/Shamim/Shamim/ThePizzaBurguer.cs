using System;
using System.Collections.Generic;
using System.Text;

namespace Shamim
{
   public class ThePizzaBurguer
   {
        private BasicHamburguer bh = new BasicHamburguer();
        private BasicPizza bp = new BasicPizza();

        public ThePizzaBurguer(BasicHamburguer bh, BasicPizza bp) {
            this.bh = bh;
            this.bp = bp;
        }
        private double GetTotal()
        {
            return bh.BasePrice +bp.BasePrice+ (bh.GetAddition1() != null ? bh.GetAddition1().Price : 0) + (bh.GetAddition2() != null ? bh.GetAddition2().Price : 0) + (bh.GetAddition3() != null ? bh.GetAddition3().Price : 0) + (bh.GetAddition4() != null ? bh.GetAddition4().Price : 0);
        }
        public override string ToString()
        {
            String message = $"The Pizza Burger top with {bh.Bread} and {bh.Meat}, on a {bp.BaseDough} base with {bp.Sauce} \nand {bp.Cheese} price is {bh.BasePrice+bp.BasePrice}\n";
            message += bh.GetAddition1() != null ? $"Added {bh.GetAddition1().Name} for an extra {bh.GetAddition1().Price}\n" : "";
            message += bh.GetAddition2() != null ? $"Added {bh.GetAddition2().Name} for an extra {bh.GetAddition2().Price}\n" : "";
          
            message += $"Total Pizza Burger price is {GetTotal()}\n";
            return message;
        }
    }
}
