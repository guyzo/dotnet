namespace Dotnet.Samples.Silverlight
{
    #region References
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;

    #endregion

    public partial class Gui : UserControl
    {
        #region Constructors
        public Gui()
        {
            this.InitializeComponent();
            this.Loaded += new RoutedEventHandler(Gui_Loaded);
        }
        #endregion

        #region Methods
        private void InitializeDataGrid()
        {
            try
            {
                List<Book> books = new List<Book>();

                books.Add(new Book("0385418868", "The Power of Myth", "Joseph Campbell", "Anchor", new DateTime(1991, 6, 1), collaborator: "Bill Moyers", pages: 293));
                books.Add(new Book("1577315936", "The Hero with a Thousand Faces", "Joseph Campbell", "New World Library", new DateTime(2008, 7, 28), pages: 432));
                books.Add(new Book("1577312023", "Thou Art That", "Joseph Campbell", "New World Library", new DateTime(2001, 10, 10), pages: 192));
                books.Add(new Book("1577312090", "The Inner Reaches of Outer Space", "Joseph Campbell", "New World Library", new DateTime(2002, 2, 9), pages: 160));
                books.Add(new Book("1577314034", "Myths of Light", "Joseph Campbell", "New World Library", new DateTime(2003, 5, 1), pages: 224));
                books.Add(new Book("1577314719", "Pathways to Bliss", "Joseph Campbell", "New World Library", new DateTime(2004, 10, 26), pages: 224));

                this.BooksDataGrid.ItemsSource = books;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        #endregion

        #region Events
        void Gui_Loaded(object sender, RoutedEventArgs e)
        {
            this.InitializeDataGrid();
        }
        #endregion
    }
}
