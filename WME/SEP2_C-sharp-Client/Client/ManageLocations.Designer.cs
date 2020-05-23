namespace Client
{
    partial class ManageLocations
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCompanyID = new System.Windows.Forms.TextBox();
            this.textBoxLocationID = new System.Windows.Forms.TextBox();
            this.buttonSearchCompany = new System.Windows.Forms.Button();
            this.buttonRentLocation = new System.Windows.Forms.Button();
            this.buttonUnRentLocation = new System.Windows.Forms.Button();
            this.buttonViewAvailableLocations = new System.Windows.Forms.Button();
            this.listViewRentedLocations = new System.Windows.Forms.ListView();
            this.locationID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rentalStartDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewAvailableLocations = new System.Windows.Forms.ListView();
            this.availableLocationID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(608, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Location ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rented Locations";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(608, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Available Locations";
            // 
            // textBoxCompanyID
            // 
            this.textBoxCompanyID.Location = new System.Drawing.Point(31, 68);
            this.textBoxCompanyID.Name = "textBoxCompanyID";
            this.textBoxCompanyID.Size = new System.Drawing.Size(229, 22);
            this.textBoxCompanyID.TabIndex = 6;
            // 
            // textBoxLocationID
            // 
            this.textBoxLocationID.Location = new System.Drawing.Point(610, 68);
            this.textBoxLocationID.Name = "textBoxLocationID";
            this.textBoxLocationID.Size = new System.Drawing.Size(221, 22);
            this.textBoxLocationID.TabIndex = 7;
            // 
            // buttonSearchCompany
            // 
            this.buttonSearchCompany.Location = new System.Drawing.Point(31, 111);
            this.buttonSearchCompany.Name = "buttonSearchCompany";
            this.buttonSearchCompany.Size = new System.Drawing.Size(229, 23);
            this.buttonSearchCompany.TabIndex = 8;
            this.buttonSearchCompany.Text = "FInd Company Locations";
            this.buttonSearchCompany.UseVisualStyleBackColor = true;
            this.buttonSearchCompany.Click += new System.EventHandler(this.ButtonFindCompanyLocations_Click);
            // 
            // buttonRentLocation
            // 
            this.buttonRentLocation.Location = new System.Drawing.Point(610, 111);
            this.buttonRentLocation.Name = "buttonRentLocation";
            this.buttonRentLocation.Size = new System.Drawing.Size(221, 23);
            this.buttonRentLocation.TabIndex = 9;
            this.buttonRentLocation.Text = "Rent Location";
            this.buttonRentLocation.UseVisualStyleBackColor = true;
            this.buttonRentLocation.Click += new System.EventHandler(this.ButtonRentLocation_Click);
            // 
            // buttonUnRentLocation
            // 
            this.buttonUnRentLocation.Location = new System.Drawing.Point(611, 152);
            this.buttonUnRentLocation.Name = "buttonUnRentLocation";
            this.buttonUnRentLocation.Size = new System.Drawing.Size(220, 23);
            this.buttonUnRentLocation.TabIndex = 10;
            this.buttonUnRentLocation.Text = "Un-Rent Location";
            this.buttonUnRentLocation.UseVisualStyleBackColor = true;
            this.buttonUnRentLocation.Click += new System.EventHandler(this.ButtonUnRentLocation_Click);
            // 
            // buttonViewAvailableLocations
            // 
            this.buttonViewAvailableLocations.Location = new System.Drawing.Point(610, 698);
            this.buttonViewAvailableLocations.Name = "buttonViewAvailableLocations";
            this.buttonViewAvailableLocations.Size = new System.Drawing.Size(220, 23);
            this.buttonViewAvailableLocations.TabIndex = 11;
            this.buttonViewAvailableLocations.Text = "View Available Locations";
            this.buttonViewAvailableLocations.UseVisualStyleBackColor = true;
            this.buttonViewAvailableLocations.Click += new System.EventHandler(this.ButtonViewAvailableLocations_Click);
            // 
            // listViewRentedLocations
            // 
            this.listViewRentedLocations.AllowColumnReorder = true;
            this.listViewRentedLocations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.locationID,
            this.rentalStartDate});
            this.listViewRentedLocations.FullRowSelect = true;
            this.listViewRentedLocations.GridLines = true;
            this.listViewRentedLocations.Location = new System.Drawing.Point(31, 235);
            this.listViewRentedLocations.Name = "listViewRentedLocations";
            this.listViewRentedLocations.Size = new System.Drawing.Size(514, 457);
            this.listViewRentedLocations.TabIndex = 12;
            this.listViewRentedLocations.UseCompatibleStateImageBehavior = false;
            this.listViewRentedLocations.View = System.Windows.Forms.View.Details;
            // 
            // locationID
            // 
            this.locationID.Text = "Location ID";
            this.locationID.Width = 115;
            // 
            // rentalStartDate
            // 
            this.rentalStartDate.Text = "Rental Start Date";
            this.rentalStartDate.Width = 176;
            // 
            // listViewAvailableLocations
            // 
            this.listViewAvailableLocations.AllowColumnReorder = true;
            this.listViewAvailableLocations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.availableLocationID});
            this.listViewAvailableLocations.FullRowSelect = true;
            this.listViewAvailableLocations.GridLines = true;
            this.listViewAvailableLocations.Location = new System.Drawing.Point(610, 235);
            this.listViewAvailableLocations.Name = "listViewAvailableLocations";
            this.listViewAvailableLocations.Size = new System.Drawing.Size(221, 457);
            this.listViewAvailableLocations.TabIndex = 13;
            this.listViewAvailableLocations.UseCompatibleStateImageBehavior = false;
            this.listViewAvailableLocations.View = System.Windows.Forms.View.Details;
            // 
            // availableLocationID
            // 
            this.availableLocationID.Text = "Location ID";
            this.availableLocationID.Width = 213;
            // 
            // ManageLocations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 780);
            this.Controls.Add(this.listViewAvailableLocations);
            this.Controls.Add(this.listViewRentedLocations);
            this.Controls.Add(this.buttonViewAvailableLocations);
            this.Controls.Add(this.buttonUnRentLocation);
            this.Controls.Add(this.buttonRentLocation);
            this.Controls.Add(this.buttonSearchCompany);
            this.Controls.Add(this.textBoxLocationID);
            this.Controls.Add(this.textBoxCompanyID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ManageLocations";
            this.Text = "ManageLocations";
            this.Load += new System.EventHandler(this.ButtonFindCompanyLocations_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCompanyID;
        private System.Windows.Forms.TextBox textBoxLocationID;
        private System.Windows.Forms.Button buttonSearchCompany;
        private System.Windows.Forms.Button buttonRentLocation;
        private System.Windows.Forms.Button buttonUnRentLocation;
        private System.Windows.Forms.Button buttonViewAvailableLocations;
        private System.Windows.Forms.ListView listViewRentedLocations;
        private System.Windows.Forms.ListView listViewAvailableLocations;
        private System.Windows.Forms.ColumnHeader locationID;
        private System.Windows.Forms.ColumnHeader rentalStartDate;
        private System.Windows.Forms.ColumnHeader availableLocationID;
    }
}