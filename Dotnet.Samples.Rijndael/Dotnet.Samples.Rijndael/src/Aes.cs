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

    public class Cipher
    {
        #region Encryption
        public string Encrypt(string plaintext, string passphrase, string salt, string hashAlgorithm, int iterations, string vector, int keySize)
        {
            byte[] saltData = Encoding.ASCII.GetBytes(salt);
            byte[] plaintextData = Encoding.UTF8.GetBytes(plaintext);
            PasswordDeriveBytes derivedPassword = new PasswordDeriveBytes(passphrase, saltData, hashAlgorithm, iterations);
            byte[] keyData = derivedPassword.GetBytes(keySize / 8);
            byte[] vectorData = Encoding.ASCII.GetBytes(vector);
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
        #endregion

        #region Decryption
        public string Decrypt(string ciphertext, string passphrase, string salt, string hashAlgorithm, int iterations, string vector, int keySize)
        {
            byte[] cyphertextData = Convert.FromBase64String(ciphertext);
            byte[] saltData = Encoding.ASCII.GetBytes(salt);
            PasswordDeriveBytes derivedPassword = new PasswordDeriveBytes(passphrase, saltData, hashAlgorithm, iterations);
            byte[] keyData = derivedPassword.GetBytes(keySize / 8);
            byte[] vectorData = Encoding.ASCII.GetBytes(vector);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyData, vectorData);
            using (MemoryStream persistence = new MemoryStream(cyphertextData))
            {
                using (CryptoStream transformer = new CryptoStream(persistence, decryptor, CryptoStreamMode.Read))
                {
                    byte[] plaintextData = new byte[cyphertextData.Length];
                    int plaintextSize = transformer.Read(plaintextData, 0, plaintextData.Length);
                    return Encoding.UTF8.GetString(plaintextData, 0, plaintextSize);
                }
            }
        }
        #endregion
    }
}
