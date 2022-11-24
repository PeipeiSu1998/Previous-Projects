using UnityEngine;

public class User : MonoBehaviour
{
    private GameObject[] controllers = new GameObject[2];

    private UserState currentState;
    
    void GetControllers()
    {
        controllers[0] = transform.GetChild(0).gameObject;
        controllers[1] = transform.GetChild(1).gameObject;
    }
    
    public void SetState(UserState state)
    {
        currentState = state;
        currentState?.OnStateEnter();
    }
    
    public void SetInitialStateToWaiting(UserState state)
    {
        currentState = state;
        currentState?.OnInitialStateEnter();
    }

    public void NextState()
    {
        currentState.Next();
    }

    public void PreviousState()
    {
        currentState.Previous();
    }

    public void EnableControllers()
    {
        if (controllers[0] == null)
        {
            GetControllers();
        }

        foreach (GameObject controller in controllers)
        {
            controller.SetActive(true);
        }
    }
    
    public void DisableControllers()
    {
        if (controllers[0] == null)
        {
            GetControllers();
        }
        
        foreach (GameObject controller in controllers)
        {
            controller.SetActive(false);
        }
    }
}
