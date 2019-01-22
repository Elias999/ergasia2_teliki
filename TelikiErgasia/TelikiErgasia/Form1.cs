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
    public partial class Form1 : Form
    {
        public int apotelesmata(int num1, int num2, string pra3i)
        {
            if (pra3i == "+")
                return num1 + num2;
            else if (pra3i == "-")
                return num1 - num2;
            else if (pra3i == "*")
                return num1 * num2;
            else
                return num1 / num2;
        }

        int cnt=60; //sec
        bool over = false;
        int mm = 2; //min
        public Form1()
        {
            InitializeComponent();

            ques[] questions = new ques[10];//Δημιουργεία ενός πίνακα με αντικείμενα
            Random rnd = new Random();
            //Δημιουργία πίνακα με τυχαιούς αριθμούς 
            int[] rando_ints = new int[20];
            for (int i = 20; i < 20; i++)
            {
                rando_ints[i] = 4;
            }
            //Λίστα με τους operators
            var oper = new List<string> { "+", "-", "*", "/" };
            //λιστα με ολα τα υπάρχοντα labels ώστε η τιμές τους να αλλαζουν δυναμικά
            var labels = new List<Label> { x1, x2, x3, x4, x5, x6, x7, x8, x9, x10 };
            var labelsy = new List<Label> { y1, y2, y3, y4, y5, y6, y7, y8, y9, y10 };
            var labelsp = new List<Label> { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };

            for (int i=0; i< 10; i++) { 
                questions[i] = new ques();
                //Δεν χρείαζετε να δεσμεύσω πίνακα αφού οι τιμές μένουν στα labels και μπόρω να τα πάρω όποτε θέλω
                questions[i].x = rnd.Next(125); //Ανάθεση τιμών στο x του αντικειμένου i
                questions[i].y = rnd.Next(125); //Ανάθεση τιμών στο y του αντικειμένου i
                int x = questions[i].x;
                int y = questions[i].y;

                //To label i+1 πέρνει την τιμή X απο το i αντικείμενο
                labels[i].Text = x.ToString();
                labelsy[i].Text = y.ToString();
                // Το label της πράξεις τυχαία πέρνει τυχαία μια πράξη
                labelsp[i].Text = oper[rnd.Next(0,4)];
                  

            }
 

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void sec_Tick(object sender, EventArgs e)
        {
            string time_to_write;
            if (over == false) {
                cnt--;
                time_to_write = mm.ToString() + ":" + cnt.ToString();
                time.Text = time_to_write;
                if (mm > 1) //πράσινο απο 2:00 εώς 1:00
                {
                    time.BackColor = Color.Green;
                }
                else if (mm == 1) //πορτοκαλι απο 1:00 εώς 0:30
                {
                    time.BackColor = Color.Orange;
                }
                else if( mm < 1 && cnt <= 30) // Κόκκινο απο 0:30 εώς 0
                {
                    time.BackColor = Color.Red;
                }

                if (cnt == 0 && mm == 0)
                {
                    //sec.Enabled = false;
                    time.BackColor = Color.Yellow;
                    var labelsapo = new List<NumericUpDown> { ap1, ap2, ap3, ap4, ap5, ap6, ap7, ap8, ap9, ap10 };
                    foreach (var apote in labelsapo)
                    {
                        apote.Enabled = false;
                    }
                    time.Text = "0:00";
                    over = true;
                    MessageBox.Show("Time is Over, but you can continue");
                }
                else if (cnt == 0)
                {
                    mm--;
                    cnt = 60;
                }
            }
            else
            {
                cnt++;
                if (cnt == 60)
                {
                    mm++;
                    cnt = 0;
                }
                time_to_write = mm.ToString() + ":" + cnt.ToString();
                time.Text = time_to_write;
            }


        }

        private void play_Click(object sender, EventArgs e)
        {
            var labelsapo = new List<NumericUpDown> { ap1, ap2, ap3, ap4, ap5, ap6, ap7, ap8, ap9, ap10 };
            foreach (var apote in labelsapo)
            {
                apote.Enabled = true;
            }
            sec.Enabled = true;
            play.Enabled = false;
        }

        private void time_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var labelsapo = new List<NumericUpDown> { ap1, ap2, ap3, ap4, ap5, ap6, ap7, ap8, ap9, ap10 };
            foreach (var apote in labelsapo)
            {
                apote.Enabled = false;
            }
            sec.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            calculator cal = new calculator();
            cal.Show();
        }
    }
}
