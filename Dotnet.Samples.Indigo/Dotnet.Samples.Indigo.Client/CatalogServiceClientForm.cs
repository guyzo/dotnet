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

namespace Dotnet.Samples.Indigo.Client
{
    using System;
    using System.Windows.Forms;
    using Dotnet.Samples.Indigo.Client;

    public partial class CatalogServiceClientForm : Form
    {
        public CatalogServiceClientForm()
        {
            InitializeComponent();
        }

        private void IndigoClientButton_Click(object sender, EventArgs e)
        {
            // TODO: Create a MSBuilsd Task to automatically generate CatalogServiceContractClient with 'svcutil.exe'.

            using (CatalogServiceContractClient client = new CatalogServiceContractClient())
            {
                // TODO: Implement real error handling here.
                try
                {
                    this.IndigoClientResponseTextBox.Text = client.GetBookByIsbn(this.IndigoClientRequestTextBox.Text);
                }
                catch (Exception error)
                {
                    MessageBox.Show(String.Format("Exception caught: {0}", error.Message));
                }
            }
        }
    }
}
