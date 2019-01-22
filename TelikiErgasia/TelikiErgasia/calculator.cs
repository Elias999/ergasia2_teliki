using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelikiErgasia
{
    public partial class calculator : Form
    {
        public calculator()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ola.Text += "3";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ola.Text += "5";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ola.Text += "7";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ola.Text += "1";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ola.Text += "2";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ola.Text += "4";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ola.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ola.Text += "8";
        }

        private void button10_Click(object sender, EventArgs e)
        {
                ola.Text += "9";
        }

        private void button4_Click(object sender, EventArgs e)
        {
                ola.Text += "0";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string last = ola.Text.Substring(ola.Text.Length - 1);
            if (last != "-" && last != "+" && last != "*" && last != "/")
                ola.Text += "+";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string last = ola.Text.Substring(ola.Text.Length - 1);
            if (last != "-" && last != "+" && last != "*" && last != "/")
                ola.Text += "-";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string last = ola.Text.Substring(ola.Text.Length - 1);
            if (last != "-" && last != "+" && last != "*" && last != "/") { 
                ola.Text += "*";
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string last = ola.Text.Substring(ola.Text.Length - 1);
            if (last != "-" && last != "+" && last != "*" && last != "/")
            {
                ola.Text += "/";
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void calculator_Load(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            string[] numbers = ola.Text.Split(new char[] { '+','-','*','/' } ); // αφαιρεί τις πράξεις απο το κομπιουτεράκι
            string[] pra = ola.Text.Split( new char[] { ' ' , '1', '2', '3', '4', '5', '6', '7', '8', '9' , '0'  } , StringSplitOptions.RemoveEmptyEntries); //αφαιρεί τους αριθμούς και τά κένα κελία του string array

            int thesi = 0; //Η πράξη που θα εκτελεστεί
            int sum = System.Convert.ToInt32(numbers[0]); //το sum έχει το αριστερότερο αριθμό η την αριστερότερη πράξη
            for (int i=0 ; i < numbers.Length-1; i++) //-1 γιατί θα κοιταμε 2 νουμέρα και θα βγαίναμε εκτός οριών
            {   if(pra[thesi] == "+")
                {
                    sum = sum + System.Convert.ToInt32(numbers[i + 1]);
                }
                else if (pra[thesi] == "-")
                {
                    sum = sum - System.Convert.ToInt32(numbers[i + 1]);
                }
                else if (pra[thesi] == "*")
                {
                    sum = sum * System.Convert.ToInt32(numbers[i + 1]);
                }
                else
                {
                    sum = sum / System.Convert.ToInt32(numbers[i + 1]);
                }
                thesi++;
            }
            MessageBox.Show(sum.ToString());
        }

        private void C_Click(object sender, EventArgs e)
        {
            ola.Text = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {   
            //Για να μην πετάει exception όταν τα έχει διαγράψει όλα
            try { 
                ola.Text = ola.Text.Remove(ola.Text.Length - 1); 
            }
            catch (System.ArgumentOutOfRangeException f)
            {
                MessageBox.Show("Διαγράφηκαν όλα");
            }
        }
    }
}
