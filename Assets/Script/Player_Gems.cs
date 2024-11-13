using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Gems : MonoBehaviour
{
    CharacterScript characterScript;
    
    [Header("Gems Values")]
    [SerializeField] int valueGems;
    // Start is called before the first frame update
    void Start()
    {
        characterScript = FindObjectOfType<CharacterScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Eğer paraya dokunan objenin "Player" etiketi varsa
        if (other.CompareTag("player"))
        {
            // Kayıtlı bilgilerden para miktarına bakmak ve geçici bir değişkende depolamak
            // Eğer böyle bir bilgi yoksa değeri sıfıra eşitlemek
            var value = PlayerPrefs.GetInt("Coins", 0);
            // "Coins" alanında saklanan para miktarını güncellemek
            // Bunu yapabilmek için geçici değişkendeki değere bir eklememiz lazım
            PlayerPrefs.SetInt("Coins", value + valueGems);
            // UI güncelleme fonksiyonunu çağıralım (hatayı görmezden gelebilirsiniz; daha fonksiyonu yazmadık)
            characterScript.GetGems();
        }
    }

}
