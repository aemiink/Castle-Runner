using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] public GameObject shopMenu;
    [SerializeField] public GameObject mainMenu;
    [SerializeField] public GameObject charactersMenu;

    [Header("UI Elements")]
    [SerializeField] TMP_Text gemsText; 

    void Start()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {
            GetGems();
        }
    }

    public void GetGems()
    {
        gemsText.text = PlayerPrefs.GetInt("Coins").ToString();  
    }

    public void ShopMenu()
    {
        mainMenu.SetActive(false);
        shopMenu.SetActive(true);
    }

    public void MainMenu()
    {
        shopMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void CharacterMenu()
    {
        shopMenu.SetActive(false);
        charactersMenu.SetActive(true);

    }
}

