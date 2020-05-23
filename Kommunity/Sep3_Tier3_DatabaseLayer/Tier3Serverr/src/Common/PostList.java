package Common;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.Date;

public class PostList implements Serializable
{

	/**
	 * 
	 */
	private static final long serialVersionUID = 4039469091431895913L;
	
private ArrayList<Post> posts;
	
	public PostList() {
		posts = new ArrayList<>();
	}
		
		public int getNumberOfPosts(){
			
			return posts.size();
		}
		
		public void addPetiton(Post p){
			
			posts.add(p);
		}
		
		public Post getPost(int index){
			
			return posts.get(index);
		}
		
		public void removePost(int index){
			
		   posts.remove(index);
		}
		
		public boolean isEmpty(){
			
			if(posts.size() == 0){
				
				return true;
			}
			else{
				
				return false;
			}
		}
		
		public Post getPetionByTitle(String title){
			
			for(int i = 0;i<posts.size();i++){
				
				if(posts.get(i).getTitle().equals(title)){
					
					return posts.get(i);
				}
			}
			
			return null;
		}
		
		public void removePostByTitle(String title)
		{
			for( int i = 0;i<posts.size();i++)
			{
				if(posts.get(i).getTitle().equals(title))
				{
					posts.remove(i);
				}
			}
		}
		
		
		public Post getPostByCreator(String cpr){
		
			for(int i = 0;i<posts.size();i++){
				
				if(posts.get(i).getCreator().getCpr().equals(cpr)){
					
					return posts.get(i);
				}
			}
			
			return null;
		}

		public Post getPostByDate(Date date)
		{
			for(int i = 0; i<posts.size();i++)
			{
				if(posts.get(i).getDate().equals(date))
				{
					return posts.get(i);
				}
			}
			
			return null;
		}
		
		public Post getPostByCity(String city)
		{
			for(int i = 0;i<posts.size();i++)
			{
				if(posts.get(i).getCity().equals(city))
				{
					return posts.get(i);
				}
			}
			return null;
		}
		

}
