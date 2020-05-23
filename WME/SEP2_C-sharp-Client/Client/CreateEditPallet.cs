using Client.Controller;
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
    public partial class CreateEditPallet : Form
    {
        private PalletController PalletController = new PalletController();
        private Pallet Pallet = new Pallet();

        public CreateEditPallet()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Method that managing the click event of create pallet button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCreatePallet_Click(object sender, EventArgs e)
        {
            bool validInput = false;


            if (textBoxCompanyID.Text == "")
            {
                errorProvider1.SetError(textBoxCompanyID, "Please input company ID");
            }
            if (textBoxPalletID.Text == "")
            {
                errorProvider1.SetError(textBoxPalletID, "Please input pallet ID");
            }
            if (textBoxLocationID.Text == "")
            {
                errorProvider1.SetError(textBoxLocationID, "Please input location ID");
            }
            if (textBoxPalletHeight.Text == "")
            {
                errorProvider1.SetError(textBoxPalletHeight, "Please input pallet height");
            }
            if (textBoxPalletArea.Text == "")
            {
                errorProvider1.SetError(textBoxPalletHeight, "Please input pallet area");
            }
            if (textBoxCompanyID.Text.Length >= 1 && textBoxPalletID.Text.Length >= 1 && textBoxLocationID.Text.Length >= 1 && textBoxPalletHeight.Text.Length >= 1 && textBoxPalletArea.Text.Length >= 1)
            {
                validInput = true;
            }

            if (validInput)
            {
                Pallet.arrivalDate = dateTimePicker.Value;
                Pallet.palletArea = double.Parse(textBoxPalletArea.Text);
                Pallet.palletHeight = double.Parse(textBoxPalletHeight.Text);
                Pallet.palletID = textBoxPalletID.Text;
                Pallet.locationID = textBoxLocationID.Text;
                Pallet.companyID = textBoxCompanyID.Text;

                PalletController.storePallet(Pallet);
            }
        }


        /// <summary>
        /// Method that managing the click event of update pallet button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdatePallet_Click(object sender, EventArgs e)
        {
            bool validInput = false;


            if (textBoxCompanyID.Text == "")
            {
                errorProvider1.SetError(textBoxCompanyID, "Please input company ID");
            }
            if (textBoxPalletID.Text == "")
            {
                errorProvider1.SetError(textBoxPalletID, "Please input pallet ID");
            }
            if (textBoxLocationID.Text == "")
            {
                errorProvider1.SetError(textBoxLocationID, "Please input location ID");
            }
            if (textBoxPalletHeight.Text == "")
            {
                errorProvider1.SetError(textBoxPalletHeight, "Please input pallet height");
            }
            if (textBoxPalletArea.Text == "")
            {
                errorProvider1.SetError(textBoxPalletArea, "Please input pallet area");
            }
            if (textBoxCompanyID.Text.Length >= 1 && textBoxPalletID.Text.Length >= 1 && textBoxLocationID.Text.Length >= 1 && textBoxPalletHeight.Text.Length >= 1 && textBoxPalletArea.Text.Length >= 1)
            {
                validInput = true;
            }

            if (validInput)
            {
                Pallet.arrivalDate = dateTimePicker.Value;
                Pallet.palletArea = double.Parse(textBoxPalletArea.Text);
                Pallet.palletHeight = double.Parse(textBoxPalletHeight.Text);
                Pallet.palletID = textBoxPalletID.Text;
                Pallet.locationID = textBoxLocationID.Text;
                Pallet.companyID = textBoxCompanyID.Text;

                PalletController.updatePallet(Pallet);
            }
        }
    }
}
