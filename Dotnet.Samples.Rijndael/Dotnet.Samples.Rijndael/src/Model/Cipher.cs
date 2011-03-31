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
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    #endregion

    sealed class Cipher
    {
        #region Properties
        /// <remarks>
        /// Refactored implementing the Model-View-ViewModel pattern.
        /// </remarks>
        internal string Plaintext { get; set; }
        internal string Ciphertext { get; set; }
        internal string Passphrase { get; set; }
        internal string Salt { get; set; }
        internal string HashName { get; set; }
        internal int IterationCount { get; set; }
        internal string InitVector { get; set; }
        internal int KeySize { get; set; }
        #endregion

        #region Constructors
        /// <remarks>
        /// Refactored implementing the Model-View-ViewModel pattern.
        /// </remarks>
        public Cipher()
        {

        }
        //public Cipher(string passphrase = "foobar", string salt = "NaCl", string hashName = "SHA1", int iterationCount = 1, string initVector = "0110111001110100", int keySize = 128)
        //{
        //    this.Passphrase = passphrase;
        //    this.Salt = salt;
        //    this.HashName = hashName;
        //    this.IterationCount = iterationCount;
        //    this.InitVector = initVector;
        //    this.KeySize = keySize;
        //}
        #endregion

        #region Methods
        public string Encrypt()
        {
            byte[] saltData = Encoding.ASCII.GetBytes(Salt);
            byte[] plaintextData = Encoding.UTF8.GetBytes(Plaintext);
            PasswordDeriveBytes derivedPassword = new PasswordDeriveBytes(Passphrase, saltData, HashName, IterationCount);
            byte[] keyData = derivedPassword.GetBytes(KeySize / 8);
            byte[] vectorData = Encoding.ASCII.GetBytes(InitVector);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyData, vectorData);
            using (MemoryStream persistence = new MemoryStream())
            {
                using (CryptoStream transformer = new CryptoStream(persistence, encryptor, CryptoStreamMode.Write))
                {
                    transformer.Write(plaintextData, 0, plaintextData.Length);
                    transformer.FlushFinalBlock();
                    byte[] ciphertextData = persistence.ToArray();

                    return Convert.ToBase64String(ciphertextData);
                }
            }
        }

        public string Decrypt()
        {
            byte[] ciphertextData = Convert.FromBase64String(Ciphertext);
            byte[] saltData = Encoding.ASCII.GetBytes(Salt);
            PasswordDeriveBytes derivedPassword = new PasswordDeriveBytes(Passphrase, saltData, HashName, IterationCount);
            byte[] keyData = derivedPassword.GetBytes(KeySize / 8);
            byte[] vectorData = Encoding.ASCII.GetBytes(InitVector);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyData, vectorData);
            using (MemoryStream persistence = new MemoryStream(ciphertextData))
            {
                using (CryptoStream transformer = new CryptoStream(persistence, decryptor, CryptoStreamMode.Read))
                {
                    byte[] plaintextData = new byte[ciphertextData.Length];
                    int plaintextSize = transformer.Read(plaintextData, 0, plaintextData.Length);

                    return Encoding.UTF8.GetString(plaintextData, 0, plaintextSize);
                }
            }
        }
        #endregion
    }
}
