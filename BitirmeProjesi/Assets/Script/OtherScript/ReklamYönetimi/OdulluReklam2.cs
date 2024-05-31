using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Core.Easing;
using UnityEngine;
using UnityEngine.Advertisements;

public class OdulluReklam2 : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string androidGameId = "YOUR_ANDROID_GAME_ID";
    [SerializeField] string iosGameId = "YOUR_IOS_GAME_ID";
    [SerializeField] string androidAdUnitId = "Rewarded_Android";
    [SerializeField] string iosAdUnitId = "Rewarded_iOS";
    [SerializeField] bool testMode = false;
    private string gameId;
    private string adUnitId;

    GameManager gameManager;
    [SerializeField] private GameObject reklamPanel;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        reklamPanel.SetActive(false);
        // Game ID'yi platforma göre ayarla
        gameId = (Application.platform == RuntimePlatform.IPhonePlayer) ? iosGameId : androidGameId;
        adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer) ? iosAdUnitId : androidAdUnitId;

        // Unity Ads'ı başlat
        Advertisement.Initialize(gameId, testMode, this);
    }

    // IUnityAdsInitializationListener implementasyonu
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        LoadAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads initialization failed: {error.ToString()} - {message}");
    }

    // Ödüllü reklamı yüklemek için çağır
    public void LoadAd()
    {
        Debug.Log("Loading Ad: " + adUnitId);
        Advertisement.Load(adUnitId, this);
    }

    // Ödüllü reklamı göstermek için çağır
    public void ShowAd()
    {
        reklamPanel.SetActive(true);
        Advertisement.Show(adUnitId, this);
    }

    // IUnityAdsLoadListener implementasyonu
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);
    }

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    // IUnityAdsShowListener implementasyonu
    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string adUnitId)
    {
        reklamPanel.SetActive(false);
        Debug.Log("Ad Started: " + adUnitId);
    }

    public void OnUnityAdsShowClick(string adUnitId)
    {
        Debug.Log("Ad Clicked: " + adUnitId);
    }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            // Kullanıcıya ödül ver
            RewardPlayer();
        }
    }

    private void RewardPlayer()
    {
        // Kullanıcıya ödülü verme işlemleri
        PlayerPrefs.SetInt("durmakGerek", 0);
        gameManager.mekikKuvvet += 15;
        gameManager.mekikGecemediPanel.SetActive(false);
        Debug.Log("Player Rewarded!");
    }
}
