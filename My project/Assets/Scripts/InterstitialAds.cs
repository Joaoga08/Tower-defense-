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
        Debug.LogError($"Erro ao exibir o an�ncio: {placementId} - {error} - {message}");
        isAdShowing = false;
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log($"An�ncio iniciado: {placementId}");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log($"An�ncio clicado: {placementId}");
    }

    // M�todo para lidar com os resultados do intersticial
    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("O jogador assistiu ao an�ncio.");
                break;
            case ShowResult.Skipped:
                Debug.Log("O jogador pulou o an�ncio.");
                break;
            case ShowResult.Failed:
                Debug.LogError("Falha ao mostrar o an�ncio.");
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
            // An�ncio carregado com sucesso
            isAdLoaded = true;
            Debug.Log("An�ncio carregado e pronto para ser exibido.");
        }
    }

    // M�todo chamado se o carregamento do an�ncio falhar
    public void OnUnityAdsAdFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        if (placementId == interstitialPlacement)
        {
            // Falha ao carregar o an�ncio
            isAdLoaded = false;
            Debug.LogError($"Falha ao carregar o an�ncio: {placementId} - {error} - {message}");
        }
    }
}

