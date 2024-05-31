using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class WhatTextYonetim : MonoBehaviour
{
    private string TR = "Oyunun amacı, seçtiğimiz uzay aracını engeller veya ödül bölgelerinden geçerek sonsuz bir yolculuğa çıkarmaktır. " +
        // Uzay aracımızın üzerinde yazan güçten küçük değerli engelleri kırarak geçebiliriz.
        //"\nEngellerin üzerinde yazan kuvvetleri, Uzay araçlarımızın üzerinde yazan kuvvetleri ile kırarak geçebiliriz. " +
        "\nUzay aracımızın üzerinde yazan güçten daha az değere sahip engelleri aşabiliriz. " +
        // Engel veya Ödül bölgelerimiz var, Ödül bölgelerinden geçerek uzay araçlarımızın gücünü artırabiliriz. 
        //"\nÖdül olarak ise + ya da * ödül bölgelernden geçerek Uzay araçlarımızın gücünü artırabiliriz. " +
        "\nEngel veya Ödül bölgelerimiz var ve Ödül bölgelerinden geçerek uzay aracımızın gücünü artırabiliyoruz. " +
        "\nİstasyona girerek uzay aracımızın hızını ve manevra kabiliyetini artırabiliriz. " +
        "\nHadi Başlayalım...";
    private string EN = "The aim of the game is to take our chosen spacecraft on an endless journey through obstacles or reward zones. " +
        // Uzay aracımızın üzerinde yazan güçten küçük değerli engelleri kırarak geçebiliriz.
        //"\nEngellerin üzerinde yazan kuvvetleri, Uzay araçlarımızın üzerinde yazan kuvvetleri ile kırarak geçebiliriz. " +
        "\nWe can overcome obstacles that are worth less than the power on our spacecraft. " +
        // Engel veya Ödül bölgelerimiz var, Ödül bölgelerinden geçerek uzay araçlarımızın gücünü artırabiliriz. 
        //"\nÖdül olarak ise + ya da * ödül bölgelernden geçerek Uzay araçlarımızın gücünü artırabiliriz. " +
        "\nWe have Obstacle or Reward zones, and we can increase the power of our spacecraft by going through the Reward zones. " +
        "\nBy entering the station, we can increase the speed and maneuverability of our spacecraft. " +
        "\nLet's get started...";
    private string DE = "Das Ziel des Spiels ist es, unser ausgewähltes Raumschiff auf eine endlose Reise durch Hindernisse oder Belohnungszonen zu bringen. " +
        // Uzay aracımızın üzerinde yazan güçten küçük değerli engelleri kırarak geçebiliriz.
        //"\nEngellerin üzerinde yazan kuvvetleri, Uzay araçlarımızın üzerinde yazan kuvvetleri ile kırarak geçebiliriz. " +
        "\nWir können Hindernisse überwinden, die weniger wert sind als die Energie unseres Raumschiffs. " +
        // Engel veya Ödül bölgelerimiz var, Ödül bölgelerinden geçerek uzay araçlarımızın gücünü artırabiliriz. 
        //"\nÖdül olarak ise + ya da * ödül bölgelernden geçerek Uzay araçlarımızın gücünü artırabiliriz. " +
        "\nWir haben Hindernis- oder Belohnungszonen, und wir können die Leistung unseres Raumschiffs erhöhen, indem wir die Belohnungszonen durchlaufen. " +
        "\nWenn wir zur Station gehen, können wir die Geschwindigkeit und die Manövrierfähigkeit unseres Raumschiffs erhöhen. " +
        "\nFangen wir an...";
    [SerializeField] private Text whatText;

    public void Start()
    {
        StopAllCoroutines();
        if (PlayerPrefs.GetInt("hangiDil") == 0)
        {
            StartCoroutine(TextYazdirma(TR));
        }
        else if (PlayerPrefs.GetInt("hangiDil") == 1)
        {
            StartCoroutine(TextYazdirma(EN));
        }
        else if (PlayerPrefs.GetInt("hangiDil") == 2)
        {
            StartCoroutine(TextYazdirma(DE));
        }
    }

    IEnumerator TextYazdirma(string dilDeger)
    {
        whatText.text = "";
        for (int i = 0; i < dilDeger.Length; i++)
        {
            whatText.text += dilDeger[i];
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void DirektYaz()
    {
        whatText.text = "";
        StopAllCoroutines();
        if (PlayerPrefs.GetInt("hangiDil") == 0)
        {
            whatText.text = TR;
        }
        else if (PlayerPrefs.GetInt("hangiDil") == 1)
        {
            whatText.text = EN;
        }
        else if (PlayerPrefs.GetInt("hangiDil") == 2)
        {
            whatText.text = DE;
        }
    }
}
