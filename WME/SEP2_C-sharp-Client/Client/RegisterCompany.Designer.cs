namespace Client
{
    partial class TheMainForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCompanyName = new System.Windows.Forms.TextBox();
            this.textBoxCompanyID = new System.Windows.Forms.TextBox();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.textBoxCompanyEmail = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 151);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Company ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 224);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Company phone number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 293);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Company Email";
            // 
            // textBoxCompanyName
            // 
            this.textBoxCompanyName.Location = new System.Drawing.Point(169, 100);
            this.textBoxCompanyName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxCompanyName.Name = "textBoxCompanyName";
            this.textBoxCompanyName.Size = new System.Drawing.Size(157, 22);
            this.textBoxCompanyName.TabIndex = 4;
            // 
            // textBoxCompanyID
            // 
            this.textBoxCompanyID.Location = new System.Drawing.Point(169, 171);
            this.textBoxCompanyID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxCompanyID.Name = "textBoxCompanyID";
            this.textBoxCompanyID.Size = new System.Drawing.Size(157, 22);
            this.textBoxCompanyID.TabIndex = 5;
            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(169, 244);
            this.textBoxPhoneNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(157, 22);
            this.textBoxPhoneNumber.TabIndex = 6;
            // 
            // textBoxCompanyEmail
            // 
            this.textBoxCompanyEmail.Location = new System.Drawing.Point(169, 313);
            this.textBoxCompanyEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxCompanyEmail.Name = "textBoxCompanyEmail";
            this.textBoxCompanyEmail.Size = new System.Drawing.Size(157, 22);
            this.textBoxCompanyEmail.TabIndex = 7;
            // 
            // buttonCreate
            // 
            this.buttonCreate.BackColor = System.Drawing.SystemColors.Desktop;
            this.buttonCreate.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonCreate.Location = new System.Drawing.Point(111, 370);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(100, 28);
            this.buttonCreate.TabIndex = 8;
            this.buttonCreate.Text = "CREATE";
            this.buttonCreate.UseVisualStyleBackColor = false;
            this.buttonCreate.Click += new System.EventHandler(this.ButtonCreate_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(283, 370);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 28);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Company
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 505);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.textBoxCompanyEmail);
            this.Controls.Add(this.textBoxPhoneNumber);
            this.Controls.Add(this.textBoxCompanyID);
            this.Controls.Add(this.textBoxCompanyName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Company";
            this.Text = "RegisterCompany";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCompanyName;
        private System.Windows.Forms.TextBox textBoxCompanyID;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.TextBox textBoxCompanyEmail;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}