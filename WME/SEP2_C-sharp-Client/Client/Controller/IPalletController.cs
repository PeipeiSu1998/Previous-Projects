using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controller
{
    interface IPalletController
    {
        PalletList getAvailablePalletList();
        void storePallet(Pallet pallet);
        Pallet getPalletByID(string palletID, string companyID);
        void removePallet(string palletID, string companyID);
        void updatePallet(Pallet pallet);

    }
}
