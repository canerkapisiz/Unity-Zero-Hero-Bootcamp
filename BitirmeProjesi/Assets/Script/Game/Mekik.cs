using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mekik : MonoBehaviour
{
    public Transform[] cylinder;
    private int[] zEksen = { -30, 0, 30, 60, 90, 120 };

    int tasimaDeger = 150;
    int degmesayac = 0;
    int silindirDondurmeSayac = 1;

    YenidenBlokKarmaManager yenidenBlokKarmaManager;
    GameManager gameManager;

    float hizPlayerPrefs, manevraPlayerPrefs;
    private Vector3 direction;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("hangiMekik") == 0)
        {
            hizPlayerPrefs = PlayerPrefs.GetFloat("mekik1HizSeviye");
            manevraPlayerPrefs = PlayerPrefs.GetFloat("mekik1ManevraSeviye");
            direction = transform.right;
        }
        else if (PlayerPrefs.GetInt("hangiMekik") == 1)
        {
            hizPlayerPrefs = PlayerPrefs.GetFloat("mekik2HizSeviye");
            manevraPlayerPrefs = PlayerPrefs.GetFloat("mekik2ManevraSeviye");
            direction = transform.forward;
        }
        else if (PlayerPrefs.GetInt("hangiMekik") == 2)
        {
            hizPlayerPrefs = PlayerPrefs.GetFloat("mekik3HizSeviye");
            manevraPlayerPrefs = PlayerPrefs.GetFloat("mekik3ManevraSeviye");
            direction = transform.forward;
        }
        else if (PlayerPrefs.GetInt("hangiMekik") == 3)
        {
            hizPlayerPrefs = PlayerPrefs.GetFloat("mekik4HizSeviye");
            manevraPlayerPrefs = PlayerPrefs.GetFloat("mekik4ManevraSeviye");
            direction = transform.right;
        }
        else if (PlayerPrefs.GetInt("hangiMekik") == 4)
        {
            hizPlayerPrefs = PlayerPrefs.GetFloat("mekik5HizSeviye");
            manevraPlayerPrefs = PlayerPrefs.GetFloat("mekik5ManevraSeviye");
            direction = transform.forward;
        }
        else if (PlayerPrefs.GetInt("hangiMekik") == 5)
        {
            hizPlayerPrefs = PlayerPrefs.GetFloat("mekik6HizSeviye");
            manevraPlayerPrefs = PlayerPrefs.GetFloat("mekik6ManevraSeviye");
            direction = transform.forward;
        }
    }

    private void Start()
    {
        yenidenBlokKarmaManager = FindAnyObjectByType<YenidenBlokKarmaManager>();
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void Update()
    {
        //transform.RotateAround(cylinder[silindirDondurmeSayac].transform.position, Vector3.forward, 50 * Time.deltaTime);
        if (PlayerPrefs.GetInt("durmakGerek") == 1)
        {
            Vector3 forwardMovement = 0 * direction * hizPlayerPrefs * Time.deltaTime;
            transform.position += forwardMovement;
        }
        else
        {
            Vector3 forwardMovement = direction * hizPlayerPrefs * Time.deltaTime;
            transform.position += forwardMovement;
        }
        transform.RotateAround(cylinder[silindirDondurmeSayac].transform.position, Vector3.forward, PlayerPrefs.GetFloat("yonVerme") * manevraPlayerPrefs * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("gecis"))
        {
            int sayi = int.Parse(other.name);
            StartCoroutine(ObjeTasima(sayi));
            gameManager.yuksekSkorSayici += Random.Range(0, 20);
            degmesayac = 0;
            yenidenBlokKarmaManager.YenidenDegerlendirAmaYavas(sayi);
            if (sayi == 0)
            {
                silindirDondurmeSayac = 2;
            }
            else if (sayi == 1)
            {
                silindirDondurmeSayac = 3;
            }
            else if (sayi == 2)
            {
                silindirDondurmeSayac = 4;
            }
            else if (sayi == 3)
            {
                silindirDondurmeSayac = 5;
            }
            else if (sayi == 4)
            {
                silindirDondurmeSayac = 0;
            }
            else if (sayi == 5)
            {
                silindirDondurmeSayac = 1;
            }
        }
        else if (other.CompareTag("engel") && degmesayac == 0)
        {
            int paracik = int.Parse(other.transform.GetChild(0).GetComponent<Canvas>().transform.GetChild(0).GetComponent<TMP_Text>().text);
            PlayerPrefs.SetInt("anaPara", PlayerPrefs.GetInt("anaPara") + (paracik / 2));
            gameManager.MekikGecebilirMi(other.transform.GetChild(0).GetComponent<Canvas>().transform.GetChild(0).GetComponent<TMP_Text>().text);
            other.gameObject.SetActive(false);
            degmesayac++;
        }
        else if (other.CompareTag("odul") && degmesayac == 0)
        {
            gameManager.MekiklerinDegeriniArtirma(other.transform.GetChild(0).GetComponent<Canvas>().transform.GetChild(0).GetComponent<TMP_Text>().text);
            degmesayac++;
        }
    }

    IEnumerator ObjeTasima(int sayi)
    {
        yield return new WaitForSeconds(0.3f);
        if (sayi == 0)
        {
            cylinder[0].transform.position = new Vector3(0f, 0f, tasimaDeger);
        }
        else if (sayi == 1)
        {
            cylinder[1].transform.position = new Vector3(0f, 0f, tasimaDeger);
        }
        else if (sayi == 2)
        {
            cylinder[2].transform.position = new Vector3(0f, 0f, tasimaDeger);
        }
        else if (sayi == 3)
        {
            cylinder[3].transform.position = new Vector3(0f, 0f, tasimaDeger);
        }
        else if (sayi == 4)
        {
            cylinder[4].transform.position = new Vector3(0f, 0f, tasimaDeger);
        }
        else if (sayi == 5)
        {
            cylinder[5].transform.position = new Vector3(0f, 0f, tasimaDeger);
        }

        tasimaDeger += 30;
    }
}
