using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    

    public partial class TopScores : Form
    {
        public TopScores()
        {
            InitializeComponent();
        }
        public class User_score
        {


            public string Name
            { get; set; }

            public string Score
            { get; set; }

            public string Time
            { get; set; }

            public User_score()
            {
                Name = "No data";
                Score = "No data";
                Time = "No data";
            }
            public void setproperties(int line)
            {
                string[] lines = System.IO.File.ReadAllLines("scores.sc");
                string[] meroi = lines[line].Split(' ');
                Name = meroi[0];
                Score = meroi[1];
                Time = meroi[2];
            }
        }

        private void TopScores_Load(object sender, EventArgs e)
        {
            var for_files = new for_files();
            long count = for_files.CountLines("scores.sc");
            
            //λιστα με ολα τα υπάρχοντα labels ώστε η τιμές τους να αλλαζουν δυναμικά
            var labels = new List<Label> { x1, x2, x3, x4, x5, x6, x7, x8, x9, x10 };
            var labelsy = new List<Label> { y1, y2, y3, y4, y5, y6, y7, y8, y9, y10 };
            var labelsp = new List<Label> { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
            User_score[] top_scores = new User_score[10];

            for (int i = 0; i < 10; i++) {
                top_scores[i] = new User_score();
                //Οσό ο χρήστης που γράφεται στους καλύτερους υπάρχει στο αρχείο πέρνει στοιχεία από το αρχείο αλλίως χρησημοποιεί της προκαθορισμένες τιμές
                if(i < count) { 
                top_scores[i].setproperties(i);
                }
                labels[i].Text = top_scores[i].Name;
                labelsy[i].Text = top_scores[i].Score;
                labelsp[i].Text = top_scores[i].Time;

            }
        }

    }
}
