using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DilTekYonetim : MonoBehaviour
{
    public string TR;
    public string EN;
    public string DE;

    void Start()
    {
        TextDurumunuGuncelle();
    }

    public void TextDurumunuGuncelle()
    {
        if (PlayerPrefs.GetInt("hangiDil") == 0)
        {
            transform.GetComponent<Text>().text = TR;
        }
        else if (PlayerPrefs.GetInt("hangiDil") == 1)
        {
            GetComponent<Text>().text = EN;
        }
        else
        {
            GetComponent<Text>().text = DE;
        }
    }
}
