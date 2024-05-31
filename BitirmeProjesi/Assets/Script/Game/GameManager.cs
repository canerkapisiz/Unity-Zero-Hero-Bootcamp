using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening.Core.Easing;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] uzayAraclari;

    [SerializeField] private GameObject[] canvaslar;
    [SerializeField] private TMP_Text[] mekiklerinTextleri;
    public int mekikKuvvet = 10;
    public GameObject mekikGecemediPanel;

    public int yuksekSkorSayici = 0;

    [SerializeField] private Text yuksekSkorText, anaParaText;
    [SerializeField] private ParticleSystem[] efect;
    [SerializeField] private Button reklamIzlemeButton, devamEtButton;
    [SerializeField] private Text devamEtText;
    GecisReklam gecisReklam;

    void Start()
    {
        if (PlayerPrefs.GetInt("devamEtButton") == 0)
        {
            reklamIzlemeButton.gameObject.SetActive(true);
            devamEtButton.gameObject.SetActive(false);
            devamEtText.gameObject.SetActive(false);
        }
        else
        {
            reklamIzlemeButton.gameObject.SetActive(false);
            devamEtButton.gameObject.SetActive(true);
            devamEtText.gameObject.SetActive(true);
        }
        gecisReklam = FindAnyObjectByType<GecisReklam>();
        PlayerPrefs.SetInt("durmakGerek", 0);
        mekikGecemediPanel.SetActive(false);
        StartCoroutine(OyunBaslamasi());
    }

    IEnumerator OyunBaslamasi()
    {
        yield return new WaitForSeconds(3f);
        canvaslar[0].SetActive(false);
        uzayAraclari[PlayerPrefs.GetInt("hangiMekik")].SetActive(true);
    }

    void Update()
    {
        anaParaText.text = PlayerPrefs.GetInt("anaPara").ToString() + " ck";
        MekiklerinKuvvetYaziKontrol();

        DevamEtButonBilgileri();
    }

    void MekiklerinKuvvetYaziKontrol()
    {
        mekiklerinTextleri[PlayerPrefs.GetInt("hangiMekik")].text = mekikKuvvet.ToString();
    }

    public void MekiklerinDegeriniArtirma(string deger)
    {
        char ilk = deger[0];
        string sondeger = "";
        for (int i = 1; i < deger.Length; i++)
        {
            sondeger += deger[i];
        }

        int sayi = int.Parse(sondeger);

        switch (ilk)
        {
            case '+':
                mekikKuvvet = mekikKuvvet + sayi;
                break;
            case '*':
                mekikKuvvet = mekikKuvvet * sayi;
                break;
        }
    }

    public void MekikGecebilirMi(string deger)
    {
        int sayi = int.Parse(deger);
        if (mekikKuvvet > sayi)
        {
            efect[PlayerPrefs.GetInt("hangiMekik")].Play();
            mekikKuvvet = mekikKuvvet - sayi;
        }
        else
        {
            if (PlayerPrefs.GetInt("yuksekSkor") < yuksekSkorSayici)
            {
                PlayerPrefs.SetInt("yuksekSkor", yuksekSkorSayici);
                if (PlayerPrefs.GetInt("hangiDil") == 0)
                {
                    yuksekSkorText.text = "Yeni Yüksek Skor " + PlayerPrefs.GetInt("yuksekSkor").ToString();
                }
                else if (PlayerPrefs.GetInt("hangiDil") == 1)
                {
                    yuksekSkorText.text = "New High Score " + PlayerPrefs.GetInt("yuksekSkor").ToString();
                }
                else
                {
                    yuksekSkorText.text = "Neuer Highscore " + PlayerPrefs.GetInt("yuksekSkor").ToString();
                }
            }
            mekikGecemediPanel.SetActive(true);
            PlayerPrefs.SetInt("durmakGerek", 1);
            if (PlayerPrefs.GetInt("gecisReklamGoster") % 3 == 0)
            {
                if (PlayerPrefs.GetInt("reklamSatinAlma") == 0)
                {
                    gecisReklam.ShowInterstitialAd();
                }
            }
            PlayerPrefs.SetInt("gecisReklamGoster", PlayerPrefs.GetInt("gecisReklamGoster") + 1);
        }
    }

    public void AnaSayfaGit()
    {
        SceneManager.LoadScene(0);
    }

    public void TekrarOyna()
    {
        SceneManager.LoadScene(2);
    }

    public void Durdurabiliriz()
    {
        mekikGecemediPanel.SetActive(true);
    }

    public void DevamEtButtonTiklandi()
    {
        if(PlayerPrefs.GetInt("devamEtButton") == 1)
        {
            PlayerPrefs.SetInt("durmakGerek", 0);
            mekikKuvvet += 15;
            mekikGecemediPanel.SetActive(false);
            PlayerPrefs.SetInt("devamEtButtonSayac", PlayerPrefs.GetInt("devamEtButtonSayac") - 1);
        }
    }

    public void DevamEtButonBilgileri()
    {
        if(PlayerPrefs.GetInt("devamEtButton") == 1)
        {
            if (PlayerPrefs.GetInt("devamEtButtonSayac") == 0)
            {
                devamEtButton.interactable = false;
            }
            string aciklama = "";
            if (PlayerPrefs.GetInt("hangiDil") == 0)
            {
                aciklama = "Devam Etme Hakkınız : " + PlayerPrefs.GetInt("devamEtButtonSayac");
            }
            else if (PlayerPrefs.GetInt("hangiDil") == 1)
            {
                aciklama = "Your Right to Continue : " + PlayerPrefs.GetInt("devamEtButtonSayac");
            }
            else if (PlayerPrefs.GetInt("hangiDil") == 2)
            {
                aciklama = "Ihr Recht auf Fortsetzung : " + PlayerPrefs.GetInt("devamEtButtonSayac");
            }
            devamEtText.text = aciklama;
        }
    }
}