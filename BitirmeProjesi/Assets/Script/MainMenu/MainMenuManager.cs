using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject[] uzayAraclari;
    [SerializeField] private GameObject cankaGamesCanvas, ayarlarPanel, whatPanel;
    [SerializeField] private Button reklamSatinAlmaButton;
    [SerializeField] private Button[] butonlar;
    [SerializeField] private Button whatButton;

    private void Awake()
    {
        //GunAyYilBilgileriAl();

        foreach (var mekik in uzayAraclari)
        {
            mekik.SetActive(false);
        }

        PlayerPrefsDegerKayit();
    }

    void Start()
    {
        whatPanel.SetActive(false);
        cankaGamesCanvas.SetActive(false);
        ayarlarPanel.SetActive(false);
        uzayAraclari[PlayerPrefs.GetInt("hangiMekik")].SetActive(true);

        //GunAyYilBilgileriAl();

        if (PlayerPrefs.GetInt("cankaGamesİlkGiris") == 0)
        {
            cankaGamesCanvas.SetActive(true);
            StartCoroutine(CankaGamesCanvasKapatma());
            PlayerPrefs.SetInt("cankaGamesİlkGiris", 1);
        }

        if (PlayerPrefs.GetInt("whatİlkGiris") == 0)
        {
            for (int i = 0; i < butonlar.Length; i++)
            {
                butonlar[i].interactable = false;
                butonlar[i].gameObject.SetActive(false);
            }
            whatButton.transform.DOScale(0f, 0f);
            ayarlarPanel.SetActive(true);
        }
        else
        {
            ayarlarPanel.SetActive(false);
        }

        if (!PlayerPrefs.HasKey("devamEtButton"))
        {
            PlayerPrefs.SetInt("devamEtButton", 0);
            PlayerPrefs.SetInt("devamEtButtonSayac", 3);
        }
    }

    void Update()
    {
        ReklamSatinAlindiMi();
    }

    public void IlkKereAyarlarKapatma()
    {
        if (PlayerPrefs.GetInt("whatİlkGiris") == 0)
        {
            StartCoroutine(ButonBuyuKucul());
        }
    }

    IEnumerator ButonBuyuKucul()
    {
        whatButton.transform.DOScale(1.5f, 1f);
        yield return new WaitForSeconds(1.2f);
        whatButton.transform.DOScale(0f, 1f);
        yield return new WaitForSeconds(1.2f);
        if (PlayerPrefs.GetInt("whatİlkGiris") != 1)
        {
            StartCoroutine(ButonBuyuKucul());
        }
        else
        {
            whatButton.transform.DOScale(1f, 0f);
        }
    }

    IEnumerator CankaGamesCanvasKapatma()
    {
        yield return new WaitForSeconds(1.5f);
        cankaGamesCanvas.SetActive(false);
    }

    public void ScenesGo(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Quit()
    {
        Application.Quit();
    }

    void PlayerPrefsDegerKayit()
    {
        if (!PlayerPrefs.HasKey("hangiMekik"))
        {
            PlayerPrefs.SetInt("hangiMekik", 0);

            PlayerPrefs.SetInt("reklamSatinAlma", 0);
            PlayerPrefs.SetInt("gecisReklamGoster", 0);
            PlayerPrefs.SetFloat("yonVerme", 0);
            PlayerPrefs.SetInt("cankaGamesİlkGiris", 0);
            PlayerPrefs.SetInt("whatİlkGiris", 0);
            PlayerPrefs.SetInt("yuksekSkor", 0);
            PlayerPrefs.SetInt("yil", 0);
            PlayerPrefs.SetInt("ay", 0);
            PlayerPrefs.SetInt("gun", 0);
            PlayerPrefs.SetInt("anaPara", 0);
            PlayerPrefs.SetInt("hangiDil", 0);
            PlayerPrefs.SetInt("mekik1", 1);
            PlayerPrefs.SetInt("mekik2", 0);
            PlayerPrefs.SetInt("mekik3", 0);
            PlayerPrefs.SetInt("mekik4", 0);
            PlayerPrefs.SetInt("mekik5", 0);
            PlayerPrefs.SetInt("mekik6", 0);

            //Paralari yazilacak
            PlayerPrefs.SetInt("mekik2Fiyat", 150000);
            PlayerPrefs.SetInt("mekik3Fiyat", 350000);
            PlayerPrefs.SetInt("mekik4Fiyat", 500000);

            //Mekik 1
            PlayerPrefs.SetInt("mekik1HizFiyat", 3000);
            PlayerPrefs.SetFloat("mekik1HizSeviye", 6f);
            PlayerPrefs.SetInt("mekik1ManevraFiyat", 3000);
            PlayerPrefs.SetFloat("mekik1ManevraSeviye", 20f);

            //Mekik 2
            PlayerPrefs.SetInt("mekik2HizFiyat", 3250);
            PlayerPrefs.SetFloat("mekik2HizSeviye", 7.5f);
            PlayerPrefs.SetInt("mekik2ManevraFiyat", 3250);
            PlayerPrefs.SetFloat("mekik2ManevraSeviye", 30);

            //Mekik 3
            PlayerPrefs.SetInt("mekik3HizFiyat", 3500);
            PlayerPrefs.SetFloat("mekik3HizSeviye", 9f);
            PlayerPrefs.SetInt("mekik3ManevraFiyat", 3500);
            PlayerPrefs.SetFloat("mekik3ManevraSeviye", 40f);

            //Mekik 4
            PlayerPrefs.SetInt("mekik4HizFiyat", 4000);
            PlayerPrefs.SetFloat("mekik4HizSeviye", 10.5f);
            PlayerPrefs.SetInt("mekik4ManevraFiyat", 4000);
            PlayerPrefs.SetFloat("mekik4ManevraSeviye", 50f);

            //Mekik 5
            PlayerPrefs.SetInt("mekik5HizFiyat", 5000);
            PlayerPrefs.SetFloat("mekik5HizSeviye", 12f);
            PlayerPrefs.SetInt("mekik5ManevraFiyat", 5000);
            PlayerPrefs.SetFloat("mekik5ManevraSeviye", 60f);

            //Mekik 6
            PlayerPrefs.SetInt("mekik6HizFiyat", 7500);
            PlayerPrefs.SetFloat("mekik6HizSeviye", 13.5f);
            PlayerPrefs.SetInt("mekik6ManevraFiyat", 7500);
            PlayerPrefs.SetFloat("mekik6ManevraSeviye", 70f);
        }
    }

    void ReklamSatinAlindiMi()
    {
        if (PlayerPrefs.GetInt("reklamSatinAlma") == 0)
        {
            reklamSatinAlmaButton.interactable = true;
        }
        else
        {
            reklamSatinAlmaButton.interactable = false;
        }
    }

    public void WhatPanelKapatmaButonAktifEtme()
    {
        for (int i = 0; i < butonlar.Length; i++)
        {
            butonlar[i].interactable = true;
        }
    }

    public void WhatIlkGirisGuncelle()
    {
        PlayerPrefs.SetInt("whatİlkGiris", 1);
    }
}
