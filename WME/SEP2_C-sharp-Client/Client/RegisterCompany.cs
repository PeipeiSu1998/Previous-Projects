using Client.Controller;
using Client.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class TheMainForm : Form
    {
        private CompanyController CompanyController = new CompanyController();
        
        /// <summary>
        ///Method for initializing the form of registering company
        /// </summary>
        public TheMainForm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Method that handling the click event of createing company's button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            bool validInput = false;


            if (textBoxCompanyID.Text == "") 
            {
                errorProvider1.SetError(textBoxCompanyID, "Please input company ID");
            }
            if (textBoxCompanyName.Text == "")
            {
                errorProvider1.SetError(textBoxCompanyName, "Please input company name");
            }
            if (textBoxCompanyEmail.Text == "")
            {
                errorProvider1.SetError(textBoxCompanyEmail, "Please input company email");
            }
            if (textBoxPhoneNumber.Text == "")
            {
                errorProvider1.SetError(textBoxPhoneNumber, "Please input company phone number");
            }
            if (textBoxCompanyID.Text.Length >= 1 && textBoxCompanyName.Text.Length >= 1 && textBoxCompanyEmail.Text.Length >= 1 && textBoxPhoneNumber.Text.Length >= 1)
            {
                validInput = true;
            }

            if (validInput)
            {
                Model.Company tempCompany = new Model.Company
                {
                    companyID = textBoxCompanyID.Text,
                    name = textBoxCompanyName.Text,
                    email = textBoxCompanyEmail.Text,
                    phone = int.Parse(textBoxPhoneNumber.Text)
                };

                CompanyController.registerCompany(tempCompany);

                validInput = false;
            }
        }


        /// <summary>
        /// Method that handling the click event of cancelling inputted company information's button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            textBoxCompanyID.Text = null;
            textBoxCompanyName.Text = null;
            textBoxCompanyEmail.Text = null;
            textBoxPhoneNumber.Text = null;

            Close();
        }
    }
}
