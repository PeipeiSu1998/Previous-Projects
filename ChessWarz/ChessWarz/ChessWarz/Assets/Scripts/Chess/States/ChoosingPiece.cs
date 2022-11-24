using UnityEngine;
public class ChoosingPiece : UserState
{
    public ChoosingPiece(User user) : base(user)
    {
        
    }

    public override void OnStateEnter()
    {
        EnableControllers();
    }

    private void EnableControllers()
    {
        user.EnableControllers();
    }

    public override void Next()
    {
        user.SetState(new ChoosingLocation(user));
    }
}
