package Common;


public class Inbox {

	private int rid;

	private User rcpr;

	private Message mid;

	public int getRid() {
		return rid;
	}

	public void setRid(int rid) {
		this.rid = rid;
	}

	

	public User getRcpr() {
		return rcpr;
	}

	public void setRcpr(User rcpr) {
		this.rcpr = rcpr;
	}

	public Message getMid() {
		return mid;
	}

	public void setMid(Message mid) {
		this.mid = mid;
	}

	public Inbox(int rid, User rcpr, Message mid) {
		super();
		this.rid = rid;
		this.rcpr = rcpr;
		this.mid = mid;
	}
	
	public Inbox()
	{
		
	}

}
