using Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controller
{
    interface ICompanyController
    {
        CompanyList getCompanyList();
        void registerCompany(Model.Company company);
        void assignLocationToCompany(string locationID, string companyID);
        Model.Company getCompanyByID(string companyID);
        void removeLocationFromCurrentCompany(string locationID);
        void editCompany(Model.Company company);
    }
}
