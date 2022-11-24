public class ChoosingLocation : UserState
{
    public ChoosingLocation(User user) : base(user)
    {
        
    }
    
    public override void OnStateEnter()
    {
        HighlightValidLocations();
    }

    private void HighlightValidLocations()
    {
        GameManager.Instance.chessGameManager.chosenPiece.GetComponent<MoveSelector>().HighlightLocations();
    }

    public override void Next()
    {
        user.SetState(new Waiting(user));
    }
    
    public override void Previous()
    {
        user.SetState(new ChoosingPiece(user));
    }
}
