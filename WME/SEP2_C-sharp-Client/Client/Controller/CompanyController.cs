using Client.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static Client.Controller.SocketRequest;

namespace Client.Controller
{
    class CompanyController : ICompanyController
    {
        private SocketRequest SocketRequest = new SocketRequest();
        private readonly CommunicationController communicationController;

        public CompanyController()
        {
            communicationController = CommunicationController.GetInstance();
        }

        public void assignLocationToCompany(string locationID, string companyID)
        {
            SocketRequest = new SocketRequest();
            SocketRequest.Action = ACTION.ASSIGN_LOCATION_TO_COMPANY;
            SocketRequest.LocationID = locationID;
            SocketRequest.CompanyID = companyID;

            //serializing to Json
            string requestAsJSON = JsonConvert.SerializeObject(SocketRequest);

            //send request
            communicationController.SendMessage(requestAsJSON);

            // used for testing purposes
            string JsonString = communicationController.ReadReplyMessage();
            bool response = false;
            if (JsonString.Equals("success")) { response = true; }
            communicationController.clientSocket.Close();
            //return response;
        }

        public void editCompany(Model.Company company)
        {
            SocketRequest = new SocketRequest();
            SocketRequest.Action = ACTION.EDIT_COMPANY;
            SocketRequest.Obj = company;

            //serializing to Json
            string requestAsJSON = JsonConvert.SerializeObject(SocketRequest);

            //send request
            communicationController.SendMessage(requestAsJSON);

            // used for testing purposes
            string JsonString = communicationController.ReadReplyMessage();
            bool response = false;
            if (JsonString.Equals("success")) { response = true; }
            communicationController.clientSocket.Close();
            //return response;
        }

        public Model.Company getCompanyByID(string companyID)
        {
            SocketRequest = new SocketRequest();
            SocketRequest.Action = ACTION.GET_COMPANY_BYID;
            SocketRequest.CompanyID = companyID;

            //send request
            string requestAsJSON = JsonConvert.SerializeObject(SocketRequest);
            communicationController.SendMessage(requestAsJSON);

            // used for testing purposes
            string JsonString = communicationController.ReadReplyMessage();

            Model.Company tempCompany = new Model.Company();
            communicationController.clientSocket.NoDelay = true;

            //deserializing
            tempCompany = JsonConvert.DeserializeObject<Model.Company>(JsonString);

            communicationController.clientSocket.Close();
            if (tempCompany.companyID == null)
                return null;
            else
                return tempCompany;
        }

        public CompanyList getCompanyList()
        {
            //create request
            SocketRequest socketRequest = new SocketRequest();
            socketRequest.Action = ACTION.GET_COMPANY_LIST;

            //seriliazing to JSON
            string requestAsJSON = JsonConvert.SerializeObject(socketRequest);

            //send request 
            communicationController.SendMessage(requestAsJSON);

            //read resultset
            string JsonString = communicationController.ReadReplyMessage();

            CompanyList companyList = new CompanyList();
            communicationController.clientSocket.NoDelay = true;
            //deseriliasing 
            companyList = JsonConvert.DeserializeObject<CompanyList>(JsonString);


            communicationController.clientSocket.Close();

            return companyList;
        }
        
        /// <summary>
        /// Takes a company object, converts it into JSON and sends it to the java server. Expect a server reply used for tests.
        /// </summary>
        /// <param name="company"></param>
        public void registerCompany(Model.Company company)
        {
            SocketRequest = new SocketRequest();
            SocketRequest.Action = ACTION.REGISTER_COMPANY;
            SocketRequest.Obj = company;
            //send request
            string requestAsJSON = JsonConvert.SerializeObject(SocketRequest);
            communicationController.SendMessage(requestAsJSON);

            // used for testing purposes
            string JsonString = communicationController.ReadReplyMessage();
            bool response = false;
            if (JsonString.Equals("success")) { response = true; }
            communicationController.clientSocket.Close();
            //return response;
        }

        public void removeLocationFromCurrentCompany(string locationID)
        {
            SocketRequest = new SocketRequest();
            SocketRequest.Action = ACTION.REMOVE_LOCATION_FROM_CURRENT_COMPANY;
            SocketRequest.LocationID = locationID;
            //send request
            string requestAsJSON = JsonConvert.SerializeObject(SocketRequest);
            communicationController.SendMessage(requestAsJSON);

            // used for testing purposes
            string JsonString = communicationController.ReadReplyMessage();
            bool response = false;
            if (JsonString.Equals("success")) { response = true; }
            communicationController.clientSocket.Close();
            //return response;
        }
    }
}
