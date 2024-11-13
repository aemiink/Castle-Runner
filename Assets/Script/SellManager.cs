using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellManager : MonoBehaviour
{

    [Header("Img")]
    [SerializeField] Image alien;
    [SerializeField] Image survival;    
    [SerializeField] Image survivalGirl;    
    [SerializeField] Image astronout;

    [Header("Purchased Img")]
    [SerializeField] GameObject pruchasedAlien;
    [SerializeField] GameObject pruchasedSurvival;    
    [SerializeField] GameObject pruchasedSurvivalGirl;    
    [SerializeField] GameObject pruchasedAstronout;

    [Header("Destroy Objects")]
    [SerializeField] GameObject alienObjects;
    [SerializeField] GameObject survivalObjects;    
    [SerializeField] GameObject survivalGirlObjects;    
    [SerializeField] GameObject astronoutObjects;
    

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
        /*
        if (PlayerPrefs.HasKey("Coins"))
        {
            moneyAmount = PlayerPrefs.GetInt("Coins");
        }
        */
         moneyAmount = 3000;
    }

    public void alienPurchasing()
    {
        if (moneyAmount >= alienPrice)
        {
            
            moneyAmount -= alienPrice;
            //PlayerPrefs.SetInt("Coins", moneyAmount);
            characters.Add(alien);
            alienObjects.SetActive(false);
            pruchasedAlien.SetActive(true);
        } 

    }

    public void survivalPurchasing()
    {
        if (moneyAmount >= survivalPrice)
        {
            moneyAmount -= survivalPrice;
             //PlayerPrefs.SetInt("Coins", moneyAmount);
            characters.Add(survival);
            survivalObjects.SetActive(false);
            pruchasedSurvival.SetActive(true);
        } 
    }

    public void survivalGirlPurchasing()
    {
        if (moneyAmount >= survivalGirlPrice)
        {
            moneyAmount -= survivalGirlPrice;
             //PlayerPrefs.SetInt("Coins", moneyAmount);
            characters.Add(survivalGirl);
            survivalGirlObjects.SetActive(false);
            pruchasedSurvivalGirl.SetActive(true);
        } 
    }

    public void astronoutPurchasing()
    {
        if (moneyAmount >= astronoutPrice)
        {
            moneyAmount -= astronoutPrice;
             //PlayerPrefs.SetInt("Coins", moneyAmount);
            characters.Add(astronout);
            astronoutObjects.SetActive(false);
            pruchasedAstronout.SetActive(true);
        } 
    }



}
