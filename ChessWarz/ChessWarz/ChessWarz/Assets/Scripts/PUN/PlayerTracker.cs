using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    private static PlayerTracker playerTrackerInstance;
    public bool firstPlayerToJoin { get; set; }
    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (playerTrackerInstance == null)
        {
            playerTrackerInstance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
