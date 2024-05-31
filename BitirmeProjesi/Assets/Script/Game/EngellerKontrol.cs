using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EngellerKontrol : MonoBehaviour
{
    [SerializeField] private GameObject[] engeller;
    int deger;
    GameManager gameManager;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        for (int i = 0; i < engeller.Length; i++)
        {
            engeller[i].SetActive(false);
        }

        deger = Random.Range(0, engeller.Length);

        engeller[deger].SetActive(true);

        if (deger == 0)
        {
            int sayi1 = Random.Range(0, 2);
            int sayi2 = Random.Range(2, 9);
            if (sayi1 == 0)
            {
                engeller[0].transform.GetChild(0).GetComponent<Canvas>().transform.GetChild(0).GetComponent<TMP_Text>().text = "+" + sayi2.ToString();
            }
            else
            {
                engeller[0].transform.GetChild(0).GetComponent<Canvas>().transform.GetChild(0).GetComponent<TMP_Text>().text = "*" + sayi2.ToString();
            }
        }
        else
        {
            if (deger != engeller.Length)
            {
                int sayi = Random.Range(gameManager.mekikKuvvet / 2, gameManager.mekikKuvvet + 5);
                if(sayi == 0)
                {
                    sayi = 1;
                }
                engeller[deger].transform.GetChild(0).GetComponent<Canvas>().transform.GetChild(0).GetComponent<TMP_Text>().text = sayi.ToString();
            }
        }
    }
}
