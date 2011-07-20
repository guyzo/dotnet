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

/// <remarks>
/// Mapping and naming conventions inspired by Laurent Bugnion http://blog.galasoft.ch
/// </remarks>
namespace Dotnet.Samples.Rijndael
{
    #region References
    using System;
    using System.ComponentModel;
    using System.Text.RegularExpressions;
    #endregion

    // TODO: Implement CanExecuteChanged properly to control the execution of DecryptCommand

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

        public string HashName
        {
            get
            {
                return this._cipher.HashName;
            }
            set
            {
                this._cipher.HashName = value;
                OnPropertyChanged("HashName");
            }
        }

        public int IterationCount
        {
            get
            {
                return this._cipher.IterationCount;
            }
            set
            {
                this._cipher.IterationCount = value;
                OnPropertyChanged("HashName");
            }
        }

        public string InitVector
        {
            get
            {
                return this._cipher.InitVector;
            }
            set
            {
                this._cipher.InitVector = value;
                OnPropertyChanged("HashName");
            }
        }

        public int KeySize
        {
            get
            {
                return this._cipher.KeySize;
            }
            set
            {
                this._cipher.KeySize = value;
                OnPropertyChanged("HashName");
            }
        }

        private CipherCommand _encryptCommand;
        public CipherCommand EncryptCommand
        {
            get
            {
                return _encryptCommand;
            }
            set
            { 
                _encryptCommand = value;
                OnPropertyChanged("EncryptCommand");
            }
        }

        private CipherCommand _decryptCommand;
        public CipherCommand DecryptCommand
        {
            get
            {
                return _decryptCommand;
            }
            set
            {
                _decryptCommand = value;
                OnPropertyChanged("DecryptCommand");
            }
        }
        #endregion

        #region Constructors
        public CipherViewModel()
        {
            this._cipher = new Cipher()
            {
                Passphrase = "foobar",
                Salt = "NaCl",
                HashName = "SHA1",
                IterationCount = 1,
                InitVector = "0110111001110100",
                KeySize = 128
            };

            this._encryptCommand = new CipherCommand(Encrypt);
            this._decryptCommand = new CipherCommand(Decrypt);
        }
        #endregion

        #region Methods
        private void Encrypt()
        {
            if (!string.IsNullOrEmpty(this._cipher.Plaintext))
            {
                this._cipher.Ciphertext = this._cipher.Encrypt();
                OnPropertyChanged("Ciphertext");
                this._cipher.Plaintext = String.Empty;
                OnPropertyChanged("Plaintext");
            }
        }

        private void Decrypt()
        {
            if (!string.IsNullOrEmpty(this._cipher.Ciphertext))
            {
                this._cipher.Plaintext = this._cipher.Decrypt();
                OnPropertyChanged("Plaintext");
                this._cipher.Ciphertext = String.Empty;
                OnPropertyChanged("Ciphertext");
            }
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
                        break;

                    case "HashName":
                        if (string.IsNullOrEmpty(this.HashName))
                        {
                            error = "Hash Name cannot be blank.";
                        }

                        Regex regex = new Regex("(MD5)|(SHA1)", RegexOptions.Compiled);

                        if (!regex.IsMatch(this.HashName)) // arbitrary business rule
                        {
                            error = "Hash Name value must be either MD5 or SHA1.";
                        }
                        break;

                    case "IterationCount":
                        if ((this.IterationCount <= 0) || (this.IterationCount >= 9)) // arbitrary business rule
                        {
                            error = "Iteration Count number must be positive and cannot exceed 9.";
                        }
                        break;

                    case "InitVector":
                        if (this.InitVector.Length != 16)
                        {
                            error = "Init Vector value must be exactly 16 characters long.";
                        }
                        break;

                    case "KeySize":
                        if (this.KeySize <= 0)
                        {
                            error = "Key Size value must be a positive number.";
                        }
                        break;
                }

                return (error);
            }
        }
        #endregion
    }
}


