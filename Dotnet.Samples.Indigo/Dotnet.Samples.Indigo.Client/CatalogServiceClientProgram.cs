using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Dotnet.Samples.Indigo.Client
{
    static class CatalogServiceClientProgram
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CatalogServiceClientForm());
        }
    }
}
