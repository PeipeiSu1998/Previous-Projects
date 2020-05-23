namespace Client
{
    partial class ReleasePallet
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPalletID = new System.Windows.Forms.TextBox();
            this.buttonReleasePallet = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxCompanyID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pallet ID";
            // 
            // textBoxPalletID
            // 
            this.textBoxPalletID.Location = new System.Drawing.Point(46, 120);
            this.textBoxPalletID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPalletID.Name = "textBoxPalletID";
            this.textBoxPalletID.Size = new System.Drawing.Size(126, 20);
            this.textBoxPalletID.TabIndex = 1;
            // 
            // buttonReleasePallet
            // 
            this.buttonReleasePallet.Location = new System.Drawing.Point(46, 162);
            this.buttonReleasePallet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonReleasePallet.Name = "buttonReleasePallet";
            this.buttonReleasePallet.Size = new System.Drawing.Size(56, 19);
            this.buttonReleasePallet.TabIndex = 2;
            this.buttonReleasePallet.Text = "Release";
            this.buttonReleasePallet.UseVisualStyleBackColor = true;
            this.buttonReleasePallet.Click += new System.EventHandler(this.ButtonReleasePallet_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(114, 162);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(56, 19);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // textBoxCompanyID
            // 
            this.textBoxCompanyID.Location = new System.Drawing.Point(46, 62);
            this.textBoxCompanyID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCompanyID.Name = "textBoxCompanyID";
            this.textBoxCompanyID.Size = new System.Drawing.Size(126, 20);
            this.textBoxCompanyID.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Company ID";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ReleasePallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 224);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCompanyID);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonReleasePallet);
            this.Controls.Add(this.textBoxPalletID);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ReleasePallet";
            this.Text = "ReleasePallet";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPalletID;
        private System.Windows.Forms.Button buttonReleasePallet;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxCompanyID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}