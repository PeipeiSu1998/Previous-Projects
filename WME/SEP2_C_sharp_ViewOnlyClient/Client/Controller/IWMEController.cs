using Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controller
{
    interface IWMEController
    {
        CompanyList getCompanyList();
        LocationList getAvailableLocationList();
        PalletList getAvailablePalletList();
        Model.Company getCompanyByID(string companyID);
        Location getLocationByID(string locationID);
        Pallet getPalletByID(string palletID, string companyID);
    }
}
