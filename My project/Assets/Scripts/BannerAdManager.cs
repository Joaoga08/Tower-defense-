using System.Collections;

using UnityEngine;

using UnityEngine.Advertisements;

public class BannerAdManager : MonoBehaviour, IUnityAdsInitializationListener

{

    private string bannerPlacement = "Banner_Android";

    private string gameId = "5729650";

    private bool testMode = true;

    void Start()

    {

        Advertisement.Initialize(gameId, testMode, this);
        OnInitializationComplete();

    }

    public void OnInitializationComplete()

    {

        StartCoroutine(BannerAdCycle());

    }

    IEnumerator BannerAdCycle()

    {

        while (true)

        {

            // Verifica se algum anúncio está sendo exibido antes de mostrar o banner

            if (!Advertisement.isShowing)

            {

                // Carrega o banner explicitamente

                Advertisement.Banner.Load(bannerPlacement);
                Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);

                Advertisement.Banner.Show(bannerPlacement);

            }

            yield return new WaitForSeconds(10f);

            // Esconde o banner após o tempo determinado

            Advertisement.Banner.Hide();

            yield return new WaitForSeconds(5f);

        }

    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)

    {

        Debug.LogError($"Falha na inicialização do Unity Ads: {message}");

    }

}

 