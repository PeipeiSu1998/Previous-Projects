package Common;




public class City 
{
	private int postNo;
	private String name;
	
	public City(int postNo,String name)
	{
		this.postNo = postNo;
		this.name = name;
	}
	
	public City()
	{
		
	}

	public int getPostNo() {
		return postNo;
	}

	public void setPostNo(int postNo) {
		this.postNo = postNo;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}
	
	
}
