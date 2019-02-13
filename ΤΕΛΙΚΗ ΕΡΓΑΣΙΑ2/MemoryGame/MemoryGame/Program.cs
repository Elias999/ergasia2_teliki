using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var for_files = new for_files();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    class for_files
    {
        public long CountLines(string file)
        {
            long count = 0;
            using (StreamReader r = new StreamReader(file))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    count++;
                }
            }
            return count;
        }

        private string user
        {
            get; set;
        }
        public string prospatheis
        {
            get; set;
        }

        public for_files()
        {
            user = "Default_User";
        }

        public string show_user()
        {
            return user;
        }
    }
}
