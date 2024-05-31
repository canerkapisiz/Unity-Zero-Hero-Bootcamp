using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class OyundanCiktiManager : MonoBehaviour
{
    private const string url = "http://worldtimeapi.org/api/timezone/Etc/UTC"; // UTC zamanı için URL
    private float updateInterval = 600f; // 5 dakika (300 saniye)
    private float nextUpdateTime = 0f;

    void Start()
    {
        // İlk güncellemeyi hemen yap
        StartCoroutine(GetTimeFromAPI());
        nextUpdateTime = Time.time + updateInterval;
    }

    void Update()
    {
        // Belirli aralıklarla güncelleme yap
        if (Time.time >= nextUpdateTime)
        {
            StartCoroutine(GetTimeFromAPI());
            nextUpdateTime = Time.time + updateInterval;
        }
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

        SaveDate(day, month, year);
    }

    [Serializable]
    public class TimeApiResponse
    {
        public string datetime;
    }

    void SaveDate(int day, int month, int year)
    {
        PlayerPrefs.SetInt("yil", year);
        PlayerPrefs.SetInt("ay", month);
        PlayerPrefs.SetInt("gun", day);
    }

    private void OnApplicationPause(bool pause)
    {
        PlayerPrefs.SetInt("cankaGamesİlkGiris", 0);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("cankaGamesİlkGiris", 0);
    }
}
