package Common;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.Date;

public class PetitionList implements Serializable
{

/**
	 * 
	 */
	private static final long serialVersionUID = -4334067700373808798L;
private ArrayList<Petition> petitions;
	
	public PetitionList() {
		petitions = new ArrayList<>();
	}
		
		public int getNumberOfPetitions(){
			
			return petitions.size();
		}
		
		public void addPetiton(Petition p){
			
			petitions.add(p);
		}
		
		public Petition getPetition(int index){
			
			return petitions.get(index);
		}
		
		public void removePetition(int index){
			
		   petitions.remove(index);
		}
		
		public boolean isEmpty(){
			
			if(petitions.size() == 0){
				
				return true;
			}
			else{
				
				return false;
			}
		}
		
		public Petition getPetionByTitle(String title){
			
			for(int i = 0;i<petitions.size();i++){
				
				if(petitions.get(i).getTitle().equals(title)){
					
					return petitions.get(i);
				}
			}
			
			return null;
		}
		
		public void removePetitionByTitle(String title)
		{
			for( int i = 0;i<petitions.size();i++)
			{
				if(petitions.get(i).getTitle().equals(title))
				{
					petitions.remove(i);
				}
			}
		}
		
		
		public Petition getPetitionByCreator(String cpr){
		
			for(int i = 0;i<petitions.size();i++){
				
				if(petitions.get(i).getCreator().getCpr().equals(cpr)){
					
					return petitions.get(i);
				}
			}
			
			return null;
		}

		public Petition getPetitionByDate(Date date)
		{
			for(int i = 0; i<petitions.size();i++)
			{
				if(petitions.get(i).getDate().equals(date))
				{
					return petitions.get(i);
				}
			}
			
			return null;
		}
		
		
}

