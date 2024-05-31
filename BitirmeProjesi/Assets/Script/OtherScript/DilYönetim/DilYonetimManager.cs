using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DilYonetimManager : MonoBehaviour
{
    public string TR;
    public string EN;
    public string DE;

    public void TextDurumunuGuncelle(int tercihNedir)
    {
        if (tercihNedir == 0)
        {
            GetComponent<Text>().text = TR;
        }
        else if(tercihNedir == 1)
        {
            GetComponent<Text>().text = EN;
        }
        else
        {
            GetComponent<Text>().text = DE;
        }
    }
}
