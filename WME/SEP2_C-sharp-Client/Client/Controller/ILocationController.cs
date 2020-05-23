using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controller
{
    interface ILocationController
    {
        LocationList getAvailableLocationList();
        Location getLocationByID(string locationID);
    }
}
