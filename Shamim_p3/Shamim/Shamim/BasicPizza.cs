using System;
using System.Collections.Generic;
using System.Text;

namespace Shamim
{
    public class BasicPizza
    {
        protected string baseDough;
        protected string sauce;
        protected string cheese;
        protected double basePrice;

        protected Addition add1;
        protected Addition add2;
        protected Addition add3;
        protected Addition add4;

        public BasicPizza() { }

        public BasicPizza(string baseDough, string sauce, string cheese, double price)
        {
            this.baseDough = baseDough;
            this.sauce = sauce;
            this.cheese = cheese;
            basePrice = price;
            
        }
        public string BaseDough
        {
            get { return baseDough; }
            set { baseDough = value; }
        }
        public string Sauce
        {
            get { return sauce; }
            set { sauce = value; }
        }
        public string Cheese
        {
            get { return cheese; }
            set { cheese = value; }
        }
        public double BasePrice
        {
            get { return basePrice; }
            set { basePrice = value; }
        }
        public void SetAddition1(Addition add)
        {
            add1 = add;
        }
        public Addition GetAddition1()
        {
            return add1;
        }
        public void SetAddition2(Addition add)
        {
            add2 = add;
        }
        public Addition GetAddition2()
        {
            return add2;
        }
        public void SetAddition3(Addition add)
        {
            add3 = add;
        }
        public Addition GetAddition3()
        {
            return add3;
        }
        public void SetAddition4(Addition add)
        {
            add4 = add;
        }
        public Addition GetAddition4()
        {
            return add4;
        }
        public double GetTotal()
        {
            return basePrice + (add1 != null ? add1.Price : 0) + (add2 != null ? add2.Price : 0) + (add3 != null ? add3.Price : 0) + (add4 != null ? add4.Price : 0);
        }

        public override string ToString()
        {
            String message = $"Basic Pizza on a {baseDough} with {sauce}, and {cheese} price is {basePrice}\n";
            message += add1 != null ? $"Added {add1.Name} for an extra {add1.Price}\n" : "";
            message += add2 != null ? $"Added {add2.Name} for an extra {add2.Price}\n" : "";
            message += add3 != null ? $"Added {add3.Name} for an extra {add3.Price}\n" : "";
            message += add4 != null ? $"Added {add4.Name} for an extra {add4.Price}\n" : "";
            message += $"Total Pizza price is {GetTotal()}\n";
            return message;
            
        }
    }
}