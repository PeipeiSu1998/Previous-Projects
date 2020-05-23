using Client.Controller;

namespace Client.Model
{
    public class Company
    {
        public string name { get; set; }
        public string companyID { get; set; }
        public int phone { get; set; }
        public string email { get; set; }
        public LocationList locationList { get; set; }
    }
}