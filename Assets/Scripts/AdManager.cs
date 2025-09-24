using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    public static AdManager Instance;
    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
    private string adUnitIdIntersticial = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
  private string adUnitIdIntersticial = "ca-app-pub-3940256099942544/4411468910";
#else
  private string adUnitIdIntersticial = "unused";
#endif

    InterstitialAd _interstitialAd;
    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
    private string adUnitIdBanner = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
  private string adUnitIdBanner = "ca-app-pub-3940256099942544/2934735716";
#else
  private string adUnitIdBanner = "unused";
#endif

    BannerView _bannerView;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // This callback is called once the MobileAds SDK is initialized.
            CreateBannerView();
            LoadInterstitialAd();
        });
    }
    public void CreateBannerView()
    {
        Debug.Log("Creating banner view");

        // If we already have a banner, destroy the old one.
        if (_bannerView != null)
        {
            _bannerView.Destroy();
        }

        AdSize adSize = new AdSize(468, 60);
        _bannerView = new BannerView(adUnitIdBanner, AdSize.Banner, AdPosition.Bottom);
        
        var adRequest = new AdRequest();
        
        _bannerView.LoadAd(adRequest);
        if (_bannerView != null)
        {
            Debug.Log("hay banner");
        }
    }
    private void ListenToAdEvents()
    {
        // Raised when an ad is loaded into the banner view.
        _bannerView.OnBannerAdLoaded += () =>
        {
            Debug.Log("Banner view loaded an ad with response : "
                + _bannerView.GetResponseInfo());
        };
        // Raised when an ad fails to load into the banner view.
        _bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.LogError("Banner view failed to load an ad with error : "
                + error);
            CreateBannerView();
        };
        // Raised when the ad is estimated to have earned money.
        _bannerView.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Banner view paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        _bannerView.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Banner view recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        _bannerView.OnAdClicked += () =>
        {
            Debug.Log("Banner view was clicked.");
        };
        // Raised when an ad opened full screen content.
        _bannerView.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Banner view full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        _bannerView.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Banner view full screen content closed.");
        };
    }
    public void LoadInterstitialAd()
    {
        var adRequest = new AdRequest();

        // Send the request to load the ad.
        InterstitialAd.Load(adUnitIdIntersticial, adRequest, (InterstitialAd ad, LoadAdError error) =>
        {
            if (error != null)
            {
                // The ad failed to load.
                return;
            }
            // The ad loaded successfully.
            Debug.Log("Carga de anuncio Intersticial");
            _interstitialAd = ad;
        });
    }
    public void ShowInterstitialAd()
    {
        // [START show_ad]
        if (_interstitialAd != null && _interstitialAd.CanShowAd())
        {
            Debug.Log("Muestra de anuncio Intersticial");
            _interstitialAd.Show();
        }
        // [END show_ad]]
    }
    public void ListenToAdEventsInterstitial()
    {
        // [START ad_events]
        _interstitialAd.OnAdPaid += (AdValue adValue) =>
        {
            // Raised when the ad is estimated to have earned money.
        };
        _interstitialAd.OnAdImpressionRecorded += () =>
        {
            // Raised when an impression is recorded for an ad.
        };
        _interstitialAd.OnAdClicked += () =>
        {
            // Raised when a click is recorded for an ad.
        };
        _interstitialAd.OnAdFullScreenContentOpened += () =>
        {
            // Raised when the ad opened full screen content.
        };
        _interstitialAd.OnAdFullScreenContentClosed += () =>
        {
            // Raised when the ad closed full screen content.
        };
        _interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
        {
            // Raised when the ad failed to open full screen content.
            _interstitialAd.Destroy();
            LoadInterstitialAd();
        };
        // [END ad_events]]
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
