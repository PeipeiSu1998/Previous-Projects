//package Main;
//
//import java.io.DataInputStream;
//import java.io.DataOutputStream;
//import java.io.IOException;
//import java.net.ServerSocket;
//import java.net.Socket;
//import java.sql.Connection;
//import java.sql.DriverManager;
//import java.sql.ResultSet;
//import java.sql.SQLException;
//import java.sql.Statement;
//import java.util.ArrayList;
//import java.util.Date;
//
//import com.google.gson.Gson;
//import Common.*;
//
//public class Main {
//	
//	static ArrayList <Citizen> citizens= new ArrayList <Citizen>();
//	static ArrayList <User> users= new ArrayList <User>();
//	static ArrayList <Post> posts= new ArrayList <Post>();
//	
//	static ServerSocket ss;
//	static Socket s ;
//	static DataInputStream is ;
//	static DataOutputStream os ;
//
//	
//
//	public static void main(String[] args) throws IOException {
//		
//		ss = new ServerSocket(8888);
//		System.out.println("Waiting for client request...");
//		
//		populate();
//
//		
//		socketConnection();
//		
//
//	}
//	
//public static void Command(String input) throws IOException {
//
//		switch (input) {
//
//		case "findUser":
//			login();
//			break;
//		case "signup":
//			registerConnection();
//			break;
////		/*case "changeCity":
////			this.changeCity();
////			break;*/
////		case "changeEmail":
////			this.changeEmail();
////			break;
////		case "changePassword":
////			this.changePassword();
////			break;
////		case "changeRole":
////			this.changeRole();
////			break;
////		case "approvePetition":
////			this.approvePetition();
////			break;
////		case "officialPost":
////			this.officialPost();
////			break;
////		case "Post":
////			this.post();
////			break;
////		case "deletePost":
////			this.deletePost();
////			break;
////		case "makePetition":
////			this.makePetition();
////			break;
////		case "sendMessage":
////			this.sendMessage();
////			break;
//		case "getPosts":
//			getPosts();
//			break;
////		case "getApprovedPetitions":
////			this.getApprovedPetitions();
////			break;
////		case "getUnapprovedPetitions":
////			this.getUnapprovedPetitions();
////			break;
//			
//		default:
//			System.out.println("Unrecognized command received!");
//			break;
//
//		}
//
//	}
//
//	public static void socketConnection() throws IOException {
//
//		while( true) {
//			// Waiting on the welcoming socket for contact by the client
//			s = ss.accept();
//			System.out.println("Client connected");
//
//			is = new DataInputStream(s.getInputStream());
//			os = new DataOutputStream(s.getOutputStream());
//
//			// Read from client
//
//				String fromClient = is.readLine();
//				System.out.println("This command is from client: "+fromClient);
//				
//				Command(fromClient);
//			
//		}
//
//	}
//
//	public static void login() throws IOException{
//		String fromClient = is.readLine();
//		System.out.println("This user is from client: "+fromClient);
//		Gson gson = new Gson();
//		User userFromClient = gson.fromJson(fromClient, User.class);
//		System.out.println("Converted from json: "+userFromClient);
//		User userToReturn = new User();
//		for(User u : users) {
//			if(userFromClient.getCpr().equals(u.getCpr())&& userFromClient.GetPassword().equals(u.GetPassword())) {
//				userToReturn = u;
//			}
//		}
//		
//		
//		// Convert the result user object to json string
//		String json = gson.toJson(userToReturn);
//		System.out.println("Found in database: "+userToReturn.getCpr() + " ...with pwd: "+ userToReturn.GetPassword());
//		System.out.println("Sending to client: "+json);
//		// Send user object in json format
//		
//
//
//		os.writeUTF(json);
//
//		s.close();
//		System.out.println("Responce sent to client!");
//
//	}
//	
//	static void getPosts() throws IOException{
//		
//		String city = is.readLine();
//		ArrayList<Post> toSend = new ArrayList<Post>();
//		for(Post p : posts) {
//			if(p.getCity().equals(city)) {
//				toSend.add(p);
//			}
//		}
//
//		System.out.println("Sending to client: "+ toSend);
//		Gson gson = new Gson();
//		String json = gson.toJson(toSend);
//		
//		os.writeUTF(json);
//		
//		System.out.println("Sending to client: "+ json);
//
//		s.close();
//		System.out.println("Responce sent to client!");
//		
//	}
//	
//	static void registerConnection() throws IOException{
//		
//		String fromClient = is.readLine();
//		System.out.println("This user is from client: "+fromClient);
//		Gson gson = new Gson();
//		User userFromClient = gson.fromJson(fromClient, User.class);
//		System.out.println("Converted from json: "+userFromClient);
//		
//		boolean exists = false;
//		for(User u : users) {
//			if(userFromClient.getCpr().equals(u.getCpr())) {
//				exists = true;
//				System.out.println("This user already exists in database: "+u.getCpr());
//			}
//		}
//		
//		if(!exists) {
//			
//			users.add(userFromClient);
//			System.out.println("New user with cpr: "+userFromClient.getCpr()+" has been added to database");
//			// Convert the result user object to json string
//			String json = gson.toJson(userFromClient);
//
//
//			os.writeUTF(json);
//
//			s.close();
//			System.out.println("Responce sent to client!");
//			
//		}
//
//		
//	}
//	
//	public static void populate() {
//		for(int i = 0 ; i<10000 ; i++ ) {
//		    String s = ""+i;
//		    User u = new User(""+i,"pwd"+i,"name"+i,"email"+i,"NU","city"+i);
//		   if(users.size()<10000) {
//			   users.add(u);
//		   }
//		   
//		    Citizen c = new Citizen(""+i);
//		   if(citizens.size()<10000) {
//			   citizens.add(c);
//		   }
//		//   UserDetails u1 = new UserDetails("cpr"+i,"pwd"+i,"name"+i,"email"+i,"NU","city"+i);
//		   
//		}
//		
//		for(User u : users) {
//			Post p = new Post(1, "firts",u,"This is a post", "Type",new Date(),u.getCity());
//			Post p1 = new Post(1, "second",u,"This is another post", "Type",new Date(),u.getCity());
//			Post p2 = new Post(1, "third",u,"This is also a post!", "Type",new Date(),u.getCity());
//				   posts.add(p);
//				   posts.add(p1);
//				   posts.add(p2);
//				   
//		}
//	}
//
//}
