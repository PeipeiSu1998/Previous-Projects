	package Common;




public class Vote
{

	private int vid;
	private User voter;
	private Petition peid;
	public Vote(int vid, User voter, Petition peid)
	{
		super();
		this.vid = vid;
		this.voter = voter;
		this.peid = peid;
	}
	
	public Vote()
	{
		
	}
	public int getVid() {
		return vid;
	}
	public void setVid(int vid) {
		this.vid = vid;
	}
	public User getVoter() {
		return voter;
	}
	public void setVoter(User voter) {
		this.voter = voter;
	}
	public Petition getPeid() {
		return peid;
	}
	public void setPeid(Petition peid) {
		this.peid = peid;
	}
	
	
	
	
	
	

}
