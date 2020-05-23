package Common;

import java.io.Serializable;
import java.util.ArrayList;

import Common.User;

public class UserList implements Serializable
{

	
/**
	 * 
	 */
	private static final long serialVersionUID = -4450069586079135932L;
private ArrayList<User> users;
	
	public UserList() {
		users = new ArrayList<>();
	}
		
		public int getNumberOfUsers(){
			
			return users.size();
		}
		
		public void addUser(User d){
			
			users.add(d);
		}
		
		public User getUser(int index){
			
			return users.get(index);
		}
		
		public void removeUser(int index){
			
			users.remove(index);
		}
		
		public boolean isEmpty(){
			
			if(users.size() == 0){
				
				return true;
			}
			else{
				
				return false;
			}
		}
		
		public User getUserByName(String name){
			
			for(int i = 0;i<users.size();i++){
				
				if(users.get(i).GetName().equals(name)){
					
					return users.get(i);
				}
			}
			
			return null;
		}
		
		
		
		public User getUserByCpr(String cpr){
			
			for(int i = 0;i<users.size();i++){
				
				if(users.get(i).getCpr().equals(cpr)){
					
					return users.get(i);
				}
			}
			
			return null;
		}
		
		

}
