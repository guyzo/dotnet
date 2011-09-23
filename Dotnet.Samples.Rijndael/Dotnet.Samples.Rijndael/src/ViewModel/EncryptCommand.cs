#region License
// Copyright (c) 2011 Nano Taboada, http://openid.nanotaboada.com.ar 
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE. 
#endregion

namespace Dotnet.Samples.Rijndael
{
    #region References
    using System;
    using System.Windows.Input;
    using System.Windows;
    #endregion

    public class EncryptCommand : ICommand
    {
        #region Fields
        private readonly CipherViewModel _cipherViewModel;
        private readonly Action _action;
        #endregion

        #region Constructors
        public EncryptCommand(CipherViewModel cipherViewModel, Action action)
        {
            this._cipherViewModel = cipherViewModel;
            this._action = action;

            this._cipherViewModel.PropertyChanged += (s, e) =>
            {
                if (CanExecuteChanged != null &&
                    (e.PropertyName == "Plaintext"
                    || e.PropertyName == "Passphrase"
                    || e.PropertyName == "Salt"))
                {
                    CanExecuteChanged(this, EventArgs.Empty);
                }
            };
        }
        #endregion

        #region Methods
        public bool CanExecute(object parameter)
        {
            if (this._cipherViewModel != null
                && !string.IsNullOrEmpty(this._cipherViewModel.Plaintext)
                && !string.IsNullOrEmpty(this._cipherViewModel.Passphrase)
                && this._cipherViewModel.Salt.Length => 8)
            {
                return true;
            }

            return false;
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
