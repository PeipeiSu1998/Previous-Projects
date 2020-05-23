package mediator;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

import Common.User;

public class CitizenDbs implements CitizenPersistence
{

	private String url;
	private String password;
	private String username;
	
	public CitizenDbs(String url,String username,String password)
	{
		this.url = url;
		this.username = username;
		this.password = password;
	}
	
	@Override
	public boolean CheckId(User user) {
		
		User citizenUser = user;
		System.out.println(citizenUser.getCpr());
		
		String sql = "Select * from Citizens where cpr=?";
		

        try (Connection conn = DriverManager.getConnection(url, username, password);
                PreparedStatement pstmt = conn.prepareStatement(sql)) {
 
            pstmt.setString(1, user.getCpr());
            ResultSet rs = pstmt.executeQuery();
            if (rs.next()) {
                System.out.println(rs.getString(1));
                System.out.println("Id is valid");
                return true;
            }
            else
            {
            	System.out.println("Id is invalid");
            	return false;
            }
 
		
		
	}
     catch(SQLException ex)
        {
    	 System.out.println(ex.getMessage()); 
    	 }
        return false;
        }
	
}
