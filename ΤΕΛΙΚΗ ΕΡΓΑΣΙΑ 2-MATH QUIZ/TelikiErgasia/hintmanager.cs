using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelikiErgasia
{
    class hintmanager
    {
        int remain = 2;
        public void manager()
        {
            if (remain == 2)
            {
                MessageBox.Show("Μπορειτε να χρησιμοποιησετε το κομπιουτερακι για τις πραξεις οσο τρεχει o χρονος ");
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
