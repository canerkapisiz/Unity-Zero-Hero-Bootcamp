using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InternetSorgu : MonoBehaviour
{
    [SerializeField] private GameObject internetPanel;

    void Update()
    {
        if (!CheckInternet())
        {
            internetPanel.SetActive(true);
            if(SceneManager.GetActiveScene().buildIndex != 0)
            {
                SceneManager.LoadScene(0);
            }
        }
        else
        {
            internetPanel.SetActive(false);
        }
    }

    bool CheckInternet()
    {
        // Bağlantı türünü kontrol et
        NetworkReachability reachability = Application.internetReachability;

        // İnternet bağlantısı var mı yok mu kontrol et
        if (reachability == NetworkReachability.NotReachable)
        {
            return false; // İnternet bağlantısı yok
        }
        else
        {
            return true; // İnternet bağlantısı var
        }
    }
}
