using System;
namespace Shamim
{
    public class DeluxeHamburguer : BasicHamburguer
    {
        public DeluxeHamburguer(string bread, string meat, double price) : base(bread, meat, price) {}

        public override string ToString()
        {
            return $"Deluxe hamburger on a {bread} with {meat}, price is {basePrice}\n";
        }
    }
}
