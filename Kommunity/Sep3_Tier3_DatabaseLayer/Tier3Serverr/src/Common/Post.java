package Common;

import java.sql.Date;




public class Post 
{


	private int pid;
	private String title;
	private User creator;
	private String content;
	private String type;
	private String date;
	private String city;
	
	public Post(int pid,String title, User creator, String content, String type,String date, String city) 
	{
		this.pid = pid;
		this.creator = creator;
		this.content = content;
		this.type = type;
		this.date = date;
		this.city=city;
		this.title = title;
	}
	
	public String getTitle() {
		return title;
	}

	public void setTitle(String title) {
		this.title = title;
	}

	public Post()
	{
		
	}

	public String getCity() {
		return city;
	}

	public void setCity(String city) {
		this.city = city;
	}

	public int getPid() {
		return pid;
	}

	public void setPid(int pid) {
		this.pid = pid;
	}


	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}

	public String getDate() {
		return date;
	}

	public void setDate(String date) {
		this.date = date;
	}

	public User getCreator() {
		return creator;
	}

	public void setCreator(User creator) {
		this.creator = creator;
	}
	
	
	

}
