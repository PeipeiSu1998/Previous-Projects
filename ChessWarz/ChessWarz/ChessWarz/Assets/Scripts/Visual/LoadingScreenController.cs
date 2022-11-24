using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenController : MonoBehaviour
{
    public Text text;

    public Camera camera { private get; set; }

    public LayerMask original;
    public LayerMask loading;

    public void ShowLoading()
    {
        camera.cullingMask = loading;
    }

    public void HideLoading()
    {
        camera.cullingMask = original;
    }

    public void SetLobbyText()
    {
        text.text = "Welcome to Lobby";
    }

    public void SetLoadingText()
    {
        text.text = "Wait a sec...";
    }
    
    public void SetBattleText()
    {
        text.text = "To win the battle shoot your opponent 5 times.";
    }
}
