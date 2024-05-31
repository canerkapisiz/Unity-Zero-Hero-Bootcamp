using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebDate : MonoBehaviour
{
    private const string url = "http://worldtimeapi.org/api/timezone/Etc/UTC"; // UTC zamanı için URL

    void Awake()
    {
        StartCoroutine(GetTimeFromAPI());
    }

    IEnumerator GetTimeFromAPI()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            // Web isteğini başlat
            var operation = request.SendWebRequest();

            // İsteğin tamamlanmasını bekle
            while (!operation.isDone)
            {
                yield return null;
            }

            // İsteğin sonucunu kontrol et
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                //Debug.LogError("Error: " + request.error);
            }
            else
            {
                ProcessTimeResponse(request.downloadHandler.text);
            }
        }
    }

    private void ProcessTimeResponse(string jsonResponse)
    {
        TimeApiResponse response = JsonUtility.FromJson<TimeApiResponse>(jsonResponse);
        DateTime dateTime = DateTime.Parse(response.datetime);

        int day = dateTime.Day;
        int month = dateTime.Month;
        int year = dateTime.Year;

        /*Debug.Log("Day: " + day);
        Debug.Log("Month: " + month);
        Debug.Log("Year: " + year);*/
        GunAyYilBilgileriAl(day,month,year);
        // Bu değişkenleri başka bir yerde kullanmak isterseniz, bunları sınıf seviyesinde değişken olarak saklayabilirsiniz.
        // Örnek:
        // this.day = day;
        // this.month = month;
        // this.year = year;
    }

    [Serializable]
    public class TimeApiResponse
    {
        public string datetime;
    }

    void GunAyYilBilgileriAl(int gun, int ay, int yil)
    {
        /*Debug.Log("gün " + gun);
        Debug.Log("ay " + ay);
        Debug.Log("yıl " + yil);*/

        if (yil > PlayerPrefs.GetInt("yil"))
        {
            PlayerPrefs.SetInt("kacReklamIzledinSayac", 0);
            PlayerPrefs.SetInt("devamEtButtonSayac", 3);
        }
        else if (ay > PlayerPrefs.GetInt("ay"))
        {
            PlayerPrefs.SetInt("kacReklamIzledinSayac", 0);
            PlayerPrefs.SetInt("devamEtButtonSayac", 3);
        }
        else if (gun > PlayerPrefs.GetInt("ay"))
        {
            PlayerPrefs.SetInt("kacReklamIzledinSayac", 0);
            PlayerPrefs.SetInt("devamEtButtonSayac", 3);
        }
    }
}