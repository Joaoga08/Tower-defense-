using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour, IUnityAdsInitializationListener
{
    private string interstitialPlacement = "Interstitial_Android";
    private string gameId = "5729650";
    private bool testMode = true;
    private bool isAdShowing = false;
    private bool isAdLoaded = false;
 

    void Start()
    {
        Advertisement.Initialize(gameId, testMode, this);
    }


    public void OnInitializationComplete()
    {
        Advertisement.Load(interstitialPlacement);
    }

    public void ShowInterstitialAd()
    {
        if (!isAdShowing && isAdLoaded)
        {
            isAdShowing = true;
            
             Advertisement.Show(interstitialPlacement);
        }
     
    }



    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId == interstitialPlacement)
        {
            HandleAdResult(showCompletionState == UnityAdsShowCompletionState.COMPLETED ? ShowResult.Finished : ShowResult.Skipped);
        }
        isAdShowing = false;
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.LogError($"Erro ao exibir o anúncio: {placementId} - {error} - {message}");
        isAdShowing = false;
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log($"Anúncio iniciado: {placementId}");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log($"Anúncio clicado: {placementId}");
    }

    // Método para lidar com os resultados do intersticial
    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("O jogador assistiu ao anúncio.");
                break;
            case ShowResult.Skipped:
                Debug.Log("O jogador pulou o anúncio.");
                break;
            case ShowResult.Failed:
                Debug.LogError("Falha ao mostrar o anúncio.");
                break;
        }
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
         throw new System.NotImplementedException();
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        if (placementId == interstitialPlacement)
        {
            // Anúncio carregado com sucesso
            isAdLoaded = true;
            Debug.Log("Anúncio carregado e pronto para ser exibido.");
        }
    }

    // Método chamado se o carregamento do anúncio falhar
    public void OnUnityAdsAdFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        if (placementId == interstitialPlacement)
        {
            // Falha ao carregar o anúncio
            isAdLoaded = false;
            Debug.LogError($"Falha ao carregar o anúncio: {placementId} - {error} - {message}");
        }
    }
}

