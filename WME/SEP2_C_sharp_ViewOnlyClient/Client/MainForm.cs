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
        private WMEController WMEController = new WMEController();
        private CompanyList CompanyList = new CompanyList();
        private LocationList LocationList = new LocationList();
        private PalletList PalletList = new PalletList();
        private ListAdapter ListAdapter = new ListAdapter();
        private Company Company = new Company();
        private Pallet Pallet = new Pallet();

        public MainForm()
        {
            InitializeComponent();
        }

        private void ButtonSearchCompany_Click(object sender, EventArgs e)
        {
            CompanyList.companies = new List<Company>();
            Company = WMEController.getCompanyByID(textBoxCompanyID.Text);
            if (Company != null)
                CompanyList.companies.Add(Company);
            updateCompanyListView();
        }

        private void ButtonViewAllCompanies_Click(object sender, EventArgs e)
        {
            //orderList = administratorService.GetOrdersList();
            CompanyList = WMEController.getCompanyList();
            updateCompanyListView();
        }

        private void ButtonSearchPallet_Click(object sender, EventArgs e)
        {
            Pallet = null;
            Pallet = WMEController.getPalletByID(textBoxPalletIDs.Text, textBoxCompanyID.Text);
            if (Pallet != null)
                PalletList.pallets.Add(Pallet);
            updatePalletListView();
        }

        private void ButtonViewAll_Click(object sender, EventArgs e)
        {
            PalletList = WMEController.getAvailablePalletList();
            updatePalletListView();
        }
        public void ButtonViewAllAvalableLocations_Click(object sender, EventArgs e)
        {
            LocationList = WMEController.getAvailableLocationList();
            updateAvailableLocationListView();
        }

        /// <summary>
        /// update company list view
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
        /// update pallet list view
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
        /// update location list view
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
        /// painting rows in list view for companies
        /// </summary>
        private void paintCompanyRows()
        {
            foreach (ListViewItem item in listViewCompanyIDs.Items)
            {
                item.BackColor = item.Index % 2 == 0 ? Color.LightGray : Color.LightBlue;
            }
        }

        /// <summary>
        /// painting rows in list view for pallets
        /// </summary>
        private void paintPalletRows()
        {
            foreach (ListViewItem item in listViewPallets.Items)
            {
                item.BackColor = item.Index % 2 == 0 ? Color.LightGray : Color.LightBlue;
            }
        }

        /// <summary>
        /// painting rows in list view for locations
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
