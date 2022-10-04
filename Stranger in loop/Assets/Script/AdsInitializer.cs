using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string androidGameId = "4956361";
    [SerializeField] private string IOSGameId = "4956360";
    [SerializeField] private bool testmode = true;
    private string gameId;

    public void OnInitializationComplete()
    {
        Debug.Log("Initialization success!");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Initialization fail!");
    }

    private void Awake()
    {
        InitializeAds();
    }

    private void InitializeAds()
    {
        gameId = (Application.platform == RuntimePlatform.IPhonePlayer) ? IOSGameId : androidGameId;
        Advertisement.Initialize(gameId, testmode, this);
    }


}
