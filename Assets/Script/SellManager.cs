using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellManager : MonoBehaviour
{

    [Header("Lists")]
    [SerializeField] Image alien;
    [SerializeField] Image survival;    
    [SerializeField] Image survivalGirl;    
    [SerializeField] Image astronout;

    [Header("Character Price")]
    int alienPrice = 500;
    int survivalPrice = 750;
    int survivalGirlPrice = 750;
    int astronoutPrice = 500;

    [Header("Money")]
    int moneyAmount;

    [Header("Lists")]
    public List<Image> characters = new List<Image>();


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {
            moneyAmount = PlayerPrefs.GetInt("Coins");
        }
    }

    public void alienPurchasing()
    {
        if (moneyAmount >= alienPrice)
        {
            moneyAmount -= alienPrice;
            PlayerPrefs.SetInt("Coins", moneyAmount);
            characters.Add(alien);
            Destroy(alien);
        } 

    }

    public void survivalPurchasing()
    {
        if (moneyAmount >= survivalPrice)
        {
            moneyAmount -= survivalPrice;
            PlayerPrefs.SetInt("Coins", moneyAmount);
            characters.Add(survival);
            Destroy(survival);
        } 
    }

    public void survivalGirlPurchasing()
    {
        if (moneyAmount >= survivalGirlPrice)
        {
            moneyAmount -= survivalGirlPrice;
            PlayerPrefs.SetInt("Coins", moneyAmount);
            characters.Add(survivalGirl);
            Destroy(survivalGirl);
        } 
    }

    public void astronoutPurchasing()
    {
        if (moneyAmount >= astronoutPrice)
        {
            moneyAmount -= astronoutPrice;
            PlayerPrefs.SetInt("Coins", moneyAmount);
            characters.Add(astronout);
            Destroy(astronout);
        } 
    }



}
