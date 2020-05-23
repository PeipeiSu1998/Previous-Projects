using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Client.Controller.SocketRequest;

namespace Client.Controller
{
    class LocationController : ILocationController
    {
        private SocketRequest SocketRequest = new SocketRequest();
        private readonly CommunicationController communicationController;

        public LocationController()
        {
            communicationController = CommunicationController.GetInstance();
        }
        public LocationList getAvailableLocationList()
        {
            SocketRequest = new SocketRequest();
            SocketRequest.Action = ACTION.GET_AVAILABLE_LOCATIONS;
            //send request
            string requestAsJSON = JsonConvert.SerializeObject(SocketRequest);
            communicationController.SendMessage(requestAsJSON);

            // used for testing purposes
            string JsonString = communicationController.ReadReplyMessage();

            LocationList tempLocationList = new LocationList();
            communicationController.clientSocket.NoDelay = true;

            //deserializing
            tempLocationList = JsonConvert.DeserializeObject<LocationList>(JsonString);

            communicationController.clientSocket.Close();
            return tempLocationList;
        }

        public LocationList getRentedLocationList(string companyID)
        {
            SocketRequest = new SocketRequest();
            SocketRequest.Action = ACTION.GET_LOCATIONS_OF_CURRENT_COMPANY;
            SocketRequest.CompanyID = companyID;
            //send request
            string requestAsJSON = JsonConvert.SerializeObject(SocketRequest);
            communicationController.SendMessage(requestAsJSON);

            // used for testing purposes
            string JsonString = communicationController.ReadReplyMessage();

            LocationList tempLocationList = new LocationList();
            communicationController.clientSocket.NoDelay = true;

            //deserializing
            tempLocationList = JsonConvert.DeserializeObject<LocationList>(JsonString);

            communicationController.clientSocket.Close();
            return tempLocationList;
        }

        public Location getLocationByID(string locationID)
        {
            //create request
            SocketRequest socketRequest = new SocketRequest();
            socketRequest.Action = ACTION.GET_LOCATION_BYID;
            socketRequest.LocationID = locationID;

            //seriliazing to JSON
            string requestAsJSON = JsonConvert.SerializeObject(socketRequest);

            //send request 
            communicationController.SendMessage(requestAsJSON);

            //read resultset
            string JsonString = communicationController.ReadReplyMessage();

            Location location = new Location();
            communicationController.clientSocket.NoDelay = true;
            //deseriliasing 
            location = JsonConvert.DeserializeObject<Location>(JsonString);


            communicationController.clientSocket.Close();

            return location;
        }

    }
}
