using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Dotnet.Samples.Silverlight
{
    public partial class Gui : UserControl
    {
        #region Constructor
        public Gui()
        {
            this.InitializeComponent();
            this.Loaded += new RoutedEventHandler(Gui_Loaded);
        }
        #endregion

        #region Events
        void Gui_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Book> books = new List<Book>().AddBooks();
                this.BooksDataGrid.ItemsSource = books;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        #endregion
    }
}
