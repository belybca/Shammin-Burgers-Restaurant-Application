namespace Shamim
{
    public interface IDeluxeHamburguerBuilder : IShaminProduct
    {
        DeluxeHamburguer build();
    }

    public class DeluxeHamburguerBuilder : IDeluxeHamburguerBuilder
    {
        private DeluxeHamburguer dh;
        private BasicHamburguer bh;

        public DeluxeHamburguerBuilder(string bread, string meat, double price)
        {
            bh = new BasicHamburguer(bread, meat, price);
            bh.SetAddition1(new Addition("Chips", 2.75));
            bh.SetAddition2(new Addition("Drink", 1.81));
            dh = new DeluxeHamburguer(bh);

        }

        public static IDeluxeHamburguerBuilder Init(string bread, string meat, double price)
        {
            return new DeluxeHamburguerBuilder(bread, meat, price);
        }

        public DeluxeHamburguer build()
        {
            return dh;
        }
    }
}