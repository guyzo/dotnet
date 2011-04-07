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

                // books.Add(new Book("0385418868", "The Power of Myth", "Joseph Campbell", "Anchor", new DateTime(1991, 6, 1), collaborator: "Bill Moyers", pages: 293));
                books.Add(new Book("1430225491", "Pro C# 2010 and the .NET 4 Platform", "Andrew Troelsen", "Apress", new DateTime(2010, 5, 10), isbn13: "9781430225492", pages: 1752));
                books.Add(new Book("0596800959", "C# 4.0 in a Nutshell", "Joseph Albahari, Ben Albahari", "O'Reilly Media", new DateTime(2010, 2, 10), isbn13: "9780596800956", pages: 1056));
                books.Add(new Book("1449380344", "Head First C#", "Andrew Stellman, Jennifer Greene", "O'Reilly Media", new DateTime(2010, 5, 28), isbn13: "9781449380342", pages: 848));
                books.Add(new Book("1935182471", "C# in Depth", "Jon Skeet", "Manning Publications", new DateTime(2010, 11, 15), isbn13: "9781935182474", pages: 584));
                books.Add(new Book("0735626707", "Microsoft Visual C# 2010 Step by Step", "John Sharp", "Microsoft Press", new DateTime(2010, 3, 31), isbn13: "9780735626706", pages: 784));
                books.Add(new Book("0321694694", "Essential C# 4.0", "Mark Michaelis", "Addison-Wesley Professional", new DateTime(2010, 3, 20), isbn13: "9780321694690", pages: 984));
                books.Add(new Book("0321658701", "Effective C#: 50 Specific Ways to Improve Your C#", "Bill Wagner", "Addison-Wesley Professional", new DateTime(2010, 3, 15), isbn13: "9780321658708", pages: 352));
                books.Add(new Book("0470502258", "Professional C# 4 and .NET 4", "Christian Nagel; Bill Evjen; Jay Glynn; Karli Watson; Morgan Skinner", "Wrox", new DateTime(2010, 3, 8), isbn13: "9780470502259", pages: 1536));
                books.Add(new Book("0596159838", "Programming C# 4.0", "Ian Griffiths; Matthew Adams; Jesse Liberty", "O'Reilly Media", new DateTime(2010, 8, 18), isbn13: "9780596159832", pages: 864));


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
