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

   

    private void Awake()
    {
        Advertisement.Initialize("5730091", true, this);

    }

    private void Start()
    {
        TelaGameOver.showAds += ShowRewarded;
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
        Advertisement.Banner.Hide(); // oculta o banner
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

    public void ShowAd()
    {
        if (showSkippable)
        {
            ShowInterstitial();
        }
        else
        {
            ShowNonSkippable();
        }

        // Alterna o tipo de anúncio para a próxima vez
        showSkippable = !showSkippable;
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        Debug.Log("Game Paused for Ad.");
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Game Resumed after Ad.");
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialized successfully.");
        TelaGameOver.showAds += ShowRewarded;
        LoadBanner();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        ResumeGame();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.LogError($"Unity Ads initialization failed: {error} - {message}");
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log($"Ad Loaded: {placementId}");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.LogError($"Failed to load ad {placementId}: {error} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {

    }

    public void OnUnityAdsShowStart(string placementId)
    {

    }

    public void OnUnityAdsShowClick(string placementId)
    { }



}





