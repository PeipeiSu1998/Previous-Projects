using UnityEngine;
using UnityEngine.UI;
using Valve.VR.Extras;

[RequireComponent(typeof(SteamVR_LaserPointer))]
public class MainMenuLaser : MonoBehaviour
{
    private SteamVR_LaserPointer laserPointer;

    //public NetworkManager networkManager;
    private void OnEnable()
    {
        laserPointer = GetComponent<SteamVR_LaserPointer>();
        laserPointer.PointerClick += PointerClick;
    }

    private void OnDisable()
    {
        laserPointer = GetComponent<SteamVR_LaserPointer>();
        laserPointer.PointerClick -= PointerClick;
    }
    
    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.CompareTag("EnterButton"))
        {
            e.target.GetComponent<Button>().onClick.Invoke();
        }
    }
}
