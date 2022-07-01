using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BossemDollar : MonoBehaviour
{
    [Header("Bossem")]
    public BossemDollarDatabase bossem; 
    public TMP_Text bossemtext;
 
    public static BossemDollar instance;
    public GameObject testsnack;
    public GameObject givesnack;
    public GameObject bossemDollarButton;

    public int initialCoins;

    SheepleConversation sheepleConversation;
    ButtonAnimation buttonanimation;

    private void Awake()
    {
        instance = this;
        
    }
    
    //
    public void Start()
    {
        initialCoins = PlayerPrefs.GetInt("NumberOfCoins");
        
        BossemStart();   

        sheepleConversation = GameObject.Find("HomeButton").GetComponent<SheepleConversation>();
        buttonanimation = GameObject.Find("BossemDollarSignButton").GetComponent<ButtonAnimation>();
      
    }
   

    //
    public void BossemStart()
    {
                
        // InitalCoins variable stores the intial score from the 
        // player pref and is updated over the game cycle
        initialCoins = RetrieveSavedCoinScore();

        // Adds the initialCoin to the coin to be dispalyed in unity
        UpdateCoinUI(initialCoins);

        //Collects the image specified in the scriptable objects
             
    }
   
    public void BossemRemove(int coins)
    {
        
        if(initialCoins <= 0)
        {

            givesnack.SetActive(false);
            sheepleConversation.BuySnakRequest();
            buttonanimation.enabled = true;
            initialCoins = 0;
            return;
            
        }
        else if(initialCoins >= coins)
        {
            initialCoins -= bossem.BossemDollarRemove;
            SaveCoinScore(initialCoins);
            UpdateCoinUI(initialCoins);
            sheepleConversation.ThankYou();
        }
    }
    

    
    
    
   
    // 
    public void BossemAdd()
    {

        initialCoins += bossem.BossemDollarAdd;
        
        SaveCoinScore(initialCoins);
        UpdateCoinUI(initialCoins);
    }

   
    //
    public void UpdateCoinUI(int curScore){
        bossemtext.text = " " + curScore.ToString();
         
    }
    
    // 
    public void SetDefaults(){
        //Sets player score to 100 if a new game
        if(RetrieveSavedCoinScore() == 0){
            PlayerPrefs.SetInt("initialCoins", 100);    
        }
    }

    //
    public void SaveCoinScore(int curScore){
        PlayerPrefs.SetInt("initialCoins", curScore);
    }

    //
    public int RetrieveSavedCoinScore(){
        return PlayerPrefs.GetInt("initialCoins", 5);
    }
    
    
    
}
