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

        int remain = 2;
        int apotyxia = 0;
        int epityxia = 0;
        //δευτερολεπτα το mm μου ,εβγαινε αλλιως
        int cnt=100; //ms
        bool over = false;
        int mm = 59; //sec
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;

            ques[] questions = new ques[10];//Δημιουργεία ενός πίνακα με αντικείμενα
            Random rnd = new Random();
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
                questions[i].y = rnd.Next(1,125); //Ανάθεση τιμών στο y του αντικειμένου i
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
                if (mm > 30) //πράσινο απο 2:00 εώς 1:00
                {
                    time.BackColor = Color.Green;
                }
                else if (mm <30 && mm>10) //πορτοκαλι απο 1:00 εώς 0:30
                {
                    time.BackColor = Color.Orange;
                }
                else if( mm < 10) // Κόκκινο απο 0:30 εώς 0
                {
                    time.BackColor = Color.Red;
                }
                
                if (cnt == 0 && mm == 0)
                {
                    time.BackColor = Color.Yellow;
                    var labelsapo = new List<NumericUpDown> { ap1, ap2, ap3, ap4, ap5, ap6, ap7, ap8, ap9, ap10 };
                    foreach (var apote in labelsapo)
                    {
                        apote.Enabled = false;
                    }
                    time.Text = "0:00";
                    over = true;
                    MessageBox.Show("Time is Over, but you can try more");
                }
                else if (cnt == 0)
                {
                    mm--;
                    cnt = 100;
                }
            }
            else
            {
                var labelsapo = new List<NumericUpDown> { ap1, ap2, ap3, ap4, ap5, ap6, ap7, ap8, ap9, ap10 };
                foreach (var apote in labelsapo)
                {
                    apote.Enabled = true;
                }
                cnt++;
                if (cnt == 100)
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
            mm = 59;
            cnt = 100;
            button1.Enabled = true;
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
            sec.Enabled = false;
            check_calculations();
            var labelsapo = new List<NumericUpDown> { ap1, ap2, ap3, ap4, ap5, ap6, ap7, ap8, ap9, ap10 };
            foreach (var apote in labelsapo)
            {
                apote.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            calculator cal = new calculator();
            cal.Show();
        }
        public void apotelesmata(int num1, int num2, string pra3i,string ap,int i)
        {
            //ισως και αλλο ενα ορισμα για ποια πραξη ειναι λαθος
            //if πραξη σωστη τοτε message box πραξη σωστη,αλλιως messagebox λαθος πραξη με το σωστο αποτελεσμα
            //apotyxia++
            //epityxia++
            /*  if (num1 + num2 == Convert.ToInt32(ap))
                    MessageBox.Show("Πραξη σωστη");
                    epityxia++;
                else
                    MessageBox.Show("Πραξη λαθος");
                    apotyxia++;*/
            if (pra3i == "+")
            {
                if (num1 + num2 == Convert.ToInt32(ap))
                {
                    MessageBox.Show("Πραξη" + i + " σωστη");
                    epityxia++;
                }
                else
                {
                    MessageBox.Show("Πραξη" + i + " λαθος");
                    apotyxia++;

                }
                
            }
            else if (pra3i == "-")
            {
                if (num1 - num2 == Convert.ToInt32(ap))
                {
                    MessageBox.Show("Πραξη" + i + " σωστη");
                    epityxia++;
                }
                else
                {
                    MessageBox.Show("Πραξη" + i + " λαθος");
                    apotyxia++;

                }

            }
            else if (pra3i == "*")
            {
                if (num1 * num2 == Convert.ToInt32(ap))
                {
                    MessageBox.Show("Πραξη" + i + " σωστη");
                    epityxia++;
                }
                else
                {
                    MessageBox.Show("Πραξη" + i + " λαθος");
                    apotyxia++;

                }

            }
            else
            {
                if (num1 / num2 == Convert.ToInt32(ap))
                {
                    MessageBox.Show("Πραξη" + i + " σωστη");
                    epityxia++;
                }
                else
                {
                    MessageBox.Show("Πραξη" + i + " λαθος");
                    apotyxia++;

                }
            }
        }
        //με if ελεγω καθε πραξη xi,yi αν ειναι ιδιο με τον αριθμο στο numeric
        private void check_calculations()
        {
            //labelsy[0];
            //questions[0].y
            //var y1 = labelsy.ElementAt(0);
            play.Enabled = true;
            button1.Enabled = false;
            int x1 = Convert.ToInt32(this.x1.Text);
            int x2 = Convert.ToInt32(this.x2.Text);
            int x3 = Convert.ToInt32(this.x3.Text);
            int x4 = Convert.ToInt32(this.x4.Text);
            int x5 = Convert.ToInt32(this.x5.Text);
            int x6 = Convert.ToInt32(this.x6.Text);
            int x7 = Convert.ToInt32(this.x7.Text);
            int x8 = Convert.ToInt32(this.x8.Text);
            int x9 = Convert.ToInt32(this.x9.Text);
            int x10 = Convert.ToInt32(this.x10.Text);

            int y1 = Convert.ToInt32(this.y1.Text);
            int y2 = Convert.ToInt32(this.y2.Text);
            int y3 = Convert.ToInt32(this.y3.Text);
            int y4 = Convert.ToInt32(this.y4.Text);
            int y5 = Convert.ToInt32(this.y5.Text);
            int y6 = Convert.ToInt32(this.y6.Text);
            int y7 = Convert.ToInt32(this.y7.Text);
            int y8 = Convert.ToInt32(this.y8.Text);
            int y9 = Convert.ToInt32(this.y9.Text);
            int y10 = Convert.ToInt32(this.y10.Text);

            double a1 = Convert.ToDouble(this.ap1.Text);
            double a2 = Convert.ToDouble(this.ap1.Text);
            double a3 = Convert.ToDouble(this.ap1.Text);
            double a4 = Convert.ToDouble(this.ap1.Text);
            double a5 = Convert.ToDouble(this.ap1.Text);
            double a6 = Convert.ToDouble(this.ap1.Text);
            double a7 = Convert.ToDouble(this.ap1.Text);
            double a8 = Convert.ToDouble(this.ap1.Text);
            double a9 = Convert.ToDouble(this.ap1.Text);
            double a10 = Convert.ToDouble(this.ap1.Text);
            
            apotelesmata(x1, y1, p1.Text, ap1.Text,1);
            apotelesmata(x2, y2, p2.Text, ap2.Text, 2);
            apotelesmata(x3, y3, p3.Text, ap3.Text, 3);
            apotelesmata(x4, y4, p4.Text, ap4.Text, 4);
            apotelesmata(x5, y5, p5.Text, ap5.Text, 5);
            apotelesmata(x6, y6, p6.Text, ap6.Text, 6);
            apotelesmata(x7, y7, p7.Text, ap7.Text, 7);
            apotelesmata(x8, y8, p8.Text, ap8.Text, 8);
            apotelesmata(x9, y9, p9.Text, ap9.Text, 9);
            apotelesmata(x10, y10, p10.Text, ap10.Text, 10);
            int xronos;
            if (over)
            {
                xronos = 60 + mm;
                MessageBox.Show("Χρονος ολοκληρωσης test:" + xronos + "sec" + "\nΑποτυχιες:" + apotyxia + "\nEπιτυχιες:" + epityxia);
                apotyxia = 0;
                epityxia = 0;
            }
            else
            {
                xronos = 60 - mm;
                MessageBox.Show("Χρονος ολοκληρωσης test:" + xronos + "sec" + "\nΑποτυχιες:" + apotyxia + "\nEπιτυχιες:" + epityxia);
                apotyxia = 0;
                epityxia = 0;
            }
        }

        private void hint_Click(object sender, EventArgs e)
        {
            if(remain == 2)
            {
                MessageBox.Show("Μπορειτε να χρησιμοποιησετε το κομπιουτερακι για τις πραξεις οσο τρεχει  χρονος ");
            }
            else if (remain == 1)
            {
                MessageBox.Show("Oλα τα αποτελεσματα πρεπει να δωθουν σε ακεραιο ");
            }
            else 
            {
                MessageBox.Show("Σας δοθηκαν οι χρησιμες πληροφροιες για την εφαρμογη");
            }
            remain--;
        }
    }
}
//πρεπει να ξανααλλαζουν οι αριθμοι με το δευτερο ξεκινηστε το quiz(oxi)
//να βαλω λειτουργια οταν ο χρονος 0 το ατομο να μπορει να συνεχισει το τεστ,παει με χρι 0.1 και ετσι δεν γινεται το over true για να μπει στο else 
//κλασεις
//εχει θεμα οταν το y μεγαλυτερο του x στην διαιρεση(hint οτι πρεπει να ειναι ακεραια τα αποτελεσματτα)
//να αλλαζω τα hint
//CLASS ME TA METHOD GIA TIS PRAXEIS

//CLASS ME METHOD GIA TA CALCULATION KAI HINTS    
//EXCEPTION AN TO NUMERIC ΕΙΝΑΙ ΚΕΝΟ
//ΧΡΟΝΟΣ ΑΝ ΠΕΡΑΣΕΙ ΤΟ ΧΡΟΝΟΜΕΤΡΟ ΤΟΥ 60    ok
