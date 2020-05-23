package Common;

import java.util.Date;



public class Message
{



	private int mid;
	private User senderid;
	private User receiverid;
	public User getReceiverid() {
		return receiverid;
	}

	public void setReceiverid(User receiverid) {
		this.receiverid = receiverid;
	}

	private Date date;
	private String text;
	
	public Message(int mid, User senderid, Date date, String text) 
	{
		this.mid = mid;
		this.senderid = senderid;
		this.date = date;
		this.text = text;
	}
	
	public Message()
	{
		
	}

	public int getMid() {
		return mid;
	}

	public void setMid(int mid) {
		this.mid = mid;
	}



	public User getSenderid() {
		return senderid;
	}

	public void setSenderid(User senderid) {
		this.senderid = senderid;
	}

	public Date getDate() {
		return date;
	}

	public void setDate(Date date) {
		this.date = date;
	}

	public String getText() {
		return text;
	}

	public void setText(String text) {
		this.text = text;
	}
	
	
	
	
	
	

}
