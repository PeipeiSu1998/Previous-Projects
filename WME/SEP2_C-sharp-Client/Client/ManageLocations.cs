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
    public partial class ManageLocations : Form
    {
        private CompanyController CompanyController = new CompanyController();
        private LocationController LocationController = new LocationController();
        private LocationList RentedLocationList = new LocationList();
        private LocationList AvailableLocationList = new LocationList();
        private ListAdapter ListAdapter = new ListAdapter();


        /// <summary>
        /// Method for initializing the manage location form
        /// </summary>
        public ManageLocations()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method that handling the click event of find company's locations' button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonFindCompanyLocations_Click(object sender, EventArgs e)
        {
            RentedLocationList = new LocationList();
            RentedLocationList = LocationController.getRentedLocationList(textBoxCompanyID.Text);
            updateRentedLocationsListView();
        }


        /// <summary>
        /// Method that handling the click event of renting a location to a company
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRentLocation_Click(object sender, EventArgs e)
        {
            if (textBoxLocationID.Text != null && textBoxCompanyID.Text != null)
                CompanyController.assignLocationToCompany(textBoxLocationID.Text, textBoxCompanyID.Text);

            RentedLocationList = new LocationList();
            AvailableLocationList = new LocationList();
            updateAvailableLocationsListView();
            updateRentedLocationsListView();
        }


        /// <summary>
        /// Method that handling the click event of the button for removing a location from the current company
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUnRentLocation_Click(object sender, EventArgs e)
        {
            CompanyController.removeLocationFromCurrentCompany(textBoxLocationID.Text);
            RentedLocationList = new LocationList();
            AvailableLocationList = new LocationList();
            updateAvailableLocationsListView();
            updateRentedLocationsListView();
        }


        /// <summary>
        /// Method that handling the click event of viewing all available locations' button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonViewAvailableLocations_Click(object sender, EventArgs e)
        {
            RentedLocationList = new LocationList();
            AvailableLocationList = new LocationList();

            AvailableLocationList = LocationController.getAvailableLocationList();
            updateAvailableLocationsListView();
            updateRentedLocationsListView();
        }

        /// <summary>
        /// Method that handling the click event of updating rented location list view's button
        /// </summary>
        private void updateRentedLocationsListView()
        {
            listViewRentedLocations.Items.Clear();
            List<string[]> adaptedRentedLocationsList = ListAdapter.GetAdaptedRentedLocationsList(RentedLocationList);

            foreach (string[] location in adaptedRentedLocationsList)
            {
                listViewRentedLocations.Items.Add(new ListViewItem(location));
            }

            paintLocationListRows();
        }

        /// <summary>
        /// Method that handling the click event of updating available location list view's button
        /// </summary>
        private void updateAvailableLocationsListView()
        {
            listViewAvailableLocations.Items.Clear();
            List<string[]> adaptedAvailableLocationsList = ListAdapter.GetAdaptedAvailableLocationsList(AvailableLocationList);

            foreach (string[] location in adaptedAvailableLocationsList)
            {
                listViewAvailableLocations.Items.Add(new ListViewItem(location));
            }

            paintLocationListRows();
        }

        /// <summary>
        /// Method that handling the click event of painting rows in list view for locations' button
        /// </summary>
        private void paintLocationListRows()
        {
            foreach (ListViewItem item in listViewRentedLocations.Items)
            {
                item.BackColor = item.Index % 2 == 0 ? Color.LightGray : Color.LightBlue;
            }

            foreach (ListViewItem item in listViewAvailableLocations.Items)
            {
                item.BackColor = item.Index % 2 == 0 ? Color.LightGray : Color.LightBlue;
            }
        }
    }
}
