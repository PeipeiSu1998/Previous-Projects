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
    public partial class ReleasePallet : Form
    {
        private PalletController PalletController = new PalletController();

        /// <summary>
        /// Method that initializing the release pallet's view
        /// </summary>
        public ReleasePallet()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Method that handling the click event of releasing pallet's button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReleasePallet_Click(object sender, EventArgs e)
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
            if (textBoxCompanyID.Text.Length >= 1 && textBoxPalletID.Text.Length >= 1)
            {
                validInput = true;
            }

            if (validInput)
            {
                PalletController.removePallet(textBoxPalletID.Text, textBoxCompanyID.Text);
            }
        }


        /// <summary>
        /// Method that handling the click event of cancelling inputted pallet information's button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            textBoxPalletID.Text = null;

            Close();
        }
    }
}
