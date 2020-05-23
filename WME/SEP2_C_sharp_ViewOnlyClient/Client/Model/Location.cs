using System;

namespace Client.Controller
{
    public class Location
    {
        public string locationID { get; set; }
        public string rentalStart { get; set; }
        public PalletList palletList { get; set; }
    }
}