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
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    #endregion

    sealed class Cipher
    {
        #region Properties
        internal string Plaintext { get; set; }
        internal string Ciphertext { get; set; }
        internal string Passphrase { get; set; }
        internal string Salt { get; set; }
        #endregion

        #region Methods
        public string Encrypt()
        {
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(
                Passphrase,
                Encoding.ASCII.GetBytes(Salt)
                );

            var rijndaelManaged = new RijndaelManaged();
                rijndaelManaged.Mode = CipherMode.CBC;
                rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(32);
                rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(16);

            var memoryStream = new MemoryStream();

            using (memoryStream)
            {
                var cryptoStream = new CryptoStream(
                    memoryStream,
                    rijndaelManaged.CreateEncryptor(),
                    CryptoStreamMode.Write
                    );

                using (cryptoStream)
                {
                    var plaintext = Encoding.UTF8.GetBytes(Plaintext);
                    
                    cryptoStream.Write(
                        plaintext,
                        plaintext.GetLowerBound(0),
                        plaintext.Length
                        );
                    cryptoStream.FlushFinalBlock();

                    var cyphertext = Convert.ToBase64String(memoryStream.ToArray());

                    return cyphertext;
                }
            }
        }

        public string Decrypt()
        {
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(
                Passphrase,
                Encoding.ASCII.GetBytes(Salt)
                );

            var rijndaelManaged = new RijndaelManaged();
                rijndaelManaged.Mode = CipherMode.CBC;
                rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(32);
                rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(16);

            var memoryStream = new MemoryStream();

            using (memoryStream)
            {
                var cryptoStream = new CryptoStream(
                    memoryStream,
                    rijndaelManaged.CreateDecryptor(),
                    CryptoStreamMode.Write
                    );

                using (cryptoStream)
                {
                    var ciphertext = Convert.FromBase64String(Ciphertext);

                    cryptoStream.Write(
                        ciphertext,
                        ciphertext.GetLowerBound(0),
                        ciphertext.Length
                        );
                    cryptoStream.FlushFinalBlock();

                    var plaintext = Encoding.UTF8.GetString(memoryStream.ToArray());

                    return plaintext;
                }
            }
        }
        #endregion
    }
}
