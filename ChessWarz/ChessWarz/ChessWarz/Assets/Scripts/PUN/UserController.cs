using System.Collections;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserController : MonoBehaviourPunCallbacks
{
    public GameObject leftHand;
    public GameObject rightHand;

    public Camera VRCamera;

    public AudioListener audioListener;

    void Start()
    {
        StartCoroutine(DisableCameraAndListener());
    }

    private IEnumerator DisableCameraAndListener()
    {
        if (GameManager.Instance.loadingScreenController.text != null)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 3)
            {
                GameManager.Instance.loadingScreenController.SetLoadingText();
            }
        }

        GameManager.Instance.loadingScreenController.ShowLoading();
        yield return new WaitForSeconds(3);

        if (!photonView.IsMine)
        {
            VRCamera.enabled = false;
            audioListener.enabled = false;

            if (SceneManager.GetActiveScene().buildIndex != 3)
            {
                leftHand.SetActive(false);
                rightHand.SetActive(false);
            }
        }


        if (GameManager.Instance.loadingScreenController.text != null)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                GameManager.Instance.loadingScreenController.SetLobbyText();
            }

            else
            {
                GameManager.Instance.loadingScreenController.SetBattleText();
            }
        }

        GameManager.Instance.loadingScreenController.HideLoading();
    }
}