using Microsoft;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace MemoryGame
{
    public partial class Form1 : Form
    {
        PictureBox[] pictureBoxs = new PictureBox[16];
        Random rnd = new Random();
        int prospatheis = 0;
        int remain = 8;//υπολοιπομενα ζευγαρια
        int stopper=0;

        public Form1()
        {
            
            InitializeComponent();
            time.Text = "0:0";
            pictureBoxs[0] = pictureBox1;
            pictureBoxs[1] = pictureBox2;
            pictureBoxs[2] = pictureBox3;
            pictureBoxs[3] = pictureBox4;
            pictureBoxs[4] = pictureBox5;
            pictureBoxs[5] = pictureBox6;
            pictureBoxs[6] = pictureBox7;
            pictureBoxs[7] = pictureBox8;
            pictureBoxs[8] = pictureBox9;
            pictureBoxs[9] = pictureBox10;
            pictureBoxs[10] = pictureBox11;
            pictureBoxs[11] = pictureBox12;
            pictureBoxs[12] = pictureBox13;
            pictureBoxs[13] = pictureBox14;
            pictureBoxs[14] = pictureBox15;
            pictureBoxs[15] = pictureBox16;
            remains.Text = "Μένουν ακόμα " + remain.ToString() + " ζευγάρια";
        }
        void save_score(string user)
        {
            var for_files = new for_files();
            long count = for_files.CountLines("scores.sc");
            string[] lines = new string[count+1];
            lines = System.IO.File.ReadAllLines("scores.sc");
            for_files.prospatheis = prospatheis.ToString();


            if (count == 0)
            {
                string user_time = min + ":" + seconds;
                string line = for_files.show_user() + ' ' + for_files.prospatheis + " " + user_time;
                System.IO.File.AppendAllText("scores.sc", line + Environment.NewLine);
            }

            else {
                bool found = false;
                for (int i = 0; i < count; i++)
                {
                   
                    string[] meroi = lines[i].Split(' ');
                    if (Int32.Parse(meroi[1]) >= prospatheis)
                    {
                        string[] newlines = new string[lines.Length + 1];
                        for (int ii = 0;ii<i;ii++)
                        {
                            newlines[ii] = lines[ii];
                        }
                        for (int ii = i; ii < lines.Length; ii++)
                        {
                            newlines[ii + 1] = lines[ii];
                        }
                        string user_time = min + ":" + seconds;
                        string line = for_files.show_user() + ' ' + for_files.prospatheis + " " + user_time;
                        newlines[i] = line;
                        System.IO.File.WriteAllText("scores.sc", "");
                        for(int xx = 0; xx < newlines.Length; xx++)
                        {
                            System.IO.File.AppendAllText("scores.sc", newlines[xx] + Environment.NewLine);
                        }
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    string user_time = min + ":" + seconds;
                    string line = for_files.show_user() + ' ' + for_files.prospatheis + ' ' + user_time;
                    System.IO.File.AppendAllText("scores.sc", line + Environment.NewLine);
                }
            }


           
        }
        void SetDefaultPicture()
        {
            for (int i = 0; i < 16; i++)
            {
                //Σε ολες τις εικονες του πινακα/φορμας  θετει default image
                pictureBoxs[i].Image = Properties.Resources._0;

            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            SetGame();
        }

        Image[] image = new Image[8];
        bool folder_selected = false;
        private void Settings_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Επιλέξτε φάκελο με 8 φωτογραφιές.";
            
            int i = 0;
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                folder_selected = true;
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                foreach (string file in Directory.GetFiles(folderPath, "*.png"))
                {
                    image[i] = Image.FromFile(file);
                    i++;
                }
            }
        }
        void TagtoPicture(PictureBox picture)
        {
            switch (Convert.ToInt32(picture.Tag))
            {
                default:
                    picture.Image = Properties.Resources._0;
                    break;
                case 1:
                    if(folder_selected == true)
                        picture.Image = image[0];
                    else
                        picture.Image = Properties.Resources._1;
                    break;
                case 2:
                    if (folder_selected == true)
                        picture.Image = image[1];
                    else
                        picture.Image = Properties.Resources._2;
                    break;
                case 3:
                    if (folder_selected == true)
                        picture.Image = image[2];
                    else
                        picture.Image = Properties.Resources._3;
                    break;
                case 4:
                    if (folder_selected == true)
                        picture.Image = image[3];
                    else
                        picture.Image = Properties.Resources._4;
                    break;
                case 5:
                    if (folder_selected == true)
                        picture.Image = image[4];
                    else
                        picture.Image = Properties.Resources._5;
                    break;
                case 6:
                    if (folder_selected == true)
                        picture.Image = image[5];
                    else
                        picture.Image = Properties.Resources._6;
                    break;
                case 7:
                    if (folder_selected == true)
                        picture.Image = image[6];
                    else
                        picture.Image = Properties.Resources._7;
                    break;
                case 8:
                    if (folder_selected == true)
                        picture.Image = image[7];
                    else
                        picture.Image = Properties.Resources._8;
                    break;
                
            }

        }
        void TagRandom()
        {
            int[] tags = new int[] {1,2,3,4,5,6,7,8,1,2,3,4,5,6,7,8 };
            int[] MyRandomArray = tags.OrderBy(x => rnd.Next()).ToArray();
            for (int i = 0; i < 16; i++)
            {
                pictureBoxs[i].Tag = MyRandomArray[i].ToString();
            }
        }
        //δημιουργει ενα array με τα tags το αλλαζει σε τυχαιες θεσεις και τα θετει στα pictureboxes


        public void wait(int xronos)
        {
            System.Windows.Forms.Timer kathysterisi = new System.Windows.Forms.Timer();
            if (xronos == 0 || xronos < 0) return;
            kathysterisi.Interval = xronos;
            kathysterisi.Enabled = true;
            kathysterisi.Start();
            //Το timer χτυπά ώσπου φτασεί την μεταβλητή xronos
            kathysterisi.Tick += (s, e) =>
            {
                kathysterisi.Enabled = false;
                kathysterisi.Stop();
            };
            while (kathysterisi.Enabled)
            {
                Application.DoEvents();//Για να μην σταματάει το ui, συνεχίζει να εκτελεί όλες τις υπόλοιπες λειτουργείες
            }
        }

        /*συγκρινει τα strings της πρωτης που ανοιχτηκε με την δευτερη
        * Kαι αν ειναι ιδια τα αφηνει ανοιχτα και τα απενεργοποιει για να μην μπορουν να ξαναπατηθουν
          */
        void Compare(PictureBox previous, PictureBox current)
        {
            if (previous.Tag.ToString() == current.Tag.ToString())
            {
                previous.Visible = true;
                current.Visible = true;
                previous.Enabled = false;
                current.Enabled = false;
                remain--;
                remains.Text = "Μένουν ακόμα " + remain.ToString() + " ζευγάρια";
                if (remain == 0)
                {
                    sec.Enabled = false;
                    MessageBox.Show("Τέλος παιχνιδιού, αριθμός προσπαθείων: " + prospatheis.ToString() + ' '+ "χρόνος " + min.ToString() + ":" + seconds.ToString());
                    save_score(textBox1.Text);
                }
            }
            else
            {
                wait(700);
                previous.Image = Properties.Resources._0;
                current.Image = Properties.Resources._0;

            }
        }
 
        void SetGame()
        {
            SetDefaultPicture();
            TagRandom();
        }

        bool same = false;//μεταβλητη για ελεγχο στην σύγκριση
        PictureBox prev;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            sec.Enabled = true;
            prospatheis++;
            PictureBox box = sender as PictureBox;
            //box.Image = Image.FromFile(box.Tag.ToString() + ".png");
            TagtoPicture(box);//Βάση του tag θέτει στο Picturebox μια εικόνα απο το resource //βρες πως αλλάζεις το recourse sto runtime
            if (same==false)//Περίπτωση που δεν έχουμε σηκώσει άλλη κάρτα
            {
                prev = box;
                same = true;
            }
            else//Η περίπτωση το box που πατήσαμε να είναι διαφορετικό
            {
                Application.DoEvents();
                Compare(prev, box);//συγκρισή του παλιού κουτιού και του καινούργιου
                same = false;//Αφου εγίνε η συγκρίση δεν έχουμε πια γυρισμένα φύλλα
            }
        }

        int min = 0;
        int seconds = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds++;
            stopper++;
            if(seconds == 59)
            {
                seconds = 0;
                min++;
            }
            time.Text = min.ToString() + ":" + seconds.ToString();
        }
        private void scores_Click(object sender, EventArgs e)
        {
            var scoreform = new TopScores();
            scoreform.Show();
        }




        /*την πρωτη φορα που πατιεται η εικονα δεν κανει τον ελεγχο συκρισης
* Θετει το picturebox prev με αυτη την picturebox που επιλεχθηκε
* και την bool μεταβλητη true για να βγει απο το  if
* ενω στο δευτετο κλικ  γινεται συγκριση των δυο εφοσον δεν πατιεται το ιδιο picturebox
*/
    }
}
