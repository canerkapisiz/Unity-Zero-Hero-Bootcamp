using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class StationManager : MonoBehaviour
{
    [SerializeField] private GameObject[] uzayAraclari;
    [SerializeField] private Button secmeButton, reklamIzleButton, solButton, sagButton, satinAlmaButton, geriDonButton;
    [SerializeField] private Text reklamIzleText;
    [SerializeField] private Text anaParaText;
    public GameObject almakIsterMisinPanel;
    [SerializeField] private Text almakIsterMisinPanelText, almakIsterMisinPanelButtonText1, almakIsterMisinPanelButtonText2;
    [SerializeField] private Button almakIsterMisinPanelButton1;
    [SerializeField] private Button[] mekiklerHizButton;
    [SerializeField] private Button[] mekiklerManevraButton;
    int sayac = 0, artisDegeri = 0;
    [SerializeField] private Text mekik2Fiyat, mekik3Fiyat, mekik4Fiyat;

    [Header("Uzay Mekiklerinin Panel Degiskenleri")]
    [SerializeField] private RectTransform[] mekiklerPanel;
    [SerializeField] private GameObject[] mekiklerAlinmadiPanel;
    [SerializeField] private GameObject[] mekiklerAlindiPanel;
    [SerializeField] private Slider[] mekiklerHizSlider;
    [SerializeField] private Slider[] mekiklerManevraSlider;

    [SerializeField] private Text[] mekiklerHizText;
    [SerializeField] private Text[] mekiklerinManevraText;
    public GameObject reklamIzleParaKazan;

    void Start()
    {
        reklamIzleParaKazan.SetActive(false);
       
        BaslangicMekikSirasiAyarlama();
        if (!PlayerPrefs.HasKey("reklamArabaSayac"))
        {
            PlayerPrefs.SetInt("reklamArabaSayac", 0);
        }

        ReklamIzleButtonTextYazdirma();
        PanellerButonlarKontrol();
        MekiklerHizveManevraSliderDegerKontrolu();
        MekiklerHizVeManevraButtonKapaliMi();
        almakIsterMisinPanel.SetActive(false);
        ButtonAyarlama();
        mekik2Fiyat.text = PlayerPrefs.GetInt("mekik2Fiyat").ToString() + " ck";
        mekik3Fiyat.text = PlayerPrefs.GetInt("mekik3Fiyat").ToString() + " ck";
        mekik4Fiyat.text = PlayerPrefs.GetInt("mekik4Fiyat").ToString() + " ck";

        SliderBilgiTextGuncelleme();
    }

    void Update()
    {
        anaParaText.text = PlayerPrefs.GetInt("anaPara").ToString() + " ck";
        SecilenMekikButonAktif();
        ButtonAyarlama();
        ButonlarKontrol();
        PanellerButonlarKontrol();
        MekiklerHizveManevraSliderDegerKontrolu();
        MekiklerHizVeManevraButtonKapaliMi();
        ReklamIzleButtonTextYazdirma();
        Debug.Log(sayac);
    }

    void ButtonAyarlama()
    {
        // Araba kaydirma isleminde en sol ya da en saga geldigimiz de butonlari kapatmak icin
        if (sayac == uzayAraclari.Length - 1)
        {
            sagButton.interactable = false;
        }
        else
        {
            sagButton.interactable = true;
        }

        if (sayac == 0)
        {
            solButton.interactable = false;
        }
        else
        {
            solButton.interactable = true;
        }
    }

    public void SolBas()
    {
        // Sol tuşa basıldığında arabalar sağa doğru kaysın diye yazıldı
        if (sayac < uzayAraclari.Length - 1)
        {
            sayac++;
            uzayAraclari[sayac - 1].GetComponent<Transform>().DOLocalMoveZ(-16, 1.5f);
            if (sayac == 1 || sayac == 4)
            {
                uzayAraclari[sayac - 1].transform.DOLocalRotate(new Vector3(0f, 90f, 0f), 4f);
            }
            else
            {
                uzayAraclari[sayac - 1].transform.DOLocalRotate(new Vector3(0f, 180f, 0f), 4f);
            }
            //uzayAraclari[sayac - 1].transform.DOLocalRotate(new Vector3(0f, 180f, 0f), 4f);
            uzayAraclari[sayac].GetComponent<Transform>().DOLocalMoveZ(-28, 1.5f);
            if (sayac == 0 || sayac == 3)
            {
                uzayAraclari[sayac].transform.DOLocalRotate(new Vector3(0f, -140f, 0f), 4f);
            }
            else
            {
                uzayAraclari[sayac].transform.DOLocalRotate(new Vector3(0f, -50f, 0f), 4f);
            }
            //uzayAraclari[sayac].transform.DOLocalRotate(new Vector3(0f, -50f, 0f), 4f);

            mekiklerPanel[sayac - 1].DOAnchorPos(new Vector2(-3484f, mekiklerPanel[sayac - 1].offsetMax.y), 3f);
            mekiklerPanel[sayac - 1].DOAnchorPos(new Vector2(-3484f, mekiklerPanel[sayac - 1].offsetMax.y), 3f);

            mekiklerPanel[sayac].DOAnchorPos(new Vector2(0, mekiklerPanel[sayac].offsetMax.y), 3f);
            mekiklerPanel[sayac].DOAnchorPos(new Vector2(0, mekiklerPanel[sayac].offsetMax.y), 3f);
            ButtonAyarlama();
            SecilenMekikButonAktif();
            ButonlarKontrol();
            PanellerButonlarKontrol();
        }
    }

    public void SagBas()
    {
        // Sağ tuşa basıldığında arabalar sola doğru kaysın diye yazıldı
        if (sayac > 0)
        {
            sayac--;
            uzayAraclari[sayac].GetComponent<Transform>().DOLocalMoveZ(-28, 1.5f);
            if (sayac == 0 || sayac == 3)
            {
                uzayAraclari[sayac].transform.DOLocalRotate(new Vector3(0f, 140f, 0f), 4f);
            }
            else
            {
                uzayAraclari[sayac].transform.DOLocalRotate(new Vector3(0f, -130f, 0f), 4f);
            }
            uzayAraclari[sayac + 1].GetComponent<Transform>().DOLocalMoveZ(-41, 1.5f);
            if (sayac == 2)
            {
                uzayAraclari[sayac + 1].transform.DOLocalRotate(new Vector3(0f, -90f, 0f), 4f);
            }
            else
            {
                uzayAraclari[sayac + 1].transform.DOLocalRotate(new Vector3(0f, 0f, 0f), 4f);
            }

            mekiklerPanel[sayac].DOAnchorPos(new Vector2(0, mekiklerPanel[sayac].offsetMax.y), 3f);
            mekiklerPanel[sayac].DOAnchorPos(new Vector2(0, mekiklerPanel[sayac].offsetMax.y), 3f);

            mekiklerPanel[sayac + 1].DOAnchorPos(new Vector2(3484f, mekiklerPanel[sayac + 1].offsetMax.y), 3f);
            mekiklerPanel[sayac + 1].DOAnchorPos(new Vector2(3484f, mekiklerPanel[sayac + 1].offsetMax.y), 3f);
            ButtonAyarlama();
            SecilenMekikButonAktif();
            ButonlarKontrol();
            PanellerButonlarKontrol();
        }
    }

    public void MekikSecme()
    {
        // Kullanmak istediğimiz arabayı seçmek için yazıldı
        PlayerPrefs.SetInt("hangiMekik", sayac);
    }

    void SecilenMekikButonAktif()
    {
        // Seçilen arabanın seçme butonu aktif olmasın seçilmeyen arabanın seçme butonu aktif olsun diye yazıldı
        if (PlayerPrefs.GetInt("hangiMekik") != sayac)
        {
            secmeButton.interactable = true;
        }
        else
        {
            secmeButton.interactable = false;
        }
    }

    void BaslangicMekikSirasiAyarlama()
    {
        // Önceden seçtiğimiz arabaya göre arabaları sola ya da sağa hizalasın diye yazıldı
        sayac = PlayerPrefs.GetInt("hangiMekik");
        for (int i = 0; i < PlayerPrefs.GetInt("hangiMekik"); i++)
        {
            uzayAraclari[i].transform.localPosition = new Vector3(0f, 10f, -16f);
            if (i == 0 || i == 3)
            {
                uzayAraclari[i].transform.DOLocalRotate(new Vector3(0f, 90, 0f), 0.1f);
            }
            else
            {
                uzayAraclari[i].transform.DOLocalRotate(new Vector3(0f, 180, 0f), 0.1f);
            }
            mekiklerPanel[i].offsetMax = new Vector2(-3484f, mekiklerPanel[i].offsetMax.y);
            mekiklerPanel[i].offsetMin = new Vector2(-3484f, mekiklerPanel[i].offsetMin.y);
        }

        uzayAraclari[PlayerPrefs.GetInt("hangiMekik")].transform.localPosition = new Vector3(0f, 10f, -28f);
        Debug.Log(uzayAraclari[sayac].transform.rotation.y);
        if (sayac == 0 || sayac == 3)
        {
            uzayAraclari[PlayerPrefs.GetInt("hangiMekik")].transform.DOLocalRotate(new Vector3(0f, -140, 0f), 0.1f);
        }
        else
        {
            uzayAraclari[PlayerPrefs.GetInt("hangiMekik")].transform.DOLocalRotate(new Vector3(0f, -50, 0f), 0.1f);
        }
        mekiklerPanel[PlayerPrefs.GetInt("hangiMekik")].offsetMax = new Vector2(0, mekiklerPanel[PlayerPrefs.GetInt("hangiMekik")].offsetMax.y);
        mekiklerPanel[PlayerPrefs.GetInt("hangiMekik")].offsetMin = new Vector2(0, mekiklerPanel[PlayerPrefs.GetInt("hangiMekik")].offsetMin.y);

        for (int i = PlayerPrefs.GetInt("hangiMekik") + 1; i < uzayAraclari.Length; i++)
        {
            Debug.Log(uzayAraclari[i].transform.rotation.y);
            uzayAraclari[i].transform.localPosition = new Vector3(0f, 10f, -41f);
            if (i == 0 || i == 3)
            {
                uzayAraclari[i].transform.DOLocalRotate(new Vector3(0f, -90f, 0f), 0.1f);
            }
            else
            {
                uzayAraclari[i].transform.DOLocalRotate(new Vector3(0f, 0f, 0f), 0.1f);
            }
            mekiklerPanel[i].offsetMax = new Vector2(3484f, mekiklerPanel[i].offsetMax.y);
            mekiklerPanel[i].offsetMin = new Vector2(3484f, mekiklerPanel[i].offsetMin.y);
        }

        PanellerButonlarKontrol();
        ButonlarKontrol();
        ButtonAyarlama();
    }

    public void AnaMenuDon()
    {
        // Ana menüye dönmek için yazıldı
        SceneManager.LoadScene(0);
    }

    void ButonlarKontrol()
    {
        // reklam butonu ve satin alma butonunun kontrolu gerlestiriliyor
        if (sayac >= uzayAraclari.Length - 2)
        {
            if (PlayerPrefs.GetInt("reklamArabaSayac") != 20 && uzayAraclari.Length - 2 == sayac)
            {
                if (PlayerPrefs.GetInt("kacReklamIzledinSayac") < 4)
                {
                    secmeButton.gameObject.SetActive(false);
                    reklamIzleButton.gameObject.SetActive(true);
                    satinAlmaButton.gameObject.SetActive(false);
                }
                else if (PlayerPrefs.GetInt("kacReklamIzledinSayac") >= 4)
                {
                    secmeButton.gameObject.SetActive(false);
                    reklamIzleButton.gameObject.SetActive(false);
                    satinAlmaButton.gameObject.SetActive(false);
                }
            }
            else if (PlayerPrefs.GetInt("reklamArabaSayac") == 20 && uzayAraclari.Length - 2 == sayac)
            {
                secmeButton.gameObject.SetActive(true);
                reklamIzleButton.gameObject.SetActive(false);
                satinAlmaButton.gameObject.SetActive(false);
            }

            if (PlayerPrefs.GetInt("mekik6") != 1 && uzayAraclari.Length - 1 == sayac)
            {
                reklamIzleButton.gameObject.SetActive(false);
                secmeButton.gameObject.SetActive(false);
                satinAlmaButton.gameObject.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("mekik6") == 1 && uzayAraclari.Length - 1 == sayac)
            {
                reklamIzleButton.gameObject.SetActive(false);
                secmeButton.gameObject.SetActive(true);
                satinAlmaButton.gameObject.SetActive(false);
            }
        }
        if (uzayAraclari.Length - 2 > sayac)
        {
            /*if (uzayAraclari.Length - 1 == sayac)
            {
                secmeButton.gameObject.SetActive(true);
                satinAlmaButton.gameObject.SetActive(false);
            }
            else if (uzayAraclari.Length - 2 == sayac)
            {
                secmeButton.gameObject.SetActive(true);
                reklamIzleButton.gameObject.SetActive(false);
            }
            else
            {*/
            if (PlayerPrefs.GetInt("mekik1") == 1 && sayac == 0)
            {
                secmeButton.gameObject.SetActive(true);
            }
            else
            {
                secmeButton.gameObject.SetActive(false);
            }
            if (PlayerPrefs.GetInt("mekik2") == 0 && sayac == 1)
            {
                reklamIzleButton.gameObject.SetActive(false);
                satinAlmaButton.gameObject.SetActive(false);
                secmeButton.gameObject.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("mekik3") == 0 && sayac == 2)
            {
                reklamIzleButton.gameObject.SetActive(false);
                satinAlmaButton.gameObject.SetActive(false);
                secmeButton.gameObject.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("mekik4") == 0 && sayac == 3)
            {
                reklamIzleButton.gameObject.SetActive(false);
                satinAlmaButton.gameObject.SetActive(false);
                secmeButton.gameObject.SetActive(false);
            }
            else
            {
                reklamIzleButton.gameObject.SetActive(false);
                satinAlmaButton.gameObject.SetActive(false);
                secmeButton.gameObject.SetActive(true);
            }
        }
    }

    public void ReklamIzleButtonTextYazdirma()
    {
        // kac tane reklam izlenecek izldeigimiz reklam saysini belirten buton
        if (PlayerPrefs.GetInt("hangiDil") == 0)
        {
            reklamIzleText.text = "İzlenilmesi Gereken Reklam Sayisi = 20 \n İzlenilen Reklam Sayısı = " + PlayerPrefs.GetInt("reklamArabaSayac").ToString();
        }
        else if (PlayerPrefs.GetInt("hangiDil") == 1)
        {
            reklamIzleText.text = "Number of Ads to Watch = 20 \n Number of Ads Viewed = " + PlayerPrefs.GetInt("reklamArabaSayac").ToString();
        }
        else
        {
            reklamIzleText.text = "Anzahl der zu beobachtenden Anzeigen = 20 \n Anzahl der gesehenen Anzeigen = " + PlayerPrefs.GetInt("reklamArabaSayac").ToString();
        }
    }

    void PanellerButonlarKontrol()
    {
        if (PlayerPrefs.GetInt("mekik2") == 0)
        {
            mekiklerAlinmadiPanel[0].SetActive(true);
            mekiklerAlindiPanel[0].SetActive(false);
        }
        else
        {
            mekiklerAlinmadiPanel[0].SetActive(false);
            mekiklerAlindiPanel[0].SetActive(true);
        }

        if (PlayerPrefs.GetInt("mekik3") == 0)
        {
            mekiklerAlinmadiPanel[1].SetActive(true);
            mekiklerAlindiPanel[1].SetActive(false);
        }
        else
        {
            mekiklerAlinmadiPanel[1].SetActive(false);
            mekiklerAlindiPanel[1].SetActive(true);
        }

        if (PlayerPrefs.GetInt("mekik4") == 0)
        {
            mekiklerAlinmadiPanel[2].SetActive(true);
            mekiklerAlindiPanel[2].SetActive(false);
        }
        else
        {
            mekiklerAlinmadiPanel[2].SetActive(false);
            mekiklerAlindiPanel[2].SetActive(true);
        }

        if (PlayerPrefs.GetInt("mekik5") == 0)
        {
            mekiklerAlinmadiPanel[3].SetActive(true);
            mekiklerAlindiPanel[3].SetActive(false);
        }
        else
        {
            mekiklerAlinmadiPanel[3].SetActive(false);
            mekiklerAlindiPanel[3].SetActive(true);
        }

        if (PlayerPrefs.GetInt("mekik6") == 0)
        {
            mekiklerAlinmadiPanel[4].SetActive(true);
            mekiklerAlindiPanel[4].SetActive(false);
        }
        else
        {
            mekiklerAlinmadiPanel[4].SetActive(false);
            mekiklerAlindiPanel[4].SetActive(true);
        }
    }

    void MekiklerHizveManevraSliderDegerKontrolu()
    {
        mekiklerHizSlider[0].value = PlayerPrefs.GetFloat("mekik1HizSeviye");
        mekiklerHizSlider[1].value = PlayerPrefs.GetFloat("mekik2HizSeviye");
        mekiklerHizSlider[2].value = PlayerPrefs.GetFloat("mekik3HizSeviye");
        mekiklerHizSlider[3].value = PlayerPrefs.GetFloat("mekik4HizSeviye");
        mekiklerHizSlider[4].value = PlayerPrefs.GetFloat("mekik5HizSeviye");
        mekiklerHizSlider[5].value = PlayerPrefs.GetFloat("mekik6HizSeviye");

        mekiklerManevraSlider[0].value = PlayerPrefs.GetFloat("mekik1ManevraSeviye");
        mekiklerManevraSlider[1].value = PlayerPrefs.GetFloat("mekik2ManevraSeviye");
        mekiklerManevraSlider[2].value = PlayerPrefs.GetFloat("mekik3ManevraSeviye");
        mekiklerManevraSlider[3].value = PlayerPrefs.GetFloat("mekik4ManevraSeviye");
        mekiklerManevraSlider[4].value = PlayerPrefs.GetFloat("mekik5ManevraSeviye");
        mekiklerManevraSlider[5].value = PlayerPrefs.GetFloat("mekik6ManevraSeviye");
    }

    public void EvetYadaHayirButonCevap(int index)
    {
        int cevap = artisDegeri + index;
        int deger;
        if (cevap == 0)
        {
            PlayerPrefs.SetFloat("mekik1HizSeviye", PlayerPrefs.GetFloat("mekik1HizSeviye") + 0.5f);
            PlayerPrefs.SetInt("anaPara", PlayerPrefs.GetInt("anaPara") - PlayerPrefs.GetInt("mekik1HizFiyat"));
            deger = PlayerPrefs.GetInt("mekik1HizFiyat") / 4;
            PlayerPrefs.SetInt("mekik1HizFiyat", PlayerPrefs.GetInt("mekik1HizFiyat") + deger);
        }
        else if (cevap == 1)
        {
            PlayerPrefs.SetFloat("mekik2HizSeviye", PlayerPrefs.GetFloat("mekik2HizSeviye") + 0.5f);
            PlayerPrefs.SetInt("anaPara", PlayerPrefs.GetInt("anaPara") - PlayerPrefs.GetInt("mekik2HizFiyat"));
            deger = PlayerPrefs.GetInt("mekik2HizFiyat") / 4;
            PlayerPrefs.SetInt("mekik2HizFiyat", PlayerPrefs.GetInt("mekik2HizFiyat") + deger);
        }
        else if (cevap == 2)
        {
            PlayerPrefs.SetFloat("mekik3HizSeviye", PlayerPrefs.GetFloat("mekik3HizSeviye") + 0.5f);
            PlayerPrefs.SetInt("anaPara", PlayerPrefs.GetInt("anaPara") - PlayerPrefs.GetInt("mekik3HizFiyat"));
            deger = PlayerPrefs.GetInt("mekik3HizFiyat") / 4;
            PlayerPrefs.SetInt("mekik3HizFiyat", PlayerPrefs.GetInt("mekik3HizFiyat") + deger);
        }
        else if (cevap == 3)
        {
            PlayerPrefs.SetFloat("mekik4HizSeviye", PlayerPrefs.GetFloat("mekik4HizSeviye") + 0.5f);
            PlayerPrefs.SetInt("anaPara", PlayerPrefs.GetInt("anaPara") - PlayerPrefs.GetInt("mekik4HizFiyat"));
            deger = PlayerPrefs.GetInt("mekik4HizFiyat") / 4;
            PlayerPrefs.SetInt("mekik4HizFiyat", PlayerPrefs.GetInt("mekik4HizFiyat") + deger);
        }
        else if (cevap == 4)
        {
            PlayerPrefs.SetFloat("mekik5HizSeviye", PlayerPrefs.GetFloat("mekik5HizSeviye") + 0.5f);
            PlayerPrefs.SetInt("anaPara", PlayerPrefs.GetInt("anaPara") - PlayerPrefs.GetInt("mekik5HizFiyat"));
            deger = PlayerPrefs.GetInt("mekik5HizFiyat") / 4;
            PlayerPrefs.SetInt("mekik5HizFiyat", PlayerPrefs.GetInt("mekik5HizFiyat") + deger);
        }
        else if (cevap == 5)
        {
            PlayerPrefs.SetFloat("mekik6HizSeviye", PlayerPrefs.GetFloat("mekik6HizSeviye") + 0.5f);
            PlayerPrefs.SetInt("anaPara", PlayerPrefs.GetInt("anaPara") - PlayerPrefs.GetInt("mekik6HizFiyat"));
            deger = PlayerPrefs.GetInt("mekik6HizFiyat") / 4;
            PlayerPrefs.SetInt("mekik6HizFiyat", PlayerPrefs.GetInt("mekik6HizFiyat") + deger);
        }
        else if (cevap == 6)
        {
            PlayerPrefs.SetFloat("mekik1ManevraSeviye", PlayerPrefs.GetFloat("mekik1ManevraSeviye") + 5f);
            PlayerPrefs.SetInt("anaPara", PlayerPrefs.GetInt("anaPara") - PlayerPrefs.GetInt("mekik1ManevraFiyat"));
            deger = PlayerPrefs.GetInt("mekik1ManevraFiyat") / 4;
            PlayerPrefs.SetInt("mekik1ManevraFiyat", PlayerPrefs.GetInt("mekik1ManevraFiyat") + deger);
        }
        else if (cevap == 7)
        {
            PlayerPrefs.SetFloat("mekik2ManevraSeviye", PlayerPrefs.GetFloat("mekik2ManevraSeviye") + 5f);
            PlayerPrefs.SetInt("anaPara", PlayerPrefs.GetInt("anaPara") - PlayerPrefs.GetInt("mekik2ManevraFiyat"));
            deger = PlayerPrefs.GetInt("mekik2ManevraFiyat") / 4;
            PlayerPrefs.SetInt("mekik2ManevraFiyat", PlayerPrefs.GetInt("mekik2ManevraFiyat") + deger);
        }
        else if (cevap == 8)
        {
            PlayerPrefs.SetFloat("mekik3ManevraSeviye", PlayerPrefs.GetFloat("mekik3ManevraSeviye") + 5f);
            PlayerPrefs.SetInt("anaPara", PlayerPrefs.GetInt("anaPara") - PlayerPrefs.GetInt("mekik3ManevraFiyat"));
            deger = PlayerPrefs.GetInt("mekik3ManevraFiyat") / 4;
            PlayerPrefs.SetInt("mekik3ManevraFiyat", PlayerPrefs.GetInt("mekik3ManevraFiyat") + deger);
        }
        else if (cevap == 9)
        {
            PlayerPrefs.SetFloat("mekik4ManevraSeviye", PlayerPrefs.GetFloat("mekik4ManevraSeviye") + 5f);
            PlayerPrefs.SetInt("anaPara", PlayerPrefs.GetInt("anaPara") - PlayerPrefs.GetInt("mekik4ManevraFiyat"));
            deger = PlayerPrefs.GetInt("mekik4ManevraFiyat") / 4;
            PlayerPrefs.SetInt("mekik4ManevraFiyat", PlayerPrefs.GetInt("mekik4ManevraFiyat") + deger);
        }
        else if (cevap == 10)
        {
            PlayerPrefs.SetFloat("mekik5ManevraSeviye", PlayerPrefs.GetFloat("mekik5ManevraSeviye") + 5f);
            PlayerPrefs.SetInt("anaPara", PlayerPrefs.GetInt("anaPara") - PlayerPrefs.GetInt("mekik5ManevraFiyat"));
            deger = PlayerPrefs.GetInt("mekik5ManevraFiyat") / 4;
            PlayerPrefs.SetInt("mekik5ManevraFiyat", PlayerPrefs.GetInt("mekik5ManevraFiyat") + deger);
        }
        else if (cevap == 11)
        {
            PlayerPrefs.SetFloat("mekik6ManevraSeviye", PlayerPrefs.GetFloat("mekik6ManevraSeviye") + 5f);
            PlayerPrefs.SetInt("anaPara", PlayerPrefs.GetInt("anaPara") - PlayerPrefs.GetInt("mekik6ManevraFiyat"));
            deger = PlayerPrefs.GetInt("mekik6ManevraFiyat") / 4;
            PlayerPrefs.SetInt("mekik6ManevraFiyat", PlayerPrefs.GetInt("mekik6ManevraFiyat") + deger);
        }
        else if (cevap == 12)
        {
            PlayerPrefs.SetInt("mekik2", 1);
        }
        else if (cevap == 13)
        {
            PlayerPrefs.SetInt("mekik3", 1);
        }
        else if (cevap == 14)
        {
            PlayerPrefs.SetInt("mekik4", 1);
        }
        else if (cevap > 90)
        {
            almakIsterMisinPanel.SetActive(false);
        }
        almakIsterMisinPanel.SetActive(false);
        anaParaText.text = PlayerPrefs.GetInt("anaPara").ToString() + " ck";
        MekiklerHizveManevraSliderDegerKontrolu();
        MekiklerHizVeManevraButtonKapaliMi();
        PanellerButonlarKontrol();
        ButonlarKontrol();
        SliderBilgiTextGuncelleme();
    }

    public void MekikHizArtirma(int index)
    {
        int hizArtirmaDeger = -1;
        switch (index)
        {
            case 0:
                hizArtirmaDeger = PlayerPrefs.GetInt("mekik1HizFiyat");
                break;
            case 1:
                hizArtirmaDeger = PlayerPrefs.GetInt("mekik2HizFiyat");
                break;
            case 2:
                hizArtirmaDeger = PlayerPrefs.GetInt("mekik3HizFiyat");
                break;
            case 3:
                hizArtirmaDeger = PlayerPrefs.GetInt("mekik4HizFiyat");
                break;
            case 4:
                hizArtirmaDeger = PlayerPrefs.GetInt("mekik5HizFiyat");
                break;
            case 5:
                hizArtirmaDeger = PlayerPrefs.GetInt("mekik6HizFiyat");
                break;
            case 6:
                hizArtirmaDeger = PlayerPrefs.GetInt("mekik1ManevraFiyat");
                break;
            case 7:
                hizArtirmaDeger = PlayerPrefs.GetInt("mekik2ManevraFiyat");
                break;
            case 8:
                hizArtirmaDeger = PlayerPrefs.GetInt("mekik3ManevraFiyat");
                break;
            case 9:
                hizArtirmaDeger = PlayerPrefs.GetInt("mekik4ManevraFiyat");
                break;
            case 10:
                hizArtirmaDeger = PlayerPrefs.GetInt("mekik5ManevraFiyat");
                break;
            case 11:
                hizArtirmaDeger = PlayerPrefs.GetInt("mekik6ManevraFiyat");
                break;
        }

        if (6 > index)
        {
            if (PlayerPrefs.GetInt("anaPara") >= hizArtirmaDeger)
            {
                if (PlayerPrefs.GetInt("hangiDil") == 0)
                {
                    almakIsterMisinPanelText.text = hizArtirmaDeger.ToString() + " ck " + "Uzay Aracınızın Hızını Artırmak İster Misiniz?";
                }
                else if (PlayerPrefs.GetInt("hangiDil") == 1)
                {
                    almakIsterMisinPanelText.text = hizArtirmaDeger.ToString() + " ck " + "Do You Want to Increase the Speed of Your Spacecraft?";
                }
                else
                {
                    almakIsterMisinPanelText.text = hizArtirmaDeger.ToString() + " ck " + "Möchten Sie die Geschwindigkeit Ihres Raumfahrzeugs erhöhen?";
                }
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("anaPara") >= hizArtirmaDeger)
            {
                if (PlayerPrefs.GetInt("hangiDil") == 0)
                {
                    almakIsterMisinPanelText.text = hizArtirmaDeger.ToString() + " ck " + "Uzay Aracınızın Manevra Hızını Artırmak İster Misiniz?";
                }
                else if (PlayerPrefs.GetInt("hangiDil") == 1)
                {
                    almakIsterMisinPanelText.text = hizArtirmaDeger.ToString() + " ck " + "Do You Want to Increase the Maneuvering Speed ​​of Your Spacecraft?";
                }
                else
                {
                    almakIsterMisinPanelText.text = hizArtirmaDeger.ToString() + " ck " + "Möchten Sie die Manövriergeschwindigkeit Ihres Raumfahrzeugs erhöhen?";
                }
            }
        }

        if (PlayerPrefs.GetInt("anaPara") >= hizArtirmaDeger)
        {
            almakIsterMisinPanel.SetActive(true);
            if (PlayerPrefs.GetInt("hangiDil") == 0)
            {
                almakIsterMisinPanelButtonText1.text = "EVET";
                almakIsterMisinPanelButtonText2.text = "HAYIR";
            }
            else if (PlayerPrefs.GetInt("hangiDil") == 1)
            {
                almakIsterMisinPanelButtonText1.text = "YES";
                almakIsterMisinPanelButtonText2.text = "NO";
            }
            else
            {
                almakIsterMisinPanelButtonText1.text = "JA";
                almakIsterMisinPanelButtonText2.text = "NEIN";
            }

            almakIsterMisinPanelButton1.gameObject.SetActive(true);
            artisDegeri = index;
        }
        else
        {
            almakIsterMisinPanel.SetActive(true);
            if (PlayerPrefs.GetInt("hangiDil") == 0)
            {
                almakIsterMisinPanelText.text = "Yeterli Paranız Yok";
                almakIsterMisinPanelButtonText2.text = "KAPAT";
            }
            else if (PlayerPrefs.GetInt("hangiDil") == 1)
            {
                almakIsterMisinPanelText.text = "Not Enough Money";
                almakIsterMisinPanelButtonText2.text = "CLOSE";
            }
            else
            {
                almakIsterMisinPanelText.text = "Nicht genug Geld";
                almakIsterMisinPanelButtonText2.text = "SCHLIESSEN";
            }
            almakIsterMisinPanelButton1.gameObject.SetActive(false);

            StartCoroutine(paraKazanmaPanelAcma());
        }
    }

    void MekiklerHizVeManevraButtonKapaliMi()
    {
        if (PlayerPrefs.GetFloat("mekik1HizSeviye") == mekiklerHizSlider[0].maxValue)
        {
            mekiklerHizButton[0].interactable = false;
        }
        if (PlayerPrefs.GetFloat("mekik2HizSeviye") == mekiklerHizSlider[1].maxValue)
        {
            mekiklerHizButton[1].interactable = false;
        }
        if (PlayerPrefs.GetFloat("mekik3HizSeviye") == mekiklerHizSlider[2].maxValue)
        {
            mekiklerHizButton[2].interactable = false;
        }
        if (PlayerPrefs.GetFloat("mekik4HizSeviye") == mekiklerHizSlider[3].maxValue)
        {
            mekiklerHizButton[3].interactable = false;
        }
        if (PlayerPrefs.GetFloat("mekik5HizSeviye") == mekiklerHizSlider[4].maxValue)
        {
            mekiklerHizButton[4].interactable = false;
        }
        if (PlayerPrefs.GetFloat("mekik6HizSeviye") == mekiklerHizSlider[5].maxValue)
        {
            mekiklerHizButton[5].interactable = false;
        }

        if (PlayerPrefs.GetFloat("mekik1ManevraSeviye") == mekiklerManevraSlider[0].maxValue)
        {
            mekiklerManevraButton[0].interactable = false;
        }
        if (PlayerPrefs.GetFloat("mekik2ManevraSeviye") == mekiklerManevraSlider[1].maxValue)
        {
            mekiklerManevraButton[1].interactable = false;
        }
        if (PlayerPrefs.GetFloat("mekik3ManevraSeviye") == mekiklerManevraSlider[2].maxValue)
        {
            mekiklerManevraButton[2].interactable = false;
        }
        if (PlayerPrefs.GetFloat("mekik4ManevraSeviye") == mekiklerManevraSlider[3].maxValue)
        {
            mekiklerManevraButton[3].interactable = false;
        }
        if (PlayerPrefs.GetFloat("mekik5ManevraSeviye") == mekiklerManevraSlider[4].maxValue)
        {
            mekiklerManevraButton[4].interactable = false;
        }
        if (PlayerPrefs.GetFloat("mekik6ManevraSeviye") == mekiklerManevraSlider[5].maxValue)
        {
            mekiklerManevraButton[5].interactable = false;
        }
    }

    public void MekikSatinAlma(int index)
    {
        int satinAlmaDeger = -1;
        switch (index)
        {
            case 12:
                satinAlmaDeger = PlayerPrefs.GetInt("mekik2Fiyat");
                break;
            case 13:
                satinAlmaDeger = PlayerPrefs.GetInt("mekik3Fiyat");
                break;
            case 14:
                satinAlmaDeger = PlayerPrefs.GetInt("mekik4Fiyat");
                break;
        }

        if (PlayerPrefs.GetInt("anaPara") >= satinAlmaDeger)
        {
            almakIsterMisinPanel.SetActive(true);
            if (index == 12)
            {
                if (PlayerPrefs.GetInt("hangiDil") == 0)
                {
                    almakIsterMisinPanelText.text = "2. Uzay Aracını Almak İster Misiniz?";
                }
                else if (PlayerPrefs.GetInt("hangiDil") == 1)
                {
                    almakIsterMisinPanelText.text = "Would you like to buy the 2nd Spacecraft?";
                }
                else
                {
                    almakIsterMisinPanelText.text = "Möchten Sie das 2. Raumschiff kaufen?";
                }
            }
            else if (index == 13)
            {
                if (PlayerPrefs.GetInt("hangiDil") == 0)
                {
                    almakIsterMisinPanelText.text = "3. Uzay Aracını Almak İster Misiniz?";
                }
                else if (PlayerPrefs.GetInt("hangiDil") == 1)
                {
                    almakIsterMisinPanelText.text = "Do you want to buy the 3rd Spacecraft?";
                }
                else
                {
                    almakIsterMisinPanelText.text = "Möchten Sie das 3. Raumschiff kaufen?";
                }
            }
            else if (index == 14)
            {
                if (PlayerPrefs.GetInt("hangiDil") == 0)
                {
                    almakIsterMisinPanelText.text = "4. Uzay Aracını Almak İster Misiniz?";
                }
                else if (PlayerPrefs.GetInt("hangiDil") == 1)
                {
                    almakIsterMisinPanelText.text = "Do you want to buy the 4th Spacecraft?";
                }
                else
                {
                    almakIsterMisinPanelText.text = "Möchten Sie das 4. Raumschiff kaufen?";
                }
            }

            if (PlayerPrefs.GetInt("hangiDil") == 0)
            {
                almakIsterMisinPanelButtonText1.text = "EVET";
                almakIsterMisinPanelButtonText2.text = "HAYIR";
            }
            else if (PlayerPrefs.GetInt("hangiDil") == 1)
            {
                almakIsterMisinPanelButtonText1.text = "YES";
                almakIsterMisinPanelButtonText2.text = "NO";
            }
            else
            {
                almakIsterMisinPanelButtonText1.text = "JA";
                almakIsterMisinPanelButtonText2.text = "NEIN";
            }
            almakIsterMisinPanelButton1.gameObject.SetActive(true);
            artisDegeri = index;
        }
        else
        {
            almakIsterMisinPanel.SetActive(true);
            if (PlayerPrefs.GetInt("hangiDil") == 0)
            {
                almakIsterMisinPanelText.text = "Yeterli Paranız Yok";
                almakIsterMisinPanelButtonText2.text = "KAPAT";
            }
            else if (PlayerPrefs.GetInt("hangiDil") == 1)
            {
                almakIsterMisinPanelText.text = "Not Enough Money";
                almakIsterMisinPanelButtonText2.text = "CLOSE";
            }
            else
            {
                almakIsterMisinPanelText.text = "Nicht genug Geld";
                almakIsterMisinPanelButtonText2.text = "SCHLIESSEN";
            }
            almakIsterMisinPanelButton1.gameObject.SetActive(false);

            StartCoroutine(paraKazanmaPanelAcma());
        }
    }

    void SliderBilgiTextGuncelleme()
    {
        for (int i = 0; i < mekiklerHizSlider.Length; i++)
        {
            mekiklerHizText[i].text = mekiklerHizSlider[i].value.ToString();
        }

        for (int i = 0; i < mekiklerManevraSlider.Length; i++)
        {
            mekiklerinManevraText[i].text = mekiklerManevraSlider[i].value.ToString();
        }
    }

    IEnumerator paraKazanmaPanelAcma()
    {
        yield return new WaitForSeconds(0.3f);
        reklamIzleParaKazan.SetActive(true);
        secmeButton.gameObject.SetActive(false);
        reklamIzleButton.gameObject.SetActive(false);
        solButton.gameObject.SetActive(false);
        sagButton.gameObject.SetActive(false);
        satinAlmaButton.gameObject.SetActive(false);
        geriDonButton.gameObject.SetActive(false);
        for (int i = 0; i < mekiklerPanel.Length; i++)
        {
            mekiklerPanel[i].gameObject.SetActive(false);
        }
    }

    public void ParaKazanmaPanelleriİleİlgili()
    {
        reklamIzleParaKazan.SetActive(false);
        almakIsterMisinPanel.SetActive(false);
        secmeButton.gameObject.SetActive(true);
        reklamIzleButton.gameObject.SetActive(true);
        solButton.gameObject.SetActive(true);
        sagButton.gameObject.SetActive(true);
        satinAlmaButton.gameObject.SetActive(true);
        geriDonButton.gameObject.SetActive(true);
        for (int i = 0; i < mekiklerPanel.Length; i++)
        {
            mekiklerPanel[i].gameObject.SetActive(true);
        }
    }
}
