#region License
// Copyright (c) 2010 Nano Taboada, http://openid.nanotaboada.com.ar 
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
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    #endregion

    /// <summary>
    /// Interaction logic for Win.xaml
    /// </summary>
    public partial class CipherView : Window
    {
        /// <remarks>
        /// Refactored implementing the Model-View-ViewModel pattern.
        /// </remarks>
        public CipherView()
        {
            this.InitializeComponent();
        }

        //private void RijndaelWindow_Loaded(object sender, RoutedEventArgs e)
        //{
            //this.PassphraseTextBox.Text = cipher.Passphrase;
            //this.SaltTextBox.Text = cipher.Salt;
            //this.HashNameTextBox.Text = cipher.HashName;
            //this.IterationCountTextBox.Text = Convert.ToString(cipher.IterationCount);
            //this.InitVectorTextBox.Text = cipher.InitVector;
            //this.KeySizeTextBox.Text = Convert.ToString(cipher.KeySize);
        //}

        //private void EncryptDecryptButton_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (this.EncryptDecryptButton.Content.Equals("Encrypt"))
        //        {

        //            this.OutputTextBox.Text = cipher.Encrypt(this.InputTextBox.Text);
        //            this.InputTextBox.IsReadOnly = true;
        //            this.InputTextBox.Background = new SolidColorBrush(Colors.WhiteSmoke);
        //            this.EncryptDecryptButton.Content = "Decrypt";
        //        }
        //        else
        //        {
        //            this.OutputTextBox.Text = cipher.Decrypt(this.OutputTextBox.Text);
        //            this.InputTextBox.IsReadOnly = false;
        //            this.InputTextBox.Background = new SolidColorBrush(Colors.White);
        //            this.EncryptDecryptButton.Content = "Encrypt";
        //        }
        //    }
        //    catch (Exception error)
        //    {
        //        MessageBox.Show("Exception caught: " + error.Message);
        //    }
        //}

        //private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    this.OutputTextBox.Text = String.Empty;
        //}
    }
}
