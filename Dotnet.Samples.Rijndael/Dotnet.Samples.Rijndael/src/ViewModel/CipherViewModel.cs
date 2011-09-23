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
    using System.ComponentModel;
    using System.Text.RegularExpressions;
    #endregion

    public class CipherViewModel : ViewModel, IDataErrorInfo
    {
        #region Fields
        private readonly Cipher _cipher;
        #endregion

        #region Properties
        public string Plaintext
        {
            get
            {
                return this._cipher.Plaintext;
            }
            set
            {
                this._cipher.Plaintext = value;
                OnPropertyChanged("Plaintext");
            }
        }

        public string Ciphertext
        {
            get
            {
                return this._cipher.Ciphertext;
            }
            set
            {
                this._cipher.Ciphertext = value;
                OnPropertyChanged("Ciphertext");
            }
        }

        public string Passphrase
        {
            get
            {
                return this._cipher.Passphrase;
            }
            set
            {
                this._cipher.Passphrase = value;
                OnPropertyChanged("Passphrase");
            }
        }

        public string Salt
        {
            get
            {
                return this._cipher.Salt;
            }
            set
            {
                this._cipher.Salt = value;
                OnPropertyChanged("Salt");
            }
        }

        private EncryptCommand _encrypt;
        public EncryptCommand Encrypt
        {
            get
            {
                return _encrypt;
            }
            set
            {
                this._encrypt = value;
                OnPropertyChanged("Encrypt");
            }
        }

        private DecryptCommand _decrypt;
        public DecryptCommand Decrypt
        {
            get
            {
                return _decrypt;
            }
            set
            {
                this._decrypt = value;
                OnPropertyChanged("Decrypt");
            }
        }
        #endregion

        #region Constructors
        public CipherViewModel()
        {
            this._cipher = new Cipher()
            { 
                Salt = "NaCl"
            };

            this._encrypt = new EncryptCommand(this, DoEncrypt);
            this._decrypt = new DecryptCommand(this, DoDecrypt);
        }
        #endregion

        #region Methods
        private void DoEncrypt()
        {
            this._cipher.Ciphertext = this._cipher.Encrypt();
            OnPropertyChanged("Ciphertext");
            this._cipher.Plaintext = String.Empty;
            OnPropertyChanged("Plaintext");
        }

        private void DoDecrypt()
        {
            this._cipher.Plaintext = this._cipher.Decrypt();
            OnPropertyChanged("Plaintext");
            this._cipher.Ciphertext = String.Empty;
            OnPropertyChanged("Ciphertext");
        }
        #endregion

        #region Errors
        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                string error = null;

                switch (columnName)
                {
                    case "Plaintext":
                        if (string.IsNullOrEmpty(this.Plaintext))
                        {
                            error = "Plaintext value cannot be null or empty.";
                        }
                        break;

                    case "Ciphertext":
                        if (string.IsNullOrEmpty(this.Ciphertext))
                        {
                            error = "Ciphertext value cannot be null or empty.";
                        }
                        break;

                    case "Passphrase":
                        if (string.IsNullOrEmpty(this.Passphrase))
                        {
                            error = "Passphrase value cannot be null or empty.";
                        }
                        break;

                    case "Salt":
                        if (string.IsNullOrEmpty(this.Salt))
                        {
                            error = "Salt value cannot be null or empty.";
                        }
                        else if (this.Salt.Length < 8)
                        {
                            error = "Salt should be at least eight bytes long.";
                        }
                        break;
                }

                return (error);
            }
        }
        #endregion
    }
}
