using System;
namespace Shamim
{
   
    public class HamburguerFactory 
    {
        public HamburguerFactory()
        {
        }

        public IShaminProduct CreateHamburguer(HamburguerType type, string bread, string meat, double price)
        {
            switch (type)
            {
                case HamburguerType.Basic:
                    return BasicHamburguerBuilder.Init(bread, meat, price);
                case HamburguerType.Healthy:
                    return HealthyHamburguerBuilder.Init(meat, price);
                case HamburguerType.Delux:
                    return DeluxeHamburguerBuilder.Init(bread, meat, price);
                default:
                    return null;
            }
        }
    }
}