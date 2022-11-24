public abstract class UserState
{
    protected User user;

    public UserState(User user)
    {
        this.user = user;
    }
    public virtual void OnInitialStateEnter(){}
    public virtual void OnStateEnter(){}
    public virtual void Previous(){}
    public abstract void Next();
}
