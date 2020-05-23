using Kommunity_WebApp.Models;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;


namespace Kommunity_WebApp.Services
{
    public static class Service
    {


        public static User findUser(User user)
        {
            // Initialize a new socket connection to communicate with the database server 
            Connection con = new Connection();

            // Send the service name so the DatabaseServer knows what to expect
          string commandName = "findUser";
           con.sw.WriteLine(commandName);
            con.sw.Flush();
            // read confirmation from server
      //      con.sr.ReadLine();
            // Convert the object to Json string and send it
            string json = JsonConvert.SerializeObject(user);
            con.sw.WriteLine(json);
            con.sw.Flush();

            try
            {
                // Read the responce from database server
                string fromServer = con.sr.ReadLine();

                /*
                for some reason, the received json string has 2 strange characters in the beginning,
                This makes the program not able to convert it to User object,
                next code line is to remove these characters.
                 */
                string result = fromServer.Substring(2);

                // Convert the responce from Json to User object and return it
                User u = JsonConvert.DeserializeObject<User>(result);
                return u;

            }
            catch
            {
                return null;


            }



        }

        public static User signup(User user)
        {
            // Initialize a new socket connection to communicate with the database server 
            Connection con = new Connection();

            // Send the service name so the DatabaseServer knows what to expect
            string commandName = "signup";
            con.sw.WriteLine(commandName);
            con.sw.Flush();
            // read confirmation from server
          //  con.sr.ReadLine();


            // Convert the object to Json string and send it
            string json = JsonConvert.SerializeObject(user);
            con.sw.WriteLine(json);
            con.sw.Flush();

            try
            {
                // Read the responce from database server
                string fromServer = con.sr.ReadLine();
                // Convert the responce from Json to User object and return it
                string result = fromServer.Substring(2);
                User u = JsonConvert.DeserializeObject<User>(result);
                return u;
            }
            catch
            {
                return null;


            }

        }

