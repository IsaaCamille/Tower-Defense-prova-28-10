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
    private void LoadBanner()
    {
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        StartCoroutine(BannerCycleCoroutine());
        Debug.Log("Banner initialized sussefully");

    }

    private IEnumerator BannerCycleCoroutine()
    {
        while (true) // ciclo infinito
        {
            Advertisement.Banner.Show(bannerPlacementId); // exibe o banner
            Debug.Log("Banner exibido.");
            yield return new WaitForSeconds(10f); // mantém o banner visível por 10 segundos

            Advertisement.Banner.Hide(); // oculta o banner
            Debug.Log("Banner ocultado.");
            yield return new WaitForSeconds(5f); // mantém o banner oculto por 5 segundos
        }
    }

    private void Awake()
    {
        Advertisement.Initialize("5730087", true, this);
    }
    private void LoadBanner()
    {
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        StartCoroutine(BannerCycleCoroutine());
        Debug.Log("Banner initialized sussefully");

    }

    private IEnumerator BannerCycleCoroutine()
    {
        while (true) // Ciclo infinito
        {
            Advertisement.Banner.Show(bannerPlacementId); // Exibe o banner
            Debug.Log("Banner exibido.");
            yield return new WaitForSeconds(10f); // Mantém o banner visível por 10 segundos

            Advertisement.Banner.Hide(); // Oculta o banner
            Debug.Log("Banner ocultado.");
            yield return new WaitForSeconds(5f); // Mantém o banner oculto por 5 segundos
        }
    }

    // Callbacks da inicialização
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialized successfully.");
        LoadBanner();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.LogError($"Unity Ads initialization failed: {error} - {message}");
    }

    // Callbacks da exibição de anúncios
    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
      
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
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }
}





