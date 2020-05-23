package mediator;

import java.sql.Connection;
import java.sql.Date;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

import Common.Petition;
import Common.Post;
import Common.User;

public class SystemDbs implements SystemPersistence
{
	private static String url;
	private static String username;
	private static String password;
	private CitizenPersistence citizendbs;
	
	public SystemDbs(String url,String username,String password)
	{
		this.url = url;
		this.username = username;
		this.password = password;
	}
	
	@Override
	public void initializeCitizenDbs(String url)
	{
		citizendbs = new CitizenDbs(url,username,password);
	}
	
	
	
	@Override
	public User createAccount(User user)
	{
		User accountUser = user;
		System.out.println(accountUser.getCpr());
		System.out.println(accountUser.getCpr());
		if(citizendbs.CheckId(accountUser)==true)
		{
			String sql = "Insert into UserDetails(cpr,password,name,email,role,city) values(?,?,?,?,?,?)";
			String sql1 = "Select * from UserDetails where cpr =?";
			try (Connection con = DriverManager.getConnection(url, username, password);
		             PreparedStatement pst = con.prepareStatement(sql)) {
		            
		            pst.setString(1,accountUser.getCpr());
		            pst.setString(2,accountUser.GetPassword());
		            pst.setString(3,accountUser.GetName());
		            pst.setString(4,accountUser.GetEmail());
		            pst.setString(5,accountUser.GetRole());
		            pst.setString(6,accountUser.getCity());
		            pst.executeUpdate();
		            System.out.println("User added into database");
		}
			catch (SQLException ex) {

	            System.out.println(ex.getMessage());
	        }	
			
			try (Connection con = DriverManager.getConnection(url, username, password);
		             PreparedStatement pst = con.prepareStatement(sql1)) 
			{
				pst.setString(1, user.getCpr());
				ResultSet rs = pst.executeQuery();
				 if (rs.next()) {
		                
						User databaseuser = new User(rs.getString(1),rs.getString(2),rs.getString(3),rs.getString(4),rs.getString(5),rs.getString(6));
						return databaseuser;
						
		            }
				 else
				 {
					 return null;
				 }
				 
			
			}
			catch(SQLException ex)
			{
				System.out.println(ex.getMessage());
			}
			
			}
			System.out.println("Id is invalid");
		return null;
			
	}
	
@Override
	public User accesAccount(User user)
	{
	
	User loginUser = user; 
	
		String sql = "Select * from UserDetails where (cpr=? and password=?)";
		
		try (Connection con = DriverManager.getConnection(url, username, password);
	             PreparedStatement pst = con.prepareStatement(sql))
		{
			pst.setString(1, loginUser.getCpr());
			pst.setString(2, loginUser.GetPassword());
			ResultSet rs = pst.executeQuery();
			 if (rs.next()) {
	                
					User databaseuser = new User(rs.getString(1),rs.getString(2),rs.getString(3),rs.getString(4),rs.getString(5),rs.getString(6));
					System.out.println("User is logged in");
					return databaseuser;
					
	            }
			 else
			 {
				 return null;
			 }

		}
		catch(SQLException ex)
		{
			System.out.println(ex.getMessage());
		}
		
		return null;
		
	}
@Override
	public Post createPost(Post post)
	{
	String sql = "insert into Post(title,creator,content,type,pdate,city) values(?,?,?,?,?,?)";
	String sql1 = "select * from Post where creator=?";

    try (Connection conn = DriverManager.getConnection(url,username,password);
            PreparedStatement pstmt = conn.prepareStatement(sql)) {
    	pstmt.setString(1, post.getTitle());
    	pstmt.setString(2,post.getCreator().getCpr());
    	pstmt.setString(3, post.getContent());
    	pstmt.setString(4, post.getType());
    	pstmt.setString(5, post.getDate());
    	pstmt.setString(6,post.getCity());
    	
    	pstmt.executeUpdate();
        System.out.println("Post added into database");
    }
    catch(SQLException ex)
    {
	 System.out.println(ex.getMessage()); 
	 }
    
	try (Connection con = DriverManager.getConnection(url, username, password);
             PreparedStatement pst = con.prepareStatement(sql1))
	{
		pst.setString(1, post.getCreator().getCpr());
		ResultSet rs = pst.executeQuery();
		 if (rs.next()) {
                
			 User user = new User();
			 user.setCpr(rs.getString(3));
			    Post databasepost = new Post(rs.getInt(1),rs.getString(2),user,rs.getString(4),rs.getString(5),rs.getString(6),rs.getString(7));
				System.out.println("Post is in database");
				return databasepost;
				
            }
		 else
		 {
			 return null;
		 }

	}
	catch(SQLException ex)
	{
		System.out.println(ex.getMessage());
	}
	
	return null;
    
    }
@Override
public  ArrayList<Post> getPostByCity(String city)
{
	String sql = "Select * from post where city=?";
	
	   ArrayList<Post>  list = new ArrayList<>();
	
	try (Connection con = DriverManager.getConnection(url, username, password);
            PreparedStatement pst = con.prepareStatement(sql))
	{
		pst.setString(1, city);
		boolean isResult = pst.execute();

        do {
            try (ResultSet rs = pst.getResultSet()) {

                while (rs.next()) {
                
               
                  User user = new User();
 				 user.setCpr(rs.getString(3));
                  Post databasepost = new Post(rs.getInt(1),rs.getString(2),user,rs.getString(4),rs.getString(5),rs.getString(6),rs.getString(7));
                  list.add(databasepost);
                  System.out.println("Post added to list");
                }

                isResult = pst.getMoreResults();
            }
        } while (isResult);
        System.out.println(list.size());
        return list;
        


	}
	catch(SQLException ex)
	{
		System.out.println(ex.getMessage());
	}
	
	return null;

	}
@Override
public  Petition createPetition(Petition petition)
{
	String sql = "insert into Petition(title,creator,pedate,content,approved) values(?,?,?,?,?)";
	String sql1 = "select * from Petition where petition.peid = ?";

    try (Connection conn = DriverManager.getConnection(url,username,password);
            PreparedStatement pstmt = conn.prepareStatement(sql)) {
    	pstmt.setString(1, petition.getTitle());
    	pstmt.setString(2,petition.getCreator().getCpr());
    	pstmt.setString(3, petition.getDate());
    	pstmt.setString(4, petition.getContent());
    	pstmt.setBoolean(5,  petition.isApproved());

    	
    	pstmt.executeUpdate();
        System.out.println("Petition added into database");
    }
    catch(SQLException ex)
    {
	 System.out.println(ex.getMessage()); 
	 }
    
	try (Connection con = DriverManager.getConnection(url, username, password);
             PreparedStatement pst = con.prepareStatement(sql1))
	{
		pst.setInt(1, petition.getPeid());
		ResultSet rs = pst.executeQuery();
		 if (rs.next()) {
                
			 User user = new User();
			 user.setCpr(rs.getString(3));
			    Petition databasepetition = new Petition(rs.getInt(1),rs.getString(2),user,rs.getString(4),rs.getString(5),rs.getBoolean(6));
				System.out.println("Petition is in database");
				return databasepetition;
				
            }
		 else
		 {
			 return null;
		 }

	}
	catch(SQLException ex)
	{
		System.out.println(ex.getMessage());
	}
	
	return null;
    
}

@Override
public Petition approvePetition(Petition petition) 
{
	String sql = "update Petition set approved=? where petition.peid=?";
	String sql1 ="Select * from Petition where petition.peid=?";
	
	try (Connection con = DriverManager.getConnection(url, username, password);
            PreparedStatement pst = con.prepareStatement(sql))
	{
		pst.setBoolean(1, petition.isApproved());
		pst.setInt(2,petition.getPeid());
		ResultSet rs = pst.executeQuery();
		 if (rs.next()) 
		 {
			 pst.executeUpdate();
			 System.out.println("Petition is aproved");
		 }
		
	}
	catch(SQLException ex)
	{
		System.out.println(ex.getMessage());
	}
	try (Connection con = DriverManager.getConnection(url, username, password);
            PreparedStatement pst = con.prepareStatement(sql1))
	{
		pst.setInt(1, petition.getPeid());
		ResultSet rs = pst.executeQuery();
		 if (rs.next()) {
               
			 User user = new User();
			 user.setCpr(rs.getString(3));
			    Petition databasepetition = new Petition(rs.getInt(1),rs.getString(2),user,rs.getString(4),rs.getString(5),rs.getBoolean(6));
				System.out.println("Petition is in database");
				return databasepetition;
				
           }
		 else
		 {
			 return null;
		 }

	}
	catch(SQLException ex)
	{
		System.out.println(ex.getMessage());
	}
	
	return null;
}

@Override
public ArrayList<Petition> getApprovedPetition() 
{
	String sql = "Select * from Petition where approved=?";
	
	   ArrayList<Petition>  list = new ArrayList<>();
	
	try (Connection con = DriverManager.getConnection(url, username, password);
         PreparedStatement pst = con.prepareStatement(sql))
	{
		pst.setBoolean(1, true);
		boolean isResult = pst.execute();

     do {
         try (ResultSet rs = pst.getResultSet()) {

             while (rs.next()) {
             
            
               User user = new User();
				 user.setCpr(rs.getString(3));
				  Petition databasepetition = new Petition(rs.getInt(1),rs.getString(2),user,rs.getString(4),rs.getString(5),rs.getBoolean(6));
               list.add(databasepetition);
               System.out.println("Post added to list");
             }

             isResult = pst.getMoreResults();
         }
     } while (isResult);
     System.out.println(list.size());
     return list;
     


	}
	catch(SQLException ex)
	{
		System.out.println(ex.getMessage());
	}
	
	return null;

}

@Override
public ArrayList<Petition> getUnApprovedPetition() 
{
	String sql = "Select * from Petition where approved=?";
	
	   ArrayList<Petition>  list = new ArrayList<>();
	
	try (Connection con = DriverManager.getConnection(url, username, password);
      PreparedStatement pst = con.prepareStatement(sql))
	{
		pst.setBoolean(1, false);
		boolean isResult = pst.execute();

  do {
      try (ResultSet rs = pst.getResultSet()) {

          while (rs.next()) {
          
         
            User user = new User();
				 user.setCpr(rs.getString(3));
				  Petition databasepetition = new Petition(rs.getInt(1),rs.getString(2),user,rs.getString(4),rs.getString(5),rs.getBoolean(6));
            list.add(databasepetition);
            System.out.println("Post added to list");
          }

          isResult = pst.getMoreResults();
      }
  } while (isResult);
  System.out.println(list.size());
  return list;
  


	}
	catch(SQLException ex)
	{
		System.out.println(ex.getMessage());
	}
	
	return null;
	
}

@Override
public User changeCity(User user, String city) 
{
	
	String sql = "update UserDetails set city=? where cpr=?";
	String sql1 = "Select *  from UserDetails where cpr=?" ;
	
	try (Connection con = DriverManager.getConnection(url, username, password);
            PreparedStatement pst = con.prepareStatement(sql))
	{
		pst.setString(1, city);
		pst.setString(2, user.getCpr());
		ResultSet rs = pst.executeQuery();
		 if (rs.next()) 
		 {
			 pst.executeUpdate();
			 System.out.println("City has been updated");
		 }
		
	}
	catch(SQLException ex)
	{
		System.out.println(ex.getMessage());
	}
	
	try (Connection con = DriverManager.getConnection(url, username, password);
            PreparedStatement pst = con.prepareStatement(sql1)) 
	{
		pst.setString(1, user.getCpr());
		ResultSet rs = pst.executeQuery();
		 if (rs.next()) {
               
				User databaseuser = new User(rs.getString(1),rs.getString(2),rs.getString(3),rs.getString(4),rs.getString(5),rs.getString(6));
				return databaseuser;
				
				
           }
		 else
		 {
			 return null;
		 }
		 
	
	}
	catch(SQLException ex)
	{
		System.out.println(ex.getMessage());
	}
	
	
	
	return null;
}

@Override
public User changePassword(User user, String password)
{
	
	String sql = "update UserDetails set password=? where cpr=?";
	String sql1 = "Select *  from UserDetails where cpr=?" ;
	
	try (Connection con = DriverManager.getConnection(url, username, this.password);
            PreparedStatement pst = con.prepareStatement(sql))
	{
		pst.setString(1, password);
		pst.setString(2, user.getCpr());
		ResultSet rs = pst.executeQuery();
		 if (rs.next()) 
		 {
			 System.out.println("Password has been updated");
			 pst.executeUpdate();
			 
		 }
		
	}
	catch(SQLException ex)
	{
		System.out.println(ex.getMessage());
	}
	
	try (Connection con = DriverManager.getConnection(url, username, password);
            PreparedStatement pst = con.prepareStatement(sql1)) 
	{
		pst.setString(1, user.getCpr());
		ResultSet rs = pst.executeQuery();
		 if (rs.next()) {
               
				User databaseuser = new User(rs.getString(1),rs.getString(2),rs.getString(3),rs.getString(4),rs.getString(5),rs.getString(6));
				return databaseuser;
				
				
           }
		 else
		 {
			 return null;
		 }
		 
	
	}
	catch(SQLException ex)
	{
		System.out.println(ex.getMessage());
	}
	
	
	
	
	return null;
}

@Override
public User changeRole(User user, String role) 
{
	String sql = "update UserDetails set role=? where cpr=?";
	String sql1 = "Select *  from UserDetails where cpr=?" ;
	
	try (Connection con = DriverManager.getConnection(url, username, password);
            PreparedStatement pst = con.prepareStatement(sql))
	{
		pst.setString(1, role);
		pst.setString(2, user.getCpr());
		ResultSet rs = pst.executeQuery();
		 if (rs.next()) 
		 {
			 System.out.println("Role has been updated");
			 pst.executeUpdate();
			 
		 }
		
	}
	catch(SQLException ex)
	{
		System.out.println(ex.getMessage());
	}
	
	try (Connection con = DriverManager.getConnection(url, username, password);
            PreparedStatement pst = con.prepareStatement(sql1)) 
	{
		pst.setString(1, user.getCpr());
		ResultSet rs = pst.executeQuery();
		 if (rs.next()) {
               
				User databaseuser = new User(rs.getString(1),rs.getString(2),rs.getString(3),rs.getString(4),rs.getString(5),rs.getString(6));
				return databaseuser;
				
				
           }
		 else
		 {
			 return null;
		 }
		 
	
	}
	catch(SQLException ex)
	{
		System.out.println(ex.getMessage());
	}
	
	
	
	
	return null;
}

@Override
public User changeEmail(User user, String email) 
{
	String sql = "update UserDetails set email=? where cpr=?";
	String sql1 = "Select *  from UserDetails where cpr=?" ;
	
	try (Connection con = DriverManager.getConnection(url, username, password);
            PreparedStatement pst = con.prepareStatement(sql))
	{
		pst.setString(1, email);
		pst.setString(2, user.getCpr());
		ResultSet rs = pst.executeQuery();
		 if (rs.next()) 
		 {
			 System.out.println("Email has been updated");
			 pst.executeUpdate();
			 
		 }
		
	}
	catch(SQLException ex)
	{
		System.out.println(ex.getMessage());
	}
	
	try (Connection con = DriverManager.getConnection(url, username, password);
            PreparedStatement pst = con.prepareStatement(sql1)) 
	{
		pst.setString(1, user.getCpr());
		ResultSet rs = pst.executeQuery();
		 if (rs.next()) {
               
				User databaseuser = new User(rs.getString(1),rs.getString(2),rs.getString(3),rs.getString(4),rs.getString(5),rs.getString(6));
				return databaseuser;
				
				
           }
		 else
		 {
			 return null;
		 }
		 
	
	}
	catch(SQLException ex)
	{
		System.out.println(ex.getMessage());
	}
	
	
	
	
	return null;
}






}
