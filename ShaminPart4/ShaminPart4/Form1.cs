using Shamim;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShaminPart4
{
    

    public partial class frmShamin : Form
    {

       
        Dictionary<string,double> itemsPrice = new Dictionary<string, double>() { { "Tomato",1.25},{ "Lettuce",1.5},{ "Bacon",2.75},{ "Pickle",1.67},{ "Pepper",2.00},{ "Egg",2.25} };
        List<Object> hamburgerList = new List<Object>();
        private readonly ShaminBurguersEntities shaminEmtities;

        List<string> additions = new List<string>();
        String burgerType = "";
        AbstractFactory f1 = AbstractFactory.getFactory(Product.Hamburger);

        Sale tableSale = new Sale();

        Decimal totalOrderPrice = 0;
        public frmShamin()
        {
            InitializeComponent();
            shaminEmtities = new ShaminBurguersEntities();
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
           
            
            switch (burgerType) {
                case "Basic Burguer":
                    txtReceipt.Text = basicHamburgerOrder().ToString();
                    
                    break;
                case "Healty Burguer":
                    txtReceipt.Text = HealtyHamburgerOrder().ToString();

                    break;
                case "Deluxe Burguer":
                   
                    txtReceipt.Text = deluxeOrder().ToString();
                    break;
            }

            
            btnBasicB.Enabled = btnDeluxeB.Enabled =btnHealty.Enabled= true;
            Bacon.Enabled = Pickle.Enabled = Tomato.Enabled = Lettuce.Enabled = Egg.Enabled = Pepper.Enabled = true;

            additions.Clear();
        }

       
        private void btnBurger_Click(object sender, EventArgs e)
        {
            Button burgertype = (Button)sender;

            burgerType = burgertype.Text;
            txtReceipt.Text = burgerType;

            switch (burgerType) {
                case "Basic Burguer":
                    Pickle.Enabled = Pepper.Enabled = btnHealty.Enabled = btnDeluxeB.Enabled = false;
                    Egg.Enabled = Bacon.Enabled = Lettuce.Enabled = Tomato.Enabled = true;
                    break;
                case "Healty Burguer":
                     btnBasicB.Enabled = btnDeluxeB.Enabled = false;
                    Egg.Enabled = Bacon.Enabled = Lettuce.Enabled = Tomato.Enabled = Pepper.Enabled = Pickle.Enabled = true;
                    break;
                case "Deluxe Burguer":
                    Egg.Enabled = Bacon.Enabled = Lettuce.Enabled = Tomato.Enabled= Pickle.Enabled = Pepper.Enabled = btnHealty.Enabled = btnBasicB.Enabled = false;
                    break;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;
           
            btnClicked.Enabled = false;
            additions.Add(btnClicked.Name);
         
            
        }
        DeluxeHamburguer deluxeOrder() {
            DeluxeHamburger deluxeHamTable = new DeluxeHamburger();
            DeluxeHamburguer myHamburguerdeluxe = ((IDeluxeHamburguerBuilder)((HamburguerFactory)f1).CreateProductNoVeg("White roll", "Sausage & Bacon", 14.54)).build();
            hamburgerList.Add(myHamburguerdeluxe);
            deluxeHamTable.meat = "Sausage & Bacon";
            deluxeHamTable.bread = "White roll";
            deluxeHamTable.price = Convert.ToDecimal(14.54);
            deluxeHamTable.id_sale = tableSale.id_sale;
            shaminEmtities.DeluxeHamburgers.Add(deluxeHamTable);

            totalOrderPrice = totalOrderPrice + (decimal)deluxeHamTable.price;
            return myHamburguerdeluxe;

        }
        BasicHamburguer basicHamburgerOrder()
        {
            BasicHamburger basichamTable = new BasicHamburger();
            
            BasicHamburguer myHamburguer=null;
            int i = additions.Count;
            switch (i)
            {
                case 0:
                    myHamburguer = ((IBasicHamburguerBuilder)((HamburguerFactory)f1).CreateProductBasic("White roll", "Beef patty", 3.56)).build();
                    hamburgerList.Add(myHamburguer);
                    basichamTable.add1 = "";
                    basichamTable.add2 = "";
                    basichamTable.add3 = "";
                    basichamTable.add4 = "";
                    basichamTable.bread = "White roll";
                    basichamTable.meat = "Beef patty";
                    basichamTable.price = Convert.ToDecimal(3.56);
                    basichamTable.id_sale = tableSale.id_sale;
                    shaminEmtities.BasicHamburgers.Add(basichamTable);
                    
                    totalOrderPrice = totalOrderPrice + (decimal)basichamTable.price;
                   
                    return myHamburguer;

                case 1:
                    myHamburguer = ((IBasicHamburguerBuilder)((HamburguerFactory)f1).CreateProductBasic("White roll", "Beef patty", 3.56))
                .setAdd1(new Addition(additions[0], itemsPrice[additions[0]])).build();
                    hamburgerList.Add(myHamburguer);
                    basichamTable.add1 = additions[0];
                    basichamTable.add2 = "";
                    basichamTable.add3 = "";
                    basichamTable.add4 = "";
                    basichamTable.bread = "White roll";
                    basichamTable.meat = "Beef patty";
                    basichamTable.price = Convert.ToDecimal(3.56 + itemsPrice[additions[0]]);
                    basichamTable.id_sale = tableSale.id_sale;
                    shaminEmtities.BasicHamburgers.Add(basichamTable);
                    
                    totalOrderPrice = totalOrderPrice + (decimal)basichamTable.price;
                   
                    return myHamburguer;
                case 2:

                    myHamburguer = ((IBasicHamburguerBuilder)((HamburguerFactory)f1).CreateProductBasic("White roll", "Beef patty", 3.56))
                .setAdd1(new Addition(additions[0], itemsPrice[additions[0]]))
                .setAdd2(new Addition(additions[1], itemsPrice[additions[1]]))
                .build();
                    hamburgerList.Add(myHamburguer);
                    basichamTable.add1 = additions[0];
                    basichamTable.add2 = additions[1];
                    basichamTable.add3 = "";
                    basichamTable.add4 = "";
                    basichamTable.bread = "White roll";
                    basichamTable.meat = "Beef patty";
                    basichamTable.price = Convert.ToDecimal(3.56 + itemsPrice[additions[0]]+ itemsPrice[additions[1]]);
                    basichamTable.id_sale = tableSale.id_sale;
                    shaminEmtities.BasicHamburgers.Add(basichamTable);
                   
                    totalOrderPrice = totalOrderPrice + (decimal)basichamTable.price;
                    
                    return myHamburguer;
                case 3:
                    myHamburguer = ((IBasicHamburguerBuilder)((HamburguerFactory)f1).CreateProductBasic("White roll", "Beef patty", 3.56))
                     .setAdd1(new Addition(additions[0], itemsPrice[additions[0]]))
                     .setAdd2(new Addition(additions[1], itemsPrice[additions[1]]))
                     .setAdd3(new Addition(additions[2], itemsPrice[additions[2]]))
                     .build();
                    hamburgerList.Add(myHamburguer);
                    basichamTable.add1 = additions[0];
                    basichamTable.add2 = additions[1];
                    basichamTable.add3 = additions[2];
                    basichamTable.add4 = "";
                    basichamTable.bread = "White roll";
                    basichamTable.meat = "Beef patty";
                    basichamTable.price = Convert.ToDecimal(3.56 + itemsPrice[additions[0]] + itemsPrice[additions[1]]+ itemsPrice[additions[2]]);
                    basichamTable.id_sale = tableSale.id_sale;
                    shaminEmtities.BasicHamburgers.Add(basichamTable);
                    
                    totalOrderPrice = totalOrderPrice + (decimal)basichamTable.price;
                   
                    return myHamburguer;
                case 4:
                    myHamburguer = ((IBasicHamburguerBuilder)((HamburguerFactory)f1).CreateProductBasic("White roll", "Beef patty", 3.56))
                    .setAdd1(new Addition(additions[0], itemsPrice[additions[0]]))
                    .setAdd2(new Addition(additions[1], itemsPrice[additions[1]]))
                    .setAdd3(new Addition(additions[2], itemsPrice[additions[2]]))
                    .setAdd4(new Addition(additions[3], itemsPrice[additions[3]]))
                    .build();
                    hamburgerList.Add(myHamburguer);
                    basichamTable.add1 = additions[0];
                    basichamTable.add2 = additions[1];
                    basichamTable.add3 = additions[2];
                    basichamTable.add4 = additions[3];
                    basichamTable.bread = "White roll";
                    basichamTable.meat = "Beef patty";
                    basichamTable.price = Convert.ToDecimal(3.56 + itemsPrice[additions[0]] + itemsPrice[additions[1]] + itemsPrice[additions[2]] + itemsPrice[additions[3]]);
                    basichamTable.id_sale = tableSale.id_sale;
                    shaminEmtities.BasicHamburgers.Add(basichamTable);
                    
                    totalOrderPrice = totalOrderPrice + (decimal)basichamTable.price;
                   
                    return myHamburguer;

            }
            return myHamburguer;
        }

        BasicHamburguer HealtyHamburgerOrder()
        {
            HealtyHamburger healthyHamTable = new HealtyHamburger();
            HealthyHamburguer myHealtyHamburguer = null;
            int i = additions.Count;
           
            switch (i)
            {
                case 0:
                    myHealtyHamburguer = ((IHealthyHamburguerBuilder)((HamburguerFactory)f1).CreateProductVeg(null, "Veg-patty", 5.67)).build();
                    hamburgerList.Add(myHealtyHamburguer);
                    healthyHamTable.add1 = "";
                    healthyHamTable.add2 = "";
                    healthyHamTable.add3 = "";
                    healthyHamTable.add4 = "";
                    healthyHamTable.add5 = "";
                    healthyHamTable.add6 = "";
                    healthyHamTable.bread = "Brown rye roll";
                    healthyHamTable.meat = "Veg-patty";
                    healthyHamTable.price = Convert.ToDecimal(5.67);
                    healthyHamTable.id_sale = tableSale.id_sale;
                    shaminEmtities.HealtyHamburgers.Add(healthyHamTable);
                   
                    totalOrderPrice = totalOrderPrice + (decimal)healthyHamTable.price;
                   
                    return myHealtyHamburguer;

                case 1:
                    myHealtyHamburguer = ((IHealthyHamburguerBuilder)((HamburguerFactory)f1).CreateProductVeg(null, "Veg-patty", 5.67))
                     .setAdd1(new Addition(additions[0], itemsPrice[additions[0]])).build();
                    hamburgerList.Add(myHealtyHamburguer);
                    healthyHamTable.add1 = additions[0];
                    healthyHamTable.add2 ="";
                    healthyHamTable.add3 = "";
                    healthyHamTable.add4 = "";
                    healthyHamTable.add5 = "";
                    healthyHamTable.add6 = "";
                    healthyHamTable.bread = "Brown rye roll";
                    healthyHamTable.meat = "Veg-patty";
                    healthyHamTable.price = Convert.ToDecimal(5.67 + itemsPrice[additions[0]]);
                    healthyHamTable.id_sale = tableSale.id_sale;
                    shaminEmtities.HealtyHamburgers.Add(healthyHamTable);
                    
                    totalOrderPrice = totalOrderPrice + (decimal)healthyHamTable.price;
                   
                    return  myHealtyHamburguer;

                case 2:

                    myHealtyHamburguer = ((IHealthyHamburguerBuilder)((HamburguerFactory)f1).CreateProductVeg(null, "Veg-patty", 5.67))
                .setAdd1(new Addition(additions[0], itemsPrice[additions[0]]))
                .setAdd2(new Addition(additions[1], itemsPrice[additions[1]]))
                .build();
                    hamburgerList.Add(myHealtyHamburguer);
                    healthyHamTable.add1 = additions[0];
                    healthyHamTable.add2 = additions[1];
                    healthyHamTable.add3 = "";
                    healthyHamTable.add4 = "";
                    healthyHamTable.add5 = "";
                    healthyHamTable.add6 = "";
                    healthyHamTable.bread = "Brown rye roll";
                    healthyHamTable.meat = "Veg-patty";
                    healthyHamTable.price = Convert.ToDecimal(5.67 + itemsPrice[additions[0]] + itemsPrice[additions[1]] );
                    healthyHamTable.id_sale = tableSale.id_sale;
                    shaminEmtities.HealtyHamburgers.Add(healthyHamTable);
                    
                    totalOrderPrice = totalOrderPrice + (decimal)healthyHamTable.price;
                    
                    return myHealtyHamburguer;
                case 3:
                    myHealtyHamburguer = ((IHealthyHamburguerBuilder)((HamburguerFactory)f1).CreateProductVeg(null, "Veg-patty", 5.67))
                .setAdd1(new Addition(additions[0], itemsPrice[additions[0]]))
                .setAdd2(new Addition(additions[1], itemsPrice[additions[1]]))
                .setAdd3(new Addition(additions[2], itemsPrice[additions[2]]))
                .build();
                    hamburgerList.Add(myHealtyHamburguer);
                    healthyHamTable.add1 = additions[0];
                    healthyHamTable.add2 = additions[1];
                    healthyHamTable.add3 = additions[2];
                    healthyHamTable.add4 ="";
                    healthyHamTable.add5 = "";
                    healthyHamTable.add6 = "";
                    healthyHamTable.bread = "Brown rye roll";
                    healthyHamTable.meat = "Veg-patty";
                    healthyHamTable.price = Convert.ToDecimal(5.67 + itemsPrice[additions[0]] + itemsPrice[additions[1]] + itemsPrice[additions[2]]);
                    healthyHamTable.id_sale = tableSale.id_sale;
                    shaminEmtities.HealtyHamburgers.Add(healthyHamTable);
                    
                    totalOrderPrice = totalOrderPrice + (decimal)healthyHamTable.price;
                    
                    return myHealtyHamburguer;

                case 4:
                    myHealtyHamburguer = ((IHealthyHamburguerBuilder)((HamburguerFactory)f1).CreateProductVeg(null, "Veg-patty", 5.67))
                .setAdd1(new Addition(additions[0], itemsPrice[additions[0]]))
                .setAdd2(new Addition(additions[1], itemsPrice[additions[1]]))
                .setAdd3(new Addition(additions[2], itemsPrice[additions[2]]))
                .setAdd4(new Addition(additions[3], itemsPrice[additions[3]]))
                .build();
                    hamburgerList.Add(myHealtyHamburguer);
                    healthyHamTable.add1 = additions[0];
                    healthyHamTable.add2 = additions[1];
                    healthyHamTable.add3 = additions[2];
                    healthyHamTable.add4 = additions[3];
                    healthyHamTable.add5 = "";
                    healthyHamTable.add6 = "";
                    healthyHamTable.bread = "Brown rye roll";
                    healthyHamTable.meat = "Veg-patty";
                    healthyHamTable.price = Convert.ToDecimal(5.67 + itemsPrice[additions[0]] + itemsPrice[additions[1]] + itemsPrice[additions[2]] + itemsPrice[additions[3]]);
                    healthyHamTable.id_sale = tableSale.id_sale;
                    shaminEmtities.HealtyHamburgers.Add(healthyHamTable);
                    
                    totalOrderPrice = totalOrderPrice + (decimal)healthyHamTable.price;
                   
                    return myHealtyHamburguer;
                case 5:

                    myHealtyHamburguer = ((IHealthyHamburguerBuilder)((HamburguerFactory)f1).CreateProductVeg(null, "Veg-patty", 5.67))
                .setAdd1(new Addition(additions[0], itemsPrice[additions[0]]))
                .setAdd2(new Addition(additions[1], itemsPrice[additions[1]]))
                .setAdd3(new Addition(additions[2], itemsPrice[additions[2]]))
                .setAdd4(new Addition(additions[3], itemsPrice[additions[3]]))
                .setAdd5(new Addition(additions[4], itemsPrice[additions[4]]))
                .build();
                    hamburgerList.Add(myHealtyHamburguer);
                    healthyHamTable.add1 = additions[0];
                    healthyHamTable.add2 = additions[1];
                    healthyHamTable.add3 = additions[2];
                    healthyHamTable.add4 = additions[3];
                    healthyHamTable.add5 = additions[4];
                    healthyHamTable.add6 = "";
                    healthyHamTable.bread = "Brown rye roll";
                    healthyHamTable.meat = "Veg-patty";
                    healthyHamTable.price = Convert.ToDecimal(5.67 + itemsPrice[additions[0]] + itemsPrice[additions[1]] + itemsPrice[additions[2]] + itemsPrice[additions[3]] + itemsPrice[additions[4]]);
                    healthyHamTable.id_sale = tableSale.id_sale;
                    shaminEmtities.HealtyHamburgers.Add(healthyHamTable);
                   
                    totalOrderPrice = totalOrderPrice + (decimal)healthyHamTable.price;
                   
                    return myHealtyHamburguer;
                case 6:
                    myHealtyHamburguer = ((IHealthyHamburguerBuilder)((HamburguerFactory)f1).CreateProductVeg(null, "Veg-patty", 5.67))
                .setAdd1(new Addition(additions[0], itemsPrice[additions[0]]))
                .setAdd2(new Addition(additions[1], itemsPrice[additions[1]]))
                .setAdd3(new Addition(additions[2], itemsPrice[additions[2]]))
                .setAdd4(new Addition(additions[3], itemsPrice[additions[3]]))
                .setAdd5(new Addition(additions[4], itemsPrice[additions[4]]))
                .setAdd6(new Addition(additions[5], itemsPrice[additions[5]]))
                .build();
                    hamburgerList.Add(myHealtyHamburguer);
                    healthyHamTable.add1 = additions[0];
                    healthyHamTable.add2 = additions[1];
                    healthyHamTable.add3 = additions[2];
                    healthyHamTable.add4 = additions[3];
                    healthyHamTable.add5 = additions[4];
                    healthyHamTable.add6 = additions[5];
                    healthyHamTable.bread = "Brown rye roll";
                    healthyHamTable.meat = "Veg-patty";
                    healthyHamTable.price = Convert.ToDecimal(5.67 + itemsPrice[additions[0]] + itemsPrice[additions[1]] + itemsPrice[additions[2]] + itemsPrice[additions[3]]+ itemsPrice[additions[4]]+ itemsPrice[additions[5]]);
                    healthyHamTable.id_sale = tableSale.id_sale;
                    shaminEmtities.HealtyHamburgers.Add(healthyHamTable);
                    
                    totalOrderPrice = totalOrderPrice + (decimal)healthyHamTable.price;
                   
                    return myHealtyHamburguer;

                

            }
            return myHealtyHamburguer;
        }

        private void frmShamin_Load(object sender, EventArgs e)
        {
            Egg.Enabled = Bacon.Enabled = Lettuce.Enabled = Tomato.Enabled = Pickle.Enabled = Pepper.Enabled = false;
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {

            MessageBox.Show(totalOrderPrice.ToString());
            tableSale.date = DateTime.Now;
            tableSale.total = totalOrderPrice;
            shaminEmtities.Sales.Add(tableSale);
            shaminEmtities.SaveChanges();

            foreach (Object pr in hamburgerList)
            {
                txtReceipt.Text = txtReceipt.Text + pr.ToString()+"\r\n";
            }
            
            totalOrderPrice = 0;
            hamburgerList.Clear();
            
        }

       
    }
}
