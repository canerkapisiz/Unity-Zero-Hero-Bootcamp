using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuShuttlesControl : MonoBehaviour
{
    [SerializeField] private Transform[] cylinder;
    private int[] zEksen = { -30, 0, 30, 60 };

    int tasimaSayac = 0;
    int tasimaDeger = 90;

    private void Update()
    {
        if (PlayerPrefs.HasKey("hangiMekik"))
        {
            switch (PlayerPrefs.GetInt("hangiMekik"))
            {
                case 0:
                    transform.Translate(6f * Time.deltaTime * -transform.forward);
                    break;
                case 1:
                    transform.Translate(6f * Time.deltaTime * transform.forward);
                    break;
                case 2:
                    transform.Translate(6f * Time.deltaTime * transform.forward);
                    break;
                case 3:
                    transform.Translate(6f * Time.deltaTime * -transform.forward);
                    break;
                case 4:
                    transform.Translate(6f * Time.deltaTime * transform.forward);
                    break;
                case 5:
                    transform.Translate(6f * Time.deltaTime * transform.forward);
                    break;
            }
        }
       
        for (int i = 0; i < cylinder.Length; i++)
        {
            cylinder[i].transform.position = new Vector3(0f, 0f, zEksen[i]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("gecis"))
        {
            SilindirTasima();
        }
    }

    void SilindirTasima()
    {
        zEksen[tasimaSayac] = tasimaDeger;
        tasimaDeger += 30;
        tasimaSayac++;

        if (tasimaSayac == zEksen.Length)
        {
            tasimaSayac = 0;
        }
    }
}
