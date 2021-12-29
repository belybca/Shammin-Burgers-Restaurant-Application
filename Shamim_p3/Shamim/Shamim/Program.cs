/* Group: Albelis Gregoria Becea Marrero, 
 * Rameswariben Vipul Bhoi, 
 * Soniya Sirajali Nathani, 
 * David Alfonso Vacca Buenaventura,
 * Nidhiben Oza,
 * Gabriel Paz Paiva
 * Description: Multitier Application Shamin part 3 - group work
 * Date: 12 Nov 2021
 */
using System;

namespace Shamim
{
    class Program
    {
        static void Main(string[] args)
        {
            HamburguerFactory hf = new HamburguerFactory();

            BasicHamburguer myHamburguer1 = ((IBasicHamburguerBuilder)hf.CreateHamburguer(HamburguerType.Basic, "White roll", "Sausage", 3.56)).build();
            BasicHamburguer myHamburguer2 = ((IBasicHamburguerBuilder)hf.CreateHamburguer(HamburguerType.Basic, "White roll", "Sausage", 3.56))
                .setAdd1(new Addition("Tomato", 0.27))
                .setAdd2(new Addition("Lettuce", 0.75))
                .setAdd3(new Addition("Cheese", 1.13))
                .build();
            HealthyHamburguer myHamburguer3 = ((IHealthyHamburguerBuilder)hf.CreateHamburguer(HamburguerType.Healthy, null, "Bacon", 5.67))
                .setAdd1(new Addition("Egg", 5.43))
                .setAdd2(new Addition("Lentils", 3.41))
                .build();
            DeluxeHamburguer myHamburguer4 = ((IDeluxeHamburguerBuilder)hf.CreateHamburguer(HamburguerType.Delux, "White roll", "Sausage & Bacon", 14.54)).build();

            Console.WriteLine(myHamburguer1.ToString());
            Console.WriteLine(myHamburguer2.ToString());
            Console.WriteLine(myHamburguer3.ToString());
            Console.WriteLine(myHamburguer4.ToString());


            // Pizzas
            PizzaFactory pf = new PizzaFactory();

            BasicPizza myPizza1 = ((IHawaianPizzaBuilder)pf.CreatePizza(PizzaType.Hawaian, null,null,"Thin Crust", "Tomato Sauce", "Mozz", 4.39)).build();
            BasicPizza myPizza2 = ((IHawaianPizzaBuilder)pf.CreatePizza(PizzaType.Hawaian, null, null, "Thin Crust", "Tomato Sauce", "Mozz", 4.39))
                .setAdd1(new Addition("Bacon", 2.50))
                .setAdd2(new Addition("Pinneaple", 1.75))
                .setAdd3(new Addition("Ham", 2.50))
                .build();
            BasicPizza myPizza3 = ((IVegetarianPizzaBuilder)pf.CreatePizza(PizzaType.Vegetarian,  null, null, "Regular Crust", "White Sauce", "Chedd", 4.39)).build();
            BasicPizza myPizza4 = ((IVegetarianPizzaBuilder)pf.CreatePizza(PizzaType.Vegetarian, null, null, "Thin Crust", "Tomato Sauce", "Mozz", 4.39))
                .setAdd1(new Addition("Peppers", 1.50))
                .setAdd2(new Addition("Onion", 1.75))
                .setAdd3(new Addition("Olives", 1.80))
                .build();
            BasicPizza myPizza5 = ((IVegetarianPizzaBuilder)pf.CreatePizza(PizzaType.Vegetarian, null, null, "Regular Crust", "Tomato Sauce", "Mozz", 4.39))
               .setAdd1(new Addition("Peppers", 1.50))
               .setAdd2(new Addition("Onion", 1.75))
               .setAdd3(new Addition("Jalapeno", 2.00))
               .setAdd4(new Addition("Artichoke", 1.80))
               .build();
            ThePizzaBurguer myPizza6 = ((IPizzaBurguerBuilder)pf.CreatePizza(PizzaType.PizzaBurger, "Pizza Crust", "Ground Beef", "Thin Crust", "Tomato Sauce", "Mozz", 4.39)).build();

            Console.WriteLine(myPizza1.ToString());
            Console.WriteLine(myPizza2.ToString());
            Console.WriteLine(myPizza3.ToString());
            Console.WriteLine(myPizza4.ToString());
            Console.WriteLine(myPizza5.ToString());
            Console.WriteLine(myPizza6.ToString());

        }
    }
}
