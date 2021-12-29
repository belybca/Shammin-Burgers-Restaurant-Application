using System;

namespace Shamim
{
    public abstract class AbstractFactory
    {
        private static HamburguerFactory hf = new HamburguerFactory();

        private static PizzaFactory pf = new PizzaFactory();

        //private static PizzaBurguerFactory pbf = new PizzaBurguerFactory();


        public static AbstractFactory getFactory(Product p)
        {
            AbstractFactory factory = null;

            switch (p)
            {

                case Product.Hamburger:
                    factory = hf;
                    break;

                case Product.Pizza:
                    factory = pf;
                    break;
               /* case Product.PizzaBurguer:
                    factory = pbf;
                    break;*/
            }

            return factory;

        }


        public abstract IShaminProduct CreateProductVeg(string bread, string meat, double price);
        public abstract IShaminProduct CreateProductNoVeg(string bread, string meat, double price);

        public static implicit operator AbstractFactory(HamburguerFactory v)
        {
            throw new NotImplementedException();
        }

        public static implicit operator AbstractFactory(PizzaFactory v)
        {
            throw new NotImplementedException();
        }

       
    }
}
