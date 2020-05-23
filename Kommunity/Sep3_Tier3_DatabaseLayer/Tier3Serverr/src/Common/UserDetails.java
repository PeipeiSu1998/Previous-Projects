package Common;




public class UserDetails 
{
	private String cpr;
	private String password;
	private String name;
	private String email;
	private String role;
	private String city;
	
	public UserDetails(String cpr, String password,String name, String email,String role,String city)
	{
		this.cpr = cpr;
		this.password = password;//Security.HashFunction(password);
		this.name = name;
		this.email = email;
		this.role = role;
		this.city = city;
	}
	
	public UserDetails()
	{
		
	}
	
	
	
	public String getCpr() {
		return cpr;
	}



	public void setCpr(String cpr) {
		this.cpr = cpr;
	}



	public String GetPassword()
	{
		return password;
	}
	
	public void SetPassword(String password)
	{
		this.password = password;
	}
	
	public String GetName()
	{
		return name;
	}
	
	public void SetName(String name)
	{
		this.name = name;
	}
	
	public String GetEmail()
	{
		return email;
	}
	
	public void SetEmail(String email)
	{
		this.email = email;
	}
	
	public String GetRole()
	{
		return role;
	}
	
	public void SetRole(String role)
	{
		this.role = role;
	}


	public String getCity()
	{
		return city;
	}
	
	public void SetCity(String city)
	{
		this.city = city;
	}
	
	
	
	

}
