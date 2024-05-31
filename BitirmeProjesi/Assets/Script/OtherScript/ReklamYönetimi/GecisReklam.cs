using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class GecisReklam : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
#if UNITY_IOS
        private string gameId = "5626126";
#elif UNITY_ANDROID
    private string gameId = "5626127";
#endif

    private string interstitialAdPlacementId = "Interstitial_Android"; // Dashboard'daki yerleşim ID'si
    private bool testMode = false;

    void Start()
    {
        InitializeAds();
    }

    private void InitializeAds()
    {
        if (Advertisement.isSupported)
        {
            Debug.Log("Initializing Unity Ads...");
            Advertisement.Initialize(gameId, testMode, this);
        }
        else
        {
            Debug.LogWarning("Platform not supported for Unity Ads");
        }
    }

    public void LoadInterstitialAd()
    {
        Debug.Log("Loading Interstitial Ad...");
        Advertisement.Load(interstitialAdPlacementId, this);
    }

    public void ShowInterstitialAd()
    {
        Debug.Log("Showing Interstitial Ad...");
        Advertisement.Show(interstitialAdPlacementId, this);
    }

    // Implement IUnityAdsInitializationListener interface methods:
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        LoadInterstitialAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.LogError($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    // Implement IUnityAdsLoadListener interface methods:
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log($"Ad Loaded: {placementId}");
        if (placementId == interstitialAdPlacementId)
        {
            Debug.Log("Interstitial Ad is ready to be shown.");
        }
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.LogError($"Error loading Ad Unit {placementId}: {error.ToString()} - {message}");
    }

    // Implement IUnityAdsShowListener interface methods:
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.LogError($"Error showing Ad Unit {placementId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Ad Started: " + placementId);
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("Ad Clicked: " + placementId);
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log($"Ad Completed: {placementId} - {showCompletionState.ToString()}");

        // Optionally load the next ad
        LoadInterstitialAd();
    }
}
