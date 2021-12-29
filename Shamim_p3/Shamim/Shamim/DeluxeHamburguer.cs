using System;
namespace Shamim
{
    public class DeluxeHamburguer
    {
        private BasicHamburguer bh = new BasicHamburguer(); 

        public DeluxeHamburguer(BasicHamburguer bh) {
            this.bh = bh;
        }
        private double GetTotal()
        {
            return bh.BasePrice + (bh.GetAddition1() != null ? bh.GetAddition1().Price : 0) + (bh.GetAddition2() != null ? bh.GetAddition2().Price : 0) + (bh.GetAddition3() != null ? bh.GetAddition3().Price : 0) + (bh.GetAddition4() != null ? bh.GetAddition4().Price : 0);
        }
        public override string ToString()
        {
            String message = $"Deluxe hamburger on a {bh.Bread} with {bh.Meat}, price is {bh.BasePrice}\n";
            message += bh.GetAddition1() != null ? $"Added {bh.GetAddition1().Name} for an extra {bh.GetAddition1().Price}\n" : "";
            message += bh.GetAddition2() != null ? $"Added {bh.GetAddition2().Name} for an extra {bh.GetAddition2().Price}\n" : "";
         
            message += $"Total Burger price is {GetTotal()}\n";
            return message;
        }
    }
}
