using System.Collections;
using Photon.Pun;
using UnityEngine;

public class HandChildrenManager : MonoBehaviourPunCallbacks
{
    public bool rightHand;

    private bool bowSet;
    private bool handModelSet;
    private bool handRendererSet;

    private int bowCounter;
    private int modelCounter;
    private int rendererCounter;

    private void Start()
    {
        FetchChildren();
    }

    public void FetchChildren()
    {
        if (!photonView.IsMine)
        {
            if (rightHand)
            {
                FetchBow();
                FetchHandRenderer("right");
            }
            else
            {
                FetchHandRenderer("left");
            }
        }
    }

    private void FetchBow()
    {
        bowCounter++;
        GameObject[] bows = GameObject.FindGameObjectsWithTag("Bow");

        foreach (GameObject bow in bows)
        {
            if (SetParentAsHand(bow))
            {
                bowSet = true;
                break;
            }
        }

        if (!bowSet && bowCounter <= 100)
        {
            FetchBow();
        }
    }

    private void FetchHandRenderer(string hand)
    {
        rendererCounter++;
        string tag = hand + "HandRenderer";
        GameObject[] handRenderers = 
        GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject renderer in handRenderers)
        {
            if (SetParentAsHand(renderer))
            {
                handRendererSet = true;
                FetchHandModel(hand, renderer);
                break;
            }
        }

        if (!handRendererSet && rendererCounter <= 100)
        {
            FetchHandRenderer(hand);
        }
    }

    private void FetchHandModel(string hand, GameObject renderer)
    {
        modelCounter++;
        string tag = hand + "HandModel";
        GameObject[] handModels = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject model in handModels)
        {
            if (SetAndDisableParent(model, renderer))
            {
                handModelSet = true;
                break;
            }
        }

        if (!handModelSet && modelCounter <= 100)
        {
            FetchHandModel(hand, renderer);
        }
    }

    private bool SetParentAsHand(GameObject go)
    {
        if (!go.GetPhotonView().IsMine)
        {
            go.transform.parent = transform;
            return true;
        }

        return false;
    }

    private bool SetAndDisableParent(GameObject go, GameObject parent)
    {
        if (!go.GetPhotonView().IsMine)
        {
            go.transform.parent = parent.transform;
            parent.SetActive(false);
            return true;
        }

        return false;
    }
}