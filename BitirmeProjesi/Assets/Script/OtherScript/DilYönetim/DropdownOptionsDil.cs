using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownOptionsDil : MonoBehaviour
{
    [SerializeField] private Dropdown dropdown;

    private void Update()
    {
        if(PlayerPrefs.GetInt("hangiDil") == 0)
        {
            dropdown.GetComponent<Dropdown>().options[0].text = "TÜRKÇE";
            dropdown.GetComponent<Dropdown>().options[1].text = "İNGİLİZCE";
            dropdown.GetComponent<Dropdown>().options[2].text = "ALMANCA";
        }
        else if (PlayerPrefs.GetInt("hangiDil") == 1)
        {
            dropdown.GetComponent<Dropdown>().options[0].text = "TURKISH";
            dropdown.GetComponent<Dropdown>().options[1].text = "ENGLISH";
            dropdown.GetComponent<Dropdown>().options[2].text = "GERMAN";
        }
        else if (PlayerPrefs.GetInt("hangiDil") == 2)
        {
            dropdown.GetComponent<Dropdown>().options[0].text = "TÜRKISCH";
            dropdown.GetComponent<Dropdown>().options[1].text = "ENGLISCH";
            dropdown.GetComponent<Dropdown>().options[2].text = "DEUTSCH";
        }
    }
}
