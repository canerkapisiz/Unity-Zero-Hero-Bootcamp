using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DilManager : MonoBehaviour
{
    public Dropdown DiltercihiDrop;

    public List<Text> TextObjeleri;

    void Start()
    {
        if (!PlayerPrefs.HasKey("hangiDil"))
        {
            PlayerPrefs.SetInt("hangiDil", 0);
            DiltercihiDrop.value = PlayerPrefs.GetInt("hangiDil");
            DilKontrol(PlayerPrefs.GetInt("hangiDil"), false);
        }
        else
        {
            DiltercihiDrop.value = PlayerPrefs.GetInt("hangiDil");
            DilKontrol(PlayerPrefs.GetInt("hangiDil"), false);
        }
    }

    public void SecilenNedir(int gelenDeger)
    {
        DilKontrol(gelenDeger, true);
    }

    void DilKontrol(int dilIndex, bool dropmu)
    {
        if (dilIndex == 0)
        {
            for (int i = 0; i < TextObjeleri.Count; i++)
            {
                TextObjeleri[i].GetComponent<DilYonetimManager>().TextDurumunuGuncelle(dilIndex);
            }
            if (dropmu)
            {
                PlayerPrefs.SetInt("hangiDil", 0);
            }
        }
        else if(dilIndex == 1)
        {
            for (int i = 0; i < TextObjeleri.Count; i++)
            {
                TextObjeleri[i].GetComponent<DilYonetimManager>().TextDurumunuGuncelle(dilIndex);
            }
            if (dropmu)
            {
                PlayerPrefs.SetInt("hangiDil", 1);
            }
        }
        else if (dilIndex == 2)
        {
            for (int i = 0; i < TextObjeleri.Count; i++)
            {
                TextObjeleri[i].GetComponent<DilYonetimManager>().TextDurumunuGuncelle(dilIndex);
            }
            if (dropmu)
            {
                PlayerPrefs.SetInt("hangiDil", 2);
            }
        }
    }
}
