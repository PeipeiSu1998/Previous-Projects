using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Client.Controller
{
    [Serializable]
    public class SocketRequest
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ACTION Action { get; set; }
        public object Obj { get; set; }
        public string LocationID { get; set; }
        public string CompanyID { get; set; }
        public string PalletID { get; set; }
        public DateTime RentalStart { get; set; }

        public enum ACTION
        {
            REGISTER_COMPANY,
            ASSIGN_LOCATION_TO_COMPANY,
            REMOVE_LOCATION_FROM_CURRENT_COMPANY,
            EDIT_COMPANY,
            EDIT_PALLET,
            GET_COMPANY_LIST,
            GET_COMPANY_BYID,
            STORE_PALLET,
            REMOVE_PALLET,
            GET_PALLET_BYID,
            GET_PALLET_LIST,
            GET_AVAILABLE_LOCATIONS,
            GET_LOCATION_BYID,
            GET_LOCATIONS_OF_CURRENT_COMPANY
        }
    }
}