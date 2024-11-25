using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ADSManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    private string bannerPlacementId = "Banner_Android";

    private void Awake()
    {
        Advertisement.Initialize("5730091", true, this);

    }

    public void LoadBanner()
    {
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show(bannerPlacementId);
        Debug.Log("Banner initialized sussefully");
    }




}





