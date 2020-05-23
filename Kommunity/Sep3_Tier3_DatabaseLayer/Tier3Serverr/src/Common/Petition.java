package Common;

import java.sql.Date;



public class Petition 
{


	private int peid;
	private String title;
	private User creator;
	private String date;
	private String content;
	private boolean approved;
	
	public Petition(int peid,String title, User creator, String date, String content, boolean approved) 
	{
		this.peid = peid;
		this.creator = creator;
		this.date = date;
		this.content = content;
		this.approved = approved;
		this.title = title;
	}
	

	public String getTitle() {
		return title;
	}

	public void setTitle(String title) {
		this.title = title;
	}

	public Petition()
	{
		
	}

	public int getPeid() {
		return peid;
	}

	public void setPeid(int peid) {
		this.peid = peid;
	}

	public String getDate() {
		return date;
	}
	
	
	public void setDate(String date) {
		this.date = date;
	}

	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public boolean isApproved() {
		return approved;
	}

	public void setApproved(boolean approved) {
		this.approved = approved;
	}

	public User getCreator() {
		return creator;
	}

	public void setCreator(User creator) {
		this.creator = creator;
	}
	
	
	
}
