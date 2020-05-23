using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Client.Controller.SocketRequest;

namespace Client.Controller
{
    class PalletController : IPalletController
    {
        private SocketRequest SocketRequest = new SocketRequest();
        private readonly CommunicationController communicationController;

        public PalletController()
        {
            communicationController = CommunicationController.GetInstance();
        }
        public void updatePallet(Pallet pallet)
        {
            SocketRequest = new SocketRequest();
            SocketRequest.Action = ACTION.EDIT_PALLET;
            SocketRequest.Obj = pallet;

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

        public PalletList getAvailablePalletList()
        {
            SocketRequest = new SocketRequest();
            SocketRequest.Action = ACTION.GET_PALLET_LIST;
            //send request
            string requestAsJSON = JsonConvert.SerializeObject(SocketRequest);
            communicationController.SendMessage(requestAsJSON);

            // used for testing purposes
            string JsonString = communicationController.ReadReplyMessage();

            PalletList tempPalletList = new PalletList();
            communicationController.clientSocket.NoDelay = true;

            //deserializing
            tempPalletList = JsonConvert.DeserializeObject<PalletList>(JsonString);

            communicationController.clientSocket.Close();
            return tempPalletList;
        }

        public Pallet getPalletByID(string palletID, string companyID)
        {
            //create request
            SocketRequest socketRequest = new SocketRequest();
            socketRequest.Action = ACTION.GET_PALLET_BYID;
            socketRequest.PalletID = palletID;
            socketRequest.CompanyID = companyID;

            //seriliazing to JSON
            string requestAsJSON = JsonConvert.SerializeObject(socketRequest);

            //send request 
            communicationController.SendMessage(requestAsJSON);

            //read resultset
            string JsonString = communicationController.ReadReplyMessage();

            Pallet pallet = new Pallet();
            communicationController.clientSocket.NoDelay = true;
            //deseriliasing 
            pallet = JsonConvert.DeserializeObject<Pallet>(JsonString);


            communicationController.clientSocket.Close();
            if (pallet.palletID == null)
                return null;
            else
                return pallet;
        }

        public void removePallet(string palletID, string companyID)
        {
            SocketRequest = new SocketRequest();
            SocketRequest.Action = ACTION.REMOVE_PALLET;
            SocketRequest.PalletID = palletID;
            SocketRequest.CompanyID = companyID;

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

        public void storePallet(Pallet pallet)
        {
            SocketRequest = new SocketRequest();
            SocketRequest.Action = ACTION.STORE_PALLET;
            SocketRequest.Obj = pallet;

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
