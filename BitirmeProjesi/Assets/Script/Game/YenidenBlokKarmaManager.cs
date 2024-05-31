using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Core.Easing;
using TMPro;
using UnityEngine;

public class YenidenBlokKarmaManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] silindir1, silindir2, silindir3, silindir4, silindir5, silindir6;

    GameManager gameManager;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    void SilindirKapatma(GameObject[] silindirHangisi)
    {
        for (int i = 0; i < silindirHangisi.Length; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                silindirHangisi[i].transform.GetChild(j).gameObject.SetActive(false);
                silindirHangisi[i].transform.GetChild(j).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = "";
            }
        }
    }

    void SilindirAcma(GameObject[] silindirHangisi)
    {
        for (int i = 0; i < silindirHangisi.Length; i++)
        {
            int deger = Random.Range(0, 11);
            silindirHangisi[i].transform.GetChild(deger).gameObject.SetActive(true);
        }
    }

    public void SilindirTextGuncelle(GameObject[] bloklar)
    {
        for (int i = 0; i < bloklar.Length; i++)
        {
            if (bloklar[i].transform.GetChild(0).gameObject.activeSelf == true)
            {
                int sayi2 = Random.Range(0, 2);
                int sayi3 = Random.Range(2, 6);
                if (sayi2 == 0)
                {
                    bloklar[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Canvas>().transform.GetChild(0).GetComponent<TMP_Text>().text = "+" + sayi3.ToString();
                }
                else
                {
                    bloklar[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Canvas>().transform.GetChild(0).GetComponent<TMP_Text>().text = "*" + sayi3.ToString();
                }
            }
            else if (bloklar[i].transform.GetChild(1).gameObject.activeSelf == true)
            {
                int sayi = Random.Range(gameManager.mekikKuvvet / 2, gameManager.mekikKuvvet + 6);
                if(sayi == 0)
                {
                    sayi = 1;
                }
                bloklar[i].transform.GetChild(1).transform.GetChild(0).GetComponent<Canvas>().transform.GetChild(0).GetComponent<TMP_Text>().text = sayi.ToString();
            }
            else if (bloklar[i].transform.GetChild(2).gameObject.activeSelf == true)
            {
                int sayi = Random.Range(gameManager.mekikKuvvet / 2, gameManager.mekikKuvvet + 6);
                if (sayi == 0)
                {
                    sayi = 1;
                }
                bloklar[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Canvas>().transform.GetChild(0).GetComponent<TMP_Text>().text = sayi.ToString();
            }
            else if (bloklar[i].transform.GetChild(3).gameObject.activeSelf == true)
            {
                int sayi = Random.Range(gameManager.mekikKuvvet / 2, gameManager.mekikKuvvet + 6);
                if (sayi == 0)
                {
                    sayi = 1;
                }
                bloklar[i].transform.GetChild(3).transform.GetChild(0).GetComponent<Canvas>().transform.GetChild(0).GetComponent<TMP_Text>().text = sayi.ToString();
            }
            else if (bloklar[i].transform.GetChild(4).gameObject.activeSelf == true)
            {
                int sayi = Random.Range(gameManager.mekikKuvvet / 2, gameManager.mekikKuvvet + 6);
                if (sayi == 0)
                {
                    sayi = 1;
                }
                bloklar[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Canvas>().transform.GetChild(0).GetComponent<TMP_Text>().text = sayi.ToString();
            }
            else if (bloklar[i].transform.GetChild(5).gameObject.activeSelf == true)
            {
                int sayi = Random.Range(gameManager.mekikKuvvet / 2, gameManager.mekikKuvvet + 6);
                if (sayi == 0)
                {
                    sayi = 1;
                }
                bloklar[i].transform.GetChild(5).transform.GetChild(0).GetComponent<Canvas>().transform.GetChild(0).GetComponent<TMP_Text>().text = sayi.ToString();
            }
            else if (bloklar[i].transform.GetChild(6).gameObject.activeSelf == true)
            {
                int sayi = Random.Range(gameManager.mekikKuvvet / 2, gameManager.mekikKuvvet + 6);
                if (sayi == 0)
                {
                    sayi = 1;
                }
                bloklar[i].transform.GetChild(6).transform.GetChild(0).GetComponent<Canvas>().transform.GetChild(0).GetComponent<TMP_Text>().text = sayi.ToString();
            }
            else if (bloklar[i].transform.GetChild(7).gameObject.activeSelf == true)
            {
                int sayi = Random.Range(gameManager.mekikKuvvet / 2, gameManager.mekikKuvvet + 6);
                if (sayi == 0)
                {
                    sayi = 1;
                }
                bloklar[i].transform.GetChild(7).transform.GetChild(0).GetComponent<Canvas>().transform.GetChild(0).GetComponent<TMP_Text>().text = sayi.ToString();
            }
            else if (bloklar[i].transform.GetChild(8).gameObject.activeSelf == true)
            {
                int sayi = Random.Range(gameManager.mekikKuvvet / 2, gameManager.mekikKuvvet + 6);
                if (sayi == 0)
                {
                    sayi = 1;
                }
                bloklar[i].transform.GetChild(8).transform.GetChild(0).GetComponent<Canvas>().transform.GetChild(0).GetComponent<TMP_Text>().text = sayi.ToString();
            }
            else if (bloklar[i].transform.GetChild(9).gameObject.activeSelf == true)
            {
                int sayi = Random.Range(gameManager.mekikKuvvet / 2, gameManager.mekikKuvvet + 6);
                if (sayi == 0)
                {
                    sayi = 1;
                }
                bloklar[i].transform.GetChild(9).transform.GetChild(0).GetComponent<Canvas>().transform.GetChild(0).GetComponent<TMP_Text>().text = sayi.ToString();
            }
            else if (bloklar[i].transform.GetChild(10).gameObject.activeSelf == true)
            {
                int sayi = Random.Range(gameManager.mekikKuvvet / 2, gameManager.mekikKuvvet + 6);
                if (sayi == 0)
                {
                    sayi = 1;
                }
                bloklar[i].transform.GetChild(10).transform.GetChild(0).GetComponent<Canvas>().transform.GetChild(0).GetComponent<TMP_Text>().text = sayi.ToString();
            }
        }
    }

    public void YenidenDegerlendirAmaYavas(int sayi)
    {
        switch (sayi)
        {
            case 0:
                SilindirKapatma(silindir6);
                SilindirAcma(silindir6);
                SilindirTextGuncelle(silindir2);
                break;
            case 1:
                SilindirKapatma(silindir1);
                SilindirAcma(silindir1);
                SilindirTextGuncelle(silindir3);
                break;
            case 2:
                SilindirKapatma(silindir2);
                SilindirAcma(silindir2);
                SilindirTextGuncelle(silindir4);
                break;
            case 3:
                SilindirKapatma(silindir3);
                SilindirAcma(silindir3);
                SilindirTextGuncelle(silindir5);
                break;
            case 4:
                SilindirKapatma(silindir4);
                SilindirAcma(silindir4);
                SilindirTextGuncelle(silindir6);
                break;
            case 5:
                SilindirKapatma(silindir5);
                SilindirAcma(silindir5);
                SilindirTextGuncelle(silindir1);
                break;
        }
    }
}
