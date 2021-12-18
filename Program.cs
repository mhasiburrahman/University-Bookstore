using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_Bookstore
{
    static class Program
    {
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

             //Application.Run(new StdForm());
           // Application.Run(new AddStd());

            //Application.Run(new StdLogin());
            // Application.Run(new AddStd());
            Application.Run(new Loading());

        }
    }
}
