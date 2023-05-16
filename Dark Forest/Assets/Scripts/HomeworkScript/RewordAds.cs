using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;

public class RewordAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public int prize = 100;

    [SerializeField] private Button buttonShowAdd;

    [SerializeField] private string androidAdID = "Rewarded_Android";
    [SerializeField] private string iosidAdID = "Rewarded_iOS";

    private string adID;

    private void Awake()
    {
        adID = (Application.platform == RuntimePlatform.IPhonePlayer) 
            ? iosidAdID 
            : androidAdID;

        buttonShowAdd.interactable = false;
    }

    private void Start()
    {
        LoadAd();
    }

    public void LoadAd()
    {
        Debug.Log("Loading ad" + adID);
        Advertisement.Load(adID, this);
    }

    public void ShowAd()
    {
        buttonShowAdd.interactable = false;

        Advertisement.Show(adID, this);
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);

        if (adUnitId.Equals(adID))
        {
            buttonShowAdd.onClick.AddListener(ShowAd);

            buttonShowAdd.interactable = true;
        }
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(adID) && showCompletionState.Equals(UnityAdsCompletionState.COMPLETED))
        {
            Debug.Log("+9999 dolars");
        }
    }

    private void OnDestroy()
    {
        buttonShowAdd.onClick.RemoveAllListeners();
    }
}
