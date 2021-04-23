using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //public constant declaration and assignments
        public const double HamburgerPrice = 6.95;
        public const double PizzaPrice = 5.95;
        public const double SaladPrice = 4.95;
        //public variable declarations
        public double mcPrice;
        public double addOnPrice;

        // at the start 
        private void Form1_Load(object sender, EventArgs e)
        {
            radioBtnHamb.Checked = true;
            checkBox1.Text = "Lettuce, tomato, and onions";
            checkBox2.Text = "Ketchup, mustard, and mayo";
            checkBox3.Text = "French fries";
            groupBox2.Text = "Add - on items($.75/each)";
        }

        //radio buttons
        private void radioBtnHamb_CheckedChanged(object sender, EventArgs e)
        {
            //assignments
            mcPrice = HamburgerPrice;
            addOnPrice = .75;

            groupBox2.Text = "Add - on items($.75/each)";
            checkBox1.Text = "Lettuce, tomato, and onions";
            checkBox2.Text = "Ketchup, mustard, and mayo";
            checkBox3.Text = "French fries";
        }

        private void radioBtnPizza_CheckedChanged(object sender, EventArgs e)
        {
            //assignments
            mcPrice = PizzaPrice;
            addOnPrice = .50;

            groupBox2.Text = "Add - on items($.50/each)";
            checkBox1.Text = "Pepperoni";
            checkBox2.Text = "Sausage";
            checkBox3.Text = "Olives";
        }

        private void radioBtnSalad_CheckedChanged(object sender, EventArgs e)
        {
            //assignments
            mcPrice = SaladPrice;
            addOnPrice = .25;

            groupBox2.Text = "Add - on items($.25/each)";
            checkBox1.Text = "Croutons";
            checkBox2.Text = "Bacon bits";
            checkBox3.Text = "Bread sticks";
        }


        //Place Order Button
        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            //local declarations
            double payAmount;
            double addOnPriceTot;
            double Tax;
            int addOnNum;
            double Subtotal;

            // addOnNum assignment         
            if (checkBox1.Checked == true & checkBox2.Checked == false & checkBox3.Checked == false | checkBox1.Checked == false & 
                checkBox2.Checked == true & checkBox3.Checked == false | checkBox1.Checked == false & checkBox2.Checked == false & checkBox3.Checked == true)
                addOnNum = 1;
            else if (checkBox1.Checked == true & checkBox2.Checked == true & checkBox3.Checked == false | checkBox1.Checked == true & checkBox2.Checked == false 
                & checkBox3.Checked == true | checkBox1.Checked == false & checkBox2.Checked == true & checkBox3.Checked == true)
                addOnNum = 2;
            else if (checkBox1.Checked == true & checkBox2.Checked == true & checkBox3.Checked == true)
                addOnNum = 3;
            else
                addOnNum = 0;

            //add on price total calculation
            addOnPriceTot = addOnPrice * addOnNum;

            //subtotal assignment/calculation
            Subtotal = mcPrice + addOnPriceTot;

            //tax calculation
            Tax = 0.05 * (mcPrice + addOnPriceTot);

            //Total price calculation
            payAmount = mcPrice + addOnPriceTot + Tax;

            //Display Output
            txtSubTot.Text = Subtotal.ToString("c"); // currency format
            txtTax.Text = Tax.ToString("c"); // currency format
            txtOrderTot.Text = payAmount.ToString("c"); // currency format

        }
        //reset button
        private void btnReset_Click(object sender, EventArgs e)
        {
            radioBtnHamb.Checked = true;
            txtSubTot.Text = "";
            txtTax.Text = "";
            txtOrderTot.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;

        }

        //Exit button
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

