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
    public partial class MainForm : Form
    {
        private CompanyController CompanyController = new CompanyController();
        private PalletController PalletController = new PalletController();
        private LocationController LocationController = new LocationController();
        private CompanyList CompanyList = new CompanyList();
        private LocationList LocationList = new LocationList();
        private PalletList PalletList = new PalletList();
        private ListAdapter ListAdapter = new ListAdapter();
        private Company Company = new Company();
        private Pallet Pallet = new Pallet();


        /// <summary>
        /// Method for initializing and openning the main form
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Method that handling the click event of search company button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSearchCompany_Click(object sender, EventArgs e)
        {
            CompanyList.companies = new List<Company>();
            Company = CompanyController.getCompanyByID(textBoxCompanyID.Text);
            if (Company != null)
                CompanyList.companies.Add(Company);
            updateCompanyListView();
        }


        /// <summary>
        /// Method that handling the click event of viewing all companies button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonViewAllCompanies_Click(object sender, EventArgs e)
        {
            CompanyList = CompanyController.getCompanyList();
            updateCompanyListView();
        }


        /// <summary>
        /// Method that handling the click event of searching pallet button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSearchPallet_Click(object sender, EventArgs e)
        {
            PalletList.pallets = new List<Pallet>();
            Pallet = PalletController.getPalletByID(textBoxPalletIDs.Text, textBoxCompanyID.Text);
            if (Pallet != null)
                PalletList.pallets.Add(Pallet);
            updatePalletListView();
        }


        /// <summary>
        /// Method that handling the click event of viewing all available pallet button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonViewAll_Click(object sender, EventArgs e)
        {
            PalletList = PalletController.getAvailablePalletList();
            updatePalletListView();
        }


        /// <summary>
        /// Method that handling the click event of viewing all available location button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ButtonViewAllAvalableLocations_Click(object sender, EventArgs e)
        {
            LocationList = LocationController.getAvailableLocationList();
            updateAvailableLocationListView();
        }

        /// <summary>
        /// Used when the "Register" tool strip item from "Company" is clicked to open a new form for company registration.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TheMainForm frm = new TheMainForm();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
        }


        /// <summary>
        /// Method that handling the click event of editing company information button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCompany frm = new EditCompany();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
        }


        /// <summary>
        /// Method that handling the click event of editing location information button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageLocationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageLocations frm = new ManageLocations();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
        }


        /// <summary>
        /// Method that handling the click event of inserting pallet button with its information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEditPallet frm = new CreateEditPallet();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
        }


        /// <summary>
        /// Method that handling the click event of removing a pallet from the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleasePallet frm = new ReleasePallet();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
        }


        /// <summary>
        /// Method for updating company list view
        /// </summary>
        private void updateCompanyListView()
        {
            listViewCompanyIDs.Items.Clear();
            List<string[]> adaptedCompanyList = ListAdapter.GetAdaptedAllCompanyList(CompanyList);

            foreach (string[] company in adaptedCompanyList)
            {
                listViewCompanyIDs.Items.Add(new ListViewItem(company));
            }

            paintCompanyRows();
        }


        /// <summary>
        /// Method for updating pallet list view
        /// </summary>
        private void updatePalletListView()
        {
            listViewPallets.Items.Clear();
            List<string[]> adaptedPalletList = ListAdapter.GetAdaptedAllPalletsList(PalletList);

            foreach (string[] pallet in adaptedPalletList)
            {
                listViewPallets.Items.Add(new ListViewItem(pallet));
            }

            paintPalletRows();
        }

        /// <summary>
        /// Method for updating location list view
        /// </summary>
        private void updateAvailableLocationListView()
        {
            listViewAvailableLocations.Items.Clear();
            List<string[]> adaptedLocationsList = ListAdapter.GetAdaptedAvailableLocationsList(LocationList);

            foreach (string[] pallet in adaptedLocationsList)
            {
                listViewAvailableLocations.Items.Add(new ListViewItem(pallet));
            }

            paintLocationRows();
        }

        /// <summary>
        ///Method for painting rows in list view for companies
        /// </summary>
        private void paintCompanyRows()
        {
            foreach (ListViewItem item in listViewCompanyIDs.Items)
            {
                item.BackColor = item.Index % 2 == 0 ? Color.LightGray : Color.LightBlue;
            }
        }

        /// <summary>
        /// Method for painting rows in list view for pallets
        /// </summary>
        private void paintPalletRows()
        {
            foreach (ListViewItem item in listViewPallets.Items)
            {
                item.BackColor = item.Index % 2 == 0 ? Color.LightGray : Color.LightBlue;
            }
        }

        /// <summary>
        /// Method painting rows in list view for locations
        /// </summary>
        private void paintLocationRows()
        {
            foreach (ListViewItem item in listViewAvailableLocations.Items)
            {
                item.BackColor = item.Index % 2 == 0 ? Color.LightGray : Color.LightBlue;
            }
        }

    }
}
