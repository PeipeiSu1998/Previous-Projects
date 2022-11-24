using UnityEngine;

public class ScoreEventHandler : MonoBehaviour
{
    private ScoreManager scoreManager;

    public void Hit()
    {
        if (scoreManager == null)
        {
            scoreManager = FindObjectOfType<ScoreManager>();
        }
            
        scoreManager.IncrementMyScore();
    }
}
