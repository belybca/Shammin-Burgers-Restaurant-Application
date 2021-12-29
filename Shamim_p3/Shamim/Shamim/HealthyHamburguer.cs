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
    public class HealthyHamburguer
    {
        private Addition add5;
        private Addition add6;
        private BasicHamburguer bh = new BasicHamburguer(); 

        public HealthyHamburguer(BasicHamburguer bh) {
            this.bh = bh;
        }

        public void SetAddition5(Addition add)
        {
            add5 = add;
        }

        public void SetAddition6(Addition add)
        {
            add6 = add;
        }

        private double GetTotal()
        {
            return bh.BasePrice + (bh.GetAddition1() != null ? bh.GetAddition1().Price : 0) + (bh.GetAddition2() != null ? bh.GetAddition2().Price : 0) + (bh.GetAddition3() != null ? bh.GetAddition3().Price : 0) + (bh.GetAddition4() != null ? bh.GetAddition4().Price : 0) + (add5 != null ? add5.Price : 0) + (add6 != null ? add6.Price : 0);
        }

        public override string ToString()
        {
            String message = $"Healty hamburger on a {bh.Bread} with {bh.Meat}, price is {bh.BasePrice}\n";
            message += bh.GetAddition1() != null ? $"Added {bh.GetAddition1().Name} for an extra {bh.GetAddition1().Price}\n" : "";
            message += bh.GetAddition2() != null ? $"Added {bh.GetAddition2().Name} for an extra {bh.GetAddition2().Price}\n" : "";
            message += bh.GetAddition3() != null ? $"Added {bh.GetAddition3().Name} for an extra {bh.GetAddition3().Price}\n" : "";
            message += bh.GetAddition4() != null ? $"Added {bh.GetAddition4().Name} for an extra {bh.GetAddition4().Price}\n" : "";
            message += add5 != null ? $"Added {add5.Name} for an extra {add5.Price}\n" : "";
            message += add6 != null ? $"Added {add6.Name} for an extra {add6.Price}\n" : "";
            message += $"Total Burger price is {GetTotal()}\n";
            return message;
        }
    }
}
