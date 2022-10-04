using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAd : MonoBehaviour
{
    [SerializeField] BannerPosition bannerPos;
    [SerializeField] private string androidId = "Banner_Android";
    [SerializeField] private string IOSId = "Banner_IOS";
    private string adId;

    private void Awake()
    {
        adId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? IOSId
            : androidId;
    }

    private void Start()
    {
        Advertisement.Banner.SetPosition(bannerPos);
        StartCoroutine(LoadAdBanner());
    }

    private IEnumerator LoadAdBanner()
    {
        yield return new WaitForSeconds(1f);
        LoadBanner();
    }

    public void LoadBanner()
    {
        BannerLoadOptions loadOptions = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };
        Advertisement.Banner.Load(adId, loadOptions);
    }

    private void OnBannerLoaded()
    {
        Debug.Log("Banner loaded!");
        ShowBannerAd();
    }

    private void OnBannerError(string message)
    {
        Debug.Log("Banner Error:" + message);
    }
    
    private void ShowBannerAd()
    {
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };
        Advertisement.Banner.Show(adId, options);
    }

    private void OnBannerClicked()
    {

    }

    private void OnBannerHidden()
    {

    }

    private void OnBannerShown()
    {

    }
}
