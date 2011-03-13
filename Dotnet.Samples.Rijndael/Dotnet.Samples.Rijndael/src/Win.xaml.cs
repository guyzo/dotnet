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
    #endregion

    /// <summary>
    /// Interaction logic for Win.xaml
    /// </summary>
    public partial class Win : Window
    {
        public Win()
        {
            this.InitializeComponent();
            this.InitializeTextBoxes();
        }

        private void InitializeTextBoxes()
        {
            this.OutputTextBox.IsReadOnly = true;
            this.PassphraseTextBox.Text = "foobar";
            this.SaltTextBox.Text = "NaCl";
            this.HashAlgorithmTextBox.Text = "SHA1";
            this.IterationsTextBox.Text = "1";
            this.VectorTextBox.Text = "0110111001110100";
            this.KeySizeTextBox.Text = "128";

        }

        private void EncryptDecryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.EncryptDecryptButton.Content.Equals("Encrypt"))
                {
                    this.SetTextBoxesReadOnly(true);

                    Cipher aes = new Cipher();

                    this.OutputTextBox.Text = aes.Encrypt(this.InputTextBox.Text,
                                                          this.PassphraseTextBox.Text,
                                                          this.SaltTextBox.Text,
                                                          this.HashAlgorithmTextBox.Text,
                                                          Convert.ToInt32(this.IterationsTextBox.Text),
                                                          this.VectorTextBox.Text,
                                                          Convert.ToInt32(this.KeySizeTextBox.Text)
                                                          );

                    this.EncryptDecryptButton.Content = "Decrypt";
                }
                else
                {
                    Cipher aes = new Cipher();

                    this.OutputTextBox.Text = aes.Decrypt(this.OutputTextBox.Text,
                                                            this.PassphraseTextBox.Text,
                                                            this.SaltTextBox.Text,
                                                            this.HashAlgorithmTextBox.Text,
                                                            Convert.ToInt32(this.IterationsTextBox.Text),
                                                            this.VectorTextBox.Text,
                                                            Convert.ToInt32(this.KeySizeTextBox.Text)
                                                            );

                    this.EncryptDecryptButton.Content = "Encrypt";

                    this.SetTextBoxesReadOnly(false);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Exception caught: " + error.Message);
            }
        }

        private void SetTextBoxesReadOnly(bool value)
        {
            this.InputTextBox.IsReadOnly = value;
            this.PassphraseTextBox.IsReadOnly = value;
            this.SaltTextBox.IsReadOnly = value;
            this.HashAlgorithmTextBox.IsReadOnly = value;
            this.IterationsTextBox.IsReadOnly = value;
            this.VectorTextBox.IsReadOnly = value;
            this.KeySizeTextBox.IsReadOnly = value;
        }

        private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.OutputTextBox.Text = String.Empty;
        }

        private void AesWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
