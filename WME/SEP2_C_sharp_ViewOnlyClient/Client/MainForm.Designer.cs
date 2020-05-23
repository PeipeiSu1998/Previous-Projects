namespace Client
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCompanyID = new System.Windows.Forms.TextBox();
            this.buttonSearchCompany = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPalletIDs = new System.Windows.Forms.TextBox();
            this.buttonSearchPallet = new System.Windows.Forms.Button();
            this.buttonViewAll = new System.Windows.Forms.Button();
            this.buttonViewAllCompanies = new System.Windows.Forms.Button();
            this.buttonViewAllAvalableLocations = new System.Windows.Forms.Button();
            this.listViewPallets = new System.Windows.Forms.ListView();
            this.palletID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.companyID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.locationID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.palletHeight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.palletArea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.arrivalDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.daysStored = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewAvailableLocations = new System.Windows.Forms.ListView();
            this.locID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewCompanyIDs = new System.Windows.Forms.ListView();
            this.comID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 102);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Company IDs";
            // 
            // textBoxCompanyID
            // 
            this.textBoxCompanyID.Location = new System.Drawing.Point(20, 30);
            this.textBoxCompanyID.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCompanyID.Name = "textBoxCompanyID";
            this.textBoxCompanyID.Size = new System.Drawing.Size(132, 22);
            this.textBoxCompanyID.TabIndex = 4;
            this.textBoxCompanyID.Text = "Company ID";
            // 
            // buttonSearchCompany
            // 
            this.buttonSearchCompany.Location = new System.Drawing.Point(160, 29);
            this.buttonSearchCompany.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSearchCompany.Name = "buttonSearchCompany";
            this.buttonSearchCompany.Size = new System.Drawing.Size(100, 28);
            this.buttonSearchCompany.TabIndex = 5;
            this.buttonSearchCompany.Text = "Search";
            this.buttonSearchCompany.UseVisualStyleBackColor = true;
            this.buttonSearchCompany.Click += new System.EventHandler(this.ButtonSearchCompany_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(706, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Available for rent locations";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 597);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "All stored pallets";
            // 
            // textBoxPalletIDs
            // 
            this.textBoxPalletIDs.Location = new System.Drawing.Point(20, 525);
            this.textBoxPalletIDs.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPalletIDs.Name = "textBoxPalletIDs";
            this.textBoxPalletIDs.Size = new System.Drawing.Size(132, 22);
            this.textBoxPalletIDs.TabIndex = 9;
            this.textBoxPalletIDs.Text = "Pallet ID";
            // 
            // buttonSearchPallet
            // 
            this.buttonSearchPallet.Location = new System.Drawing.Point(160, 524);
            this.buttonSearchPallet.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSearchPallet.Name = "buttonSearchPallet";
            this.buttonSearchPallet.Size = new System.Drawing.Size(100, 28);
            this.buttonSearchPallet.TabIndex = 10;
            this.buttonSearchPallet.Text = "Search";
            this.buttonSearchPallet.UseVisualStyleBackColor = true;
            this.buttonSearchPallet.Click += new System.EventHandler(this.ButtonSearchPallet_Click);
            // 
            // buttonViewAll
            // 
            this.buttonViewAll.Location = new System.Drawing.Point(20, 558);
            this.buttonViewAll.Margin = new System.Windows.Forms.Padding(4);
            this.buttonViewAll.Name = "buttonViewAll";
            this.buttonViewAll.Size = new System.Drawing.Size(240, 28);
            this.buttonViewAll.TabIndex = 11;
            this.buttonViewAll.Text = "View All";
            this.buttonViewAll.UseVisualStyleBackColor = true;
            this.buttonViewAll.Click += new System.EventHandler(this.ButtonViewAll_Click);
            // 
            // buttonViewAllCompanies
            // 
            this.buttonViewAllCompanies.Location = new System.Drawing.Point(20, 63);
            this.buttonViewAllCompanies.Margin = new System.Windows.Forms.Padding(4);
            this.buttonViewAllCompanies.Name = "buttonViewAllCompanies";
            this.buttonViewAllCompanies.Size = new System.Drawing.Size(240, 28);
            this.buttonViewAllCompanies.TabIndex = 12;
            this.buttonViewAllCompanies.Text = "View All Company IDs";
            this.buttonViewAllCompanies.UseVisualStyleBackColor = true;
            this.buttonViewAllCompanies.Click += new System.EventHandler(this.ButtonViewAllCompanies_Click);
            // 
            // buttonViewAllAvalableLocations
            // 
            this.buttonViewAllAvalableLocations.Location = new System.Drawing.Point(709, 63);
            this.buttonViewAllAvalableLocations.Margin = new System.Windows.Forms.Padding(4);
            this.buttonViewAllAvalableLocations.Name = "buttonViewAllAvalableLocations";
            this.buttonViewAllAvalableLocations.Size = new System.Drawing.Size(172, 28);
            this.buttonViewAllAvalableLocations.TabIndex = 14;
            this.buttonViewAllAvalableLocations.Text = "View All Locations";
            this.buttonViewAllAvalableLocations.UseVisualStyleBackColor = true;
            this.buttonViewAllAvalableLocations.Click += new System.EventHandler(this.ButtonViewAllAvalableLocations_Click);
            // 
            // listViewPallets
            // 
            this.listViewPallets.AllowColumnReorder = true;
            this.listViewPallets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.palletID,
            this.companyID,
            this.locationID,
            this.palletHeight,
            this.palletArea,
            this.arrivalDate,
            this.daysStored});
            this.listViewPallets.FullRowSelect = true;
            this.listViewPallets.GridLines = true;
            this.listViewPallets.Location = new System.Drawing.Point(20, 621);
            this.listViewPallets.Name = "listViewPallets";
            this.listViewPallets.Size = new System.Drawing.Size(861, 372);
            this.listViewPallets.TabIndex = 0;
            this.listViewPallets.UseCompatibleStateImageBehavior = false;
            this.listViewPallets.View = System.Windows.Forms.View.Details;
            // 
            // palletID
            // 
            this.palletID.Text = "Pallet ID";
            this.palletID.Width = 88;
            // 
            // companyID
            // 
            this.companyID.Text = "Company ID";
            this.companyID.Width = 88;
            // 
            // locationID
            // 
            this.locationID.Text = "Location ID";
            this.locationID.Width = 88;
            // 
            // palletHeight
            // 
            this.palletHeight.Text = "Pallet Height";
            this.palletHeight.Width = 100;
            // 
            // palletArea
            // 
            this.palletArea.Text = "Pallet Area";
            this.palletArea.Width = 90;
            // 
            // arrivalDate
            // 
            this.arrivalDate.Text = "Arrival Date";
            this.arrivalDate.Width = 90;
            // 
            // daysStored
            // 
            this.daysStored.Text = "Days Stored";
            this.daysStored.Width = 90;
            // 
            // listViewAvailableLocations
            // 
            this.listViewAvailableLocations.AllowColumnReorder = true;
            this.listViewAvailableLocations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.locID});
            this.listViewAvailableLocations.FullRowSelect = true;
            this.listViewAvailableLocations.GridLines = true;
            this.listViewAvailableLocations.Location = new System.Drawing.Point(709, 126);
            this.listViewAvailableLocations.Name = "listViewAvailableLocations";
            this.listViewAvailableLocations.Size = new System.Drawing.Size(172, 372);
            this.listViewAvailableLocations.TabIndex = 18;
            this.listViewAvailableLocations.UseCompatibleStateImageBehavior = false;
            this.listViewAvailableLocations.View = System.Windows.Forms.View.Details;
            // 
            // locID
            // 
            this.locID.Text = "Location ID";
            this.locID.Width = 100;
            // 
            // listViewCompanyIDs
            // 
            this.listViewCompanyIDs.AllowColumnReorder = true;
            this.listViewCompanyIDs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.comID,
            this.comName,
            this.comPhone,
            this.comEmail});
            this.listViewCompanyIDs.FullRowSelect = true;
            this.listViewCompanyIDs.GridLines = true;
            this.listViewCompanyIDs.Location = new System.Drawing.Point(20, 126);
            this.listViewCompanyIDs.Name = "listViewCompanyIDs";
            this.listViewCompanyIDs.Size = new System.Drawing.Size(581, 372);
            this.listViewCompanyIDs.TabIndex = 19;
            this.listViewCompanyIDs.UseCompatibleStateImageBehavior = false;
            this.listViewCompanyIDs.View = System.Windows.Forms.View.Details;
            // 
            // comID
            // 
            this.comID.Text = "Company ID";
            this.comID.Width = 90;
            // 
            // comName
            // 
            this.comName.Text = "Company Name";
            this.comName.Width = 120;
            // 
            // comPhone
            // 
            this.comPhone.Text = "Company Phone";
            this.comPhone.Width = 120;
            // 
            // comEmail
            // 
            this.comEmail.Text = "Company Email";
            this.comEmail.Width = 110;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 1055);
            this.Controls.Add(this.listViewCompanyIDs);
            this.Controls.Add(this.listViewAvailableLocations);
            this.Controls.Add(this.listViewPallets);
            this.Controls.Add(this.buttonViewAllAvalableLocations);
            this.Controls.Add(this.buttonViewAllCompanies);
            this.Controls.Add(this.buttonViewAll);
            this.Controls.Add(this.buttonSearchPallet);
            this.Controls.Add(this.textBoxPalletIDs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonSearchCompany);
            this.Controls.Add(this.textBoxCompanyID);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCompanyID;
        private System.Windows.Forms.Button buttonSearchCompany;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPalletIDs;
        private System.Windows.Forms.Button buttonSearchPallet;
        private System.Windows.Forms.Button buttonViewAll;
        private System.Windows.Forms.Button buttonViewAllCompanies;
        private System.Windows.Forms.Button buttonViewAllAvalableLocations;
        private System.Windows.Forms.ListView listViewPallets;
        private System.Windows.Forms.ColumnHeader palletID;
        private System.Windows.Forms.ColumnHeader companyID;
        private System.Windows.Forms.ColumnHeader locationID;
        private System.Windows.Forms.ColumnHeader palletHeight;
        private System.Windows.Forms.ColumnHeader palletArea;
        private System.Windows.Forms.ColumnHeader arrivalDate;
        private System.Windows.Forms.ColumnHeader daysStored;
        private System.Windows.Forms.ListView listViewAvailableLocations;
        private System.Windows.Forms.ColumnHeader locID;
        private System.Windows.Forms.ListView listViewCompanyIDs;
        private System.Windows.Forms.ColumnHeader comID;
        private System.Windows.Forms.ColumnHeader comName;
        private System.Windows.Forms.ColumnHeader comPhone;
        private System.Windows.Forms.ColumnHeader comEmail;
    }
}

