namespace Dotnet.Samples.Indigo.Client
{
    partial class CatalogServiceClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.IndigoClientRequestGroupBox = new System.Windows.Forms.GroupBox();
            this.IndigoClientRequestISBNLabel = new System.Windows.Forms.Label();
            this.IndigoClientRequestButton = new System.Windows.Forms.Button();
            this.IndigoClientRequestTextBox = new System.Windows.Forms.TextBox();
            this.IndigoClientResponseGroupBox = new System.Windows.Forms.GroupBox();
            this.IndigoClientResponseTextBox = new System.Windows.Forms.TextBox();
            this.IndigoClientRequestGroupBox.SuspendLayout();
            this.IndigoClientResponseGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // IndigoClientRequestGroupBox
            // 
            this.IndigoClientRequestGroupBox.Controls.Add(this.IndigoClientRequestISBNLabel);
            this.IndigoClientRequestGroupBox.Controls.Add(this.IndigoClientRequestButton);
            this.IndigoClientRequestGroupBox.Controls.Add(this.IndigoClientRequestTextBox);
            this.IndigoClientRequestGroupBox.Location = new System.Drawing.Point(12, 12);
            this.IndigoClientRequestGroupBox.Name = "IndigoClientRequestGroupBox";
            this.IndigoClientRequestGroupBox.Size = new System.Drawing.Size(280, 50);
            this.IndigoClientRequestGroupBox.TabIndex = 4;
            this.IndigoClientRequestGroupBox.TabStop = false;
            this.IndigoClientRequestGroupBox.Text = "Request";
            // 
            // IndigoClientRequestISBNLabel
            // 
            this.IndigoClientRequestISBNLabel.AutoSize = true;
            this.IndigoClientRequestISBNLabel.Location = new System.Drawing.Point(6, 21);
            this.IndigoClientRequestISBNLabel.Name = "IndigoClientRequestISBNLabel";
            this.IndigoClientRequestISBNLabel.Size = new System.Drawing.Size(32, 13);
            this.IndigoClientRequestISBNLabel.TabIndex = 5;
            this.IndigoClientRequestISBNLabel.Text = "ISBN";
            // 
            // IndigoClientRequestButton
            // 
            this.IndigoClientRequestButton.Location = new System.Drawing.Point(217, 16);
            this.IndigoClientRequestButton.Name = "IndigoClientRequestButton";
            this.IndigoClientRequestButton.Size = new System.Drawing.Size(56, 23);
            this.IndigoClientRequestButton.TabIndex = 4;
            this.IndigoClientRequestButton.Text = "Submit";
            this.IndigoClientRequestButton.UseVisualStyleBackColor = true;
            this.IndigoClientRequestButton.Click += new System.EventHandler(this.IndigoClientButton_Click);
            // 
            // IndigoClientRequestTextBox
            // 
            this.IndigoClientRequestTextBox.Location = new System.Drawing.Point(44, 18);
            this.IndigoClientRequestTextBox.Name = "IndigoClientRequestTextBox";
            this.IndigoClientRequestTextBox.Size = new System.Drawing.Size(167, 20);
            this.IndigoClientRequestTextBox.TabIndex = 3;
            this.IndigoClientRequestTextBox.Text = "0123456789";
            // 
            // IndigoClientResponseGroupBox
            // 
            this.IndigoClientResponseGroupBox.Controls.Add(this.IndigoClientResponseTextBox);
            this.IndigoClientResponseGroupBox.Location = new System.Drawing.Point(12, 68);
            this.IndigoClientResponseGroupBox.Name = "IndigoClientResponseGroupBox";
            this.IndigoClientResponseGroupBox.Size = new System.Drawing.Size(280, 82);
            this.IndigoClientResponseGroupBox.TabIndex = 5;
            this.IndigoClientResponseGroupBox.TabStop = false;
            this.IndigoClientResponseGroupBox.Text = "Response";
            // 
            // IndigoClientResponseTextBox
            // 
            this.IndigoClientResponseTextBox.Location = new System.Drawing.Point(6, 19);
            this.IndigoClientResponseTextBox.Multiline = true;
            this.IndigoClientResponseTextBox.Name = "IndigoClientResponseTextBox";
            this.IndigoClientResponseTextBox.ReadOnly = true;
            this.IndigoClientResponseTextBox.Size = new System.Drawing.Size(267, 52);
            this.IndigoClientResponseTextBox.TabIndex = 4;
            // 
            // CatalogServiceClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 162);
            this.Controls.Add(this.IndigoClientResponseGroupBox);
            this.Controls.Add(this.IndigoClientRequestGroupBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(320, 200);
            this.Name = "CatalogServiceClientForm";
            this.Text = "Dotnet.Samples.Indigo.Client";
            this.IndigoClientRequestGroupBox.ResumeLayout(false);
            this.IndigoClientRequestGroupBox.PerformLayout();
            this.IndigoClientResponseGroupBox.ResumeLayout(false);
            this.IndigoClientResponseGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox IndigoClientRequestGroupBox;
        private System.Windows.Forms.Button IndigoClientRequestButton;
        private System.Windows.Forms.TextBox IndigoClientRequestTextBox;
        private System.Windows.Forms.GroupBox IndigoClientResponseGroupBox;
        private System.Windows.Forms.TextBox IndigoClientResponseTextBox;
        private System.Windows.Forms.Label IndigoClientRequestISBNLabel;
    }
}

