namespace Dotnet.Samples.Rijndael
{
    #region References
    using System;
    using System.Windows.Input;
    #endregion

    public class CipherCommand : ICommand
    {
        #region Fields
        private readonly Action _action;
        #endregion

        #region Constructors
        public CipherCommand(Action action)
        {
            this._action = action;
        }
        #endregion

        #region Methods
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this._action.Invoke();
        }
        #endregion

        #region Events
        public event EventHandler CanExecuteChanged;
        #endregion
    }
}
