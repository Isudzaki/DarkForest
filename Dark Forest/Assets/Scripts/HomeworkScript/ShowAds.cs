using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;


public class ShowAds : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private bool testMod = true;
    [SerializeField] string androidGameID = "4981053";
    [SerializeField] string iosGameID = "4981052";

    private string gameId;

    void Awake()
    {
        InstalizateAds();
    }

    public void InstalizateAds()
    {
        gameId = (Application.platform == RuntimePlatform.IPhonePlayer) ? iosGameID : androidGameID;
        Advertisement.Initialize(gameId, testMod, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Complete");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Eror");
    }
}
