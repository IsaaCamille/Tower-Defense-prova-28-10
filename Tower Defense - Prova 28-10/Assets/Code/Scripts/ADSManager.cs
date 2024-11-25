using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ADSManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    private string bannerPlacementId = "Banner_Android";
    private string interstitialPlacementId = "Interstitial_Android";
    private string nonSkkipableInterstitial = "Interstitial_Nao_Pulavel";
    private string rewardedPlacementId = "Rewarded_Android";

    private bool showSkippable = true;

    public delegate void ShowAds();

    public ShowAds showAds;

    private void Awake()
    {
        Advertisement.Initialize("5730091", true, this);

    }

    public void LoadBanner()
    {
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show(bannerPlacementId);
        Debug.Log("Banner initialized sussefully");
        StartCoroutine(BannerCycleCoroutine());
    }

    private IEnumerator BannerCycleCoroutine()
    {
        while (true) // Ciclo infinito
        {
            Advertisement.Banner.Show(bannerPlacementId); // exibe o banner
            Debug.Log("Banner exibido.");
            yield return new WaitForSeconds(10f); // mantém o banner visível por 10 segundos

            Advertisement.Banner.Hide(); // oculta o banner
            Debug.Log("Banner ocultado.");
            yield return new WaitForSeconds(5f); // mantém o banner oculto por 5 segundos
        }
    }

    public void ShowInterstitial()
    {
        PauseGame();
        Advertisement.Show(interstitialPlacementId, this);
        Debug.Log("Interstistial initialized sussefully");

    }

    public void ShowNonSkippable()
    {
        PauseGame();
        Advertisement.Show(nonSkkipableInterstitial, this);
        Debug.Log("Non Skkipable initialized sussefully");
    }

    public void ShowRewarded()
    {
        PauseGame();
        Advertisement.Show(rewardedPlacementId, this);
        Debug.Log("Rewarded initialized sussefully");
    }





}