        public static bool changePassword(User user, string old, string nu)
        {
            // Initialize a new socket connection to communicate with the database server 
            Connection con = new Connection();

            // Check if the old password is correct
            user.password = old;
            User result = findUser(user);

            // Send the service name so the DatabaseServer knows what to expect
            string commandName = "changePassword";
            con.sw.WriteLine(commandName);
            // read confirmation from server
            con.sr.ReadLine();

            // Change password
            result.password = nu;

            // Convert the object to Json string and send it
            string json = JsonConvert.SerializeObject(result);
            con.sw.WriteLine(json);
            con.sw.Flush();

            try
            {
                // Read the responce from database server
                string fromServer = con.sr.ReadLine();
                // Convert the responce from Json to User object and return result
                User u = JsonConvert.DeserializeObject<User>(fromServer);
                if (u.password.Equals(nu))
                {
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;


            }

        }

        public static bool changeEmail(User user, string newEmail)
        {
            // Initialize a new socket connection to communicate with the database server 
            Connection con = new Connection();

            // Find the user

            User result = findUser(user);

            // Send the service name so the DatabaseServer knows what to expect
            string commandName = "changeEmail";
            con.sw.WriteLine(commandName);
            // read confirmation from server
            con.sr.ReadLine();

            // Change email
            result.email = newEmail;

            // Convert the object to Json string and send it
            string json = JsonConvert.SerializeObject(result);
            con.sw.WriteLine(json);
            con.sw.Flush();

            try
            {
                // Read the responce from database server
                string fromServer = con.sr.ReadLine();
                // Convert the responce from Json to User object and return the result
                User u = JsonConvert.DeserializeObject<User>(fromServer);
                if (u.email.Equals(newEmail))
                {
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;


            }

        }

        public static bool changeCity(User user, string newCity)
        {
            // Initialize a new socket connection to communicate with the database server 
            Connection con = new Connection();

            // Find the user

            User result = findUser(user);

            // Send the service name so the DatabaseServer knows what to expect
            string commandName = "changeCity";
            con.sw.WriteLine(commandName);
            // read confirmation from server
            con.sr.ReadLine();

            // Change city
           // result.city = newCity;

            // Convert the object to Json string and send it
            string json = JsonConvert.SerializeObject(result);
            con.sw.WriteLine(json);
            con.sw.Flush();

            try
            {
                // Read the responce from database server
                string fromServer = con.sr.ReadLine();
                // Convert the responce from Json to User object and return the result
                User u = JsonConvert.DeserializeObject<User>(fromServer);
                if (u.city.Equals(newCity))
                {
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;


            }

        }

        public static bool changeRole(User user, string newRole)
        {
            // Initialize a new socket connection to communicate with the database server 
            Connection con = new Connection();

            // Find the user

            User result = findUser(user);

            // Send the service name so the DatabaseServer knows what to expect
            string commandName = "changeRole";
            con.sw.WriteLine(commandName);
            // read confirmation from server
            con.sr.ReadLine();

            // Change Role
            result.role = newRole;

            // Convert the object to Json string and send it
            string json = JsonConvert.SerializeObject(result);
            con.sw.WriteLine(json);
            con.sw.Flush();

            try
            {
                // Read the responce from database server
                string fromServer = con.sr.ReadLine();
                // Convert the responce from Json to User object and return the result
                User u = JsonConvert.DeserializeObject<User>(fromServer);
                if (u.role.Equals(newRole))
                {
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;


            }

        }

        public static bool officialPost(OfficialPost post)
        {

            // Initialize a new socket connection to communicate with the database server 
            Connection con = new Connection();

            // Send the service name so the DatabaseServer knows what to expect
            string commandName = "officialPost";
            con.sw.WriteLine(commandName);
            // read confirmation from server
            con.sr.ReadLine();

            // Convert the object to Json string and send it
            string json = JsonConvert.SerializeObject(post);
            con.sw.WriteLine(json);
            con.sw.Flush();

            try
            {
                // Read the responce from database server
                string fromServer = con.sr.ReadLine();
                // Convert the responce from Json to OfficialPost
                OfficialPost p = JsonConvert.DeserializeObject<OfficialPost>(fromServer);
                if (p.Equals(post))
                {
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;


            }



        }

        public static bool approvePetition(Petition petition)
        {

            // Initialize a new socket connection to communicate with the database server 
            Connection con = new Connection();

            // Send the service name so the DatabaseServer knows what to expect
            string commandName = "approvePetition";
            con.sw.WriteLine(commandName);
            // read confirmation from server
            con.sr.ReadLine();

            // Convert the object to Json string and send it
            string json = JsonConvert.SerializeObject(petition);
            con.sw.WriteLine(json);
            con.sw.Flush();

            try
            {
                // Read the responce from database server
                string fromServer = con.sr.ReadLine();
                // Convert the responce from Json to OfficialPost
                Petition p = JsonConvert.DeserializeObject<Petition>(fromServer);
                if (p.Equals(petition))
                {
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;


            }



        }


        public static bool Post(Post post)
        {

            // Initialize a new socket connection to communicate with the database server 
            Connection con = new Connection();

            // Send the service name so the DatabaseServer knows what to expect
            string commandName = "Post";
            con.sw.WriteLine(commandName);
            // read confirmation from server
           // con.sr.ReadLine();

            // Convert the object to Json string and send it
            string json = JsonConvert.SerializeObject(post);
            con.sw.WriteLine(json);
            con.sw.Flush();

            try
            {
                // Read the responce from database server
                string fromServer = con.sr.ReadLine();
                // Convert the responce from Json to Post
                Post p = JsonConvert.DeserializeObject<Post>(fromServer);
                if (p.Equals(post))
                {
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;


            }

        }

        public static bool DeletePost(Post post)
        {

            // Initialize a new socket connection to communicate with the database server 
            Connection con = new Connection();

            // Send the service name so the DatabaseServer knows what to expect
            string commandName = "DeletePost";
            con.sw.WriteLine(commandName);
            // read confirmation from server
            con.sr.ReadLine();

            // Convert the object to Json string and send it
            string json = JsonConvert.SerializeObject(post);
            con.sw.WriteLine(json);
            con.sw.Flush();

            try
            {
                // Read the responce from database server
                string fromServer = con.sr.ReadLine();
                // Convert the responce from Json to OfficialPost
                Post p = JsonConvert.DeserializeObject<Post>(fromServer);
                if (p.Equals(post))
                {
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;


            }



        }

        public static bool MakePetition(Petition petition)
        {

            // Initialize a new socket connection to communicate with the database server 
            Connection con = new Connection();

            // Send the service name so the DatabaseServer knows what to expect
            string commandName = "MakePetition";
            con.sw.WriteLine(commandName);
            // read confirmation from server
          //  con.sr.ReadLine();

            // Convert the object to Json string and send it
            string json = JsonConvert.SerializeObject(petition);
            con.sw.WriteLine(json);
            con.sw.Flush();

            try
            {
                // Read the responce from database server
                string fromServer = con.sr.ReadLine();
                // Convert the responce from Json to Petition
                Petition p = JsonConvert.DeserializeObject<Petition>(fromServer);
                if (p.Equals(petition))
                {
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;


            }



        }


        public static List<Petition> getPetitions(string command, string city)
        {

            // Initialize a new socket connection to communicate with the database server 
            Connection con = new Connection();

            // Send the service name so the DatabaseServer knows what to expect
            con.sw.WriteLine(command);
            con.sw.Flush();
            // read confirmation from server
            //  con.sr.ReadLine();

            // Send city name
            con.sw.WriteLine(city);
            con.sw.Flush();

            try
            {
                // Read the responce from database server
                string fromServer = con.sr.ReadLine();
                // Convert the responce from Json to a list of petitions
                
                string result = fromServer.Substring(2);
                var records = JsonConvert.DeserializeObject<List<Petition>>(result);
                return records;
            }
            catch
            {
                return null;
            }
        }

        public static List<Petition> getApprovedPetitions(string city)
        {

            return getPetitions("getAllPetitions", city);

        }


        public static List<Petition> getUnapprovedPetitions(string city)
        {

            // Initialize a new socket connection to communicate with the database server 
            Connection con = new Connection();

            // Send the service name so the DatabaseServer knows what to expect
            con.sw.WriteLine("getUnapprovedPetitions");
            con.sw.Flush();
            // read confirmation from server
            //  con.sr.ReadLine();

            // Send city name
            con.sw.WriteLine(city);
            con.sw.Flush();

            try
            {
                // Read the responce from database server
                string fromServer = con.sr.ReadLine();
                // Convert the responce from Json to a list of petitions

               // string result = fromServer.Substring(2);
                var records = JsonConvert.DeserializeObject<List<Petition>>(fromServer);
                return records;
            }
            catch
            {
                return null;
            }

        }


        public static List<OfficialPost> getNews(string city)
        {

            // Initialize a new socket connection to communicate with the database server 
            Connection con = new Connection();

            // Send the service name so the DatabaseServer knows what to expect
            string commandName = "getNews";
            con.sw.WriteLine(commandName);
            // read confirmation from server
            con.sr.ReadLine();

            // Send city name
            con.sw.WriteLine(city);
            con.sw.Flush();

            try
            {
                // Read the responce from database server
                string fromServer = con.sr.ReadLine();
                // Convert the responce from Json to a list of news

                List<OfficialPost> list = new List<OfficialPost>();
                list.Equals(JsonConvert.DeserializeObject<OfficialPost>(fromServer)); // Is this line correct??
                return list;
            }
            catch
            {
                return null;
            }
        }

        public static List<Post> getPosts(string city)
        {

            // Initialize a new socket connection to communicate with the database server 
            Connection con = new Connection();

            // Send the service name so the DatabaseServer knows what to expect
            string commandName = "getPosts";
            con.sw.WriteLine(commandName);
            con.sw.Flush();
            // read confirmation from server
            //  con.sr.ReadLine();

            // Send city name
            con.sw.WriteLine(city);
            con.sw.Flush();

            try
            {
                // Read the responce from database server
                string fromServer = con.sr.ReadLine();
                // Convert the responce from Json to a list of news

                //    List<Post> list = new List<Post>();

                string result = fromServer.Substring(2);
                var records = JsonConvert.DeserializeObject<List<Post>>(result);

             //   list = JsonConvert.DeserializeObject<Post>(fromServer) ; // Is this line correct??
                return records;
            }
            catch
            {
                return null;
            }
        }


        public static bool vote(User voter, Petition petition)
        {
            // Initialize a new socket connection to communicate with the database server 
            Connection con = new Connection();

            // Send the service name so the DatabaseServer knows what to expect
            string commandName = "vote";
            con.sw.WriteLine(commandName);
            // read confirmation from server
            con.sr.ReadLine();

            // Convert the objects to Json strings and send them
            string v = JsonConvert.SerializeObject(voter);
            con.sw.WriteLine(v);
            string p = JsonConvert.SerializeObject(voter);
            con.sw.WriteLine(p);
            con.sw.Flush();

            try
            {
                // Read the responce from database server
                string fromServer = con.sr.ReadLine();
                if(fromServer.Equals("success")){
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;


            }

        }


        public static bool sendMessage(User sender, User receiver, Message message)
        {
            // Initialize a new socket connection to communicate with the database server 
            Connection con = new Connection();

            // Send the service name so the DatabaseServer knows what to expect
            string commandName = "sendMessage";
            con.sw.WriteLine(commandName);
            // read confirmation from server
            con.sr.ReadLine();

            // Convert the objects to Json strings and send them
            string s = JsonConvert.SerializeObject(sender);
            con.sw.WriteLine(s);
            string r = JsonConvert.SerializeObject(receiver);
            con.sw.WriteLine(r);
            string m = JsonConvert.SerializeObject(message);
            con.sw.WriteLine(m);
            con.sw.Flush();

            try
            {
                // Read the responce from database server
                string fromServer = con.sr.ReadLine();
                if(fromServer.Equals("success")){
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;


            }

        }


        public static List<Message> getMessages(User user)
        {

            // Initialize a new socket connection to communicate with the database server 
            Connection con = new Connection();

            // Send the service name so the DatabaseServer knows what to expect
            string commandName = "getMessages";
            con.sw.WriteLine(commandName);
            // read confirmation from server
            con.sr.ReadLine();

            // Convert the objects to Json strings and send them
            string u = JsonConvert.SerializeObject(user);
            con.sw.WriteLine(u);
            con.sw.Flush();

            try
            {
                // Read the responce from database server
                string fromServer = con.sr.ReadLine();
                // Convert the responce from Json to a list of petitions

                List<Message> list = new List<Message>();
                list.Equals(JsonConvert.DeserializeObject<Message>(fromServer)); // Is this line correct??
                return list;
            }
            catch
            {
                return null;
            }
        }


        






    }


}
