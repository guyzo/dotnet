namespace Dotnet.Samples.Silverlight
{
    #region References
    using System;
    using System.Windows;

    #endregion

    public partial class App : Application
    {
        #region Constructors
        public App()
        {
            InitializeComponent();
            this.Startup += this.Application_Startup;
        }
        #endregion

        #region Events
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            this.RootVisual = new Gui();
        }
        #endregion
    }
}
