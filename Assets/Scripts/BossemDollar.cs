using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossemDollar : MonoBehaviour
{
    [Header("Bossem")]
    public BossemDollarDatabase bossem; 
    public TMP_Text bossemtext;
 
    public static BossemDollar instance;
    public GameObject testsnack;
    public GameObject proceedButton;
    public GameObject bossemDollarButton;

    public int initialCoins;

    private Animator animator;


    SheepleConversation sheepleConversation;
    ButtonAnimation buttonanimation;
    PlayModeMovements playModeMovements;
    Snak snak;

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
        buttonanimation = GameObject.Find("BossemDollar").GetComponent<ButtonAnimation>();
        playModeMovements = GameObject.Find("Sheeple").GetComponent<PlayModeMovements>();
        snak = GameObject.Find("SnakManager").GetComponent<Snak>();

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
            // givesnack.SetActive(false);
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
            snak.SpawnSnak();
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
    public void BossemAddReward(int amount)
    {
        initialCoins += amount;
        StartCoroutine(ChangeColorOfTextToRed());
        StartCoroutine(ChangeColorOfTextToNormal());
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
    
    
    private IEnumerator ChangeColorOfTextToRed()
    {
        bossemtext.color = Color.red;
        yield return new WaitForSeconds(0);
        
    }
    private IEnumerator ChangeColorOfTextToNormal()
    {
        yield return new WaitForSeconds(6);
        bossemtext.color = Color.white;
        
    }

   //Validation Checks
    public void AllValidation(int coins) 
    {
          if(initialCoins <= 0)
          {
            StartCoroutine(CheckAllValidation());
            initialCoins = 0;
            return;
          }
          else if(initialCoins >= coins)
          {
              StartCoroutine(ProceedToNextScene());
          }
    }

    private IEnumerator CheckAllValidation()
    {
        yield return new WaitForSeconds(9);
        sheepleConversation.BuySnakRequest();
        buttonanimation.enabled = true;
    }

    private IEnumerator ProceedToNextScene()
    {
        yield return new WaitForSeconds(11);
        // proceedButton.SetActive(true);
        SceneManager.LoadScene("Proceed To Jump");
              //Load next scene
    }

    public void ValidateWalk(int coins) 
    {
          if(initialCoins <= 0)
          {
            playModeMovements.StopAllAnimation();
            sheepleConversation.BuySnakRequest();
            buttonanimation.enabled = true;
            initialCoins = 0;
            return;
          }
          else if(initialCoins >= coins)
          {
              playModeMovements.Walk();
          }
    }

    public void ValidateJump(int coins) 
    {
          if(initialCoins <= 0)
          {
            playModeMovements.StopAllAnimation();
            sheepleConversation.BuySnakRequest();
            buttonanimation.enabled = true;
            initialCoins = 0;
            return;
          }
          else if(initialCoins >= coins)
          {
              playModeMovements.Jump();
          }
    }

    public void ValidateRun(int coins) 
    {
          if(initialCoins <= 0)
          {
            playModeMovements.StopAllAnimation();
            sheepleConversation.BuySnakRequest();
            buttonanimation.enabled = true;
            initialCoins = 0;
            return;
          }
          else if(initialCoins >= coins)
          {
              playModeMovements.Run();
          }
    }

    public void ValidateKick(int coins) 
    {
          if(initialCoins <= 0)
          {
            playModeMovements.StopAllAnimation();
            sheepleConversation.BuySnakRequest();
            buttonanimation.enabled = true;
            initialCoins = 0;
            return;
          }
          else if(initialCoins >= coins)
          {
              playModeMovements.Kick();
          }
    }

    public void ValidateDance(int coins) 
    {
          if(initialCoins <= 0)
          {
            playModeMovements.StopAllAnimation();
            sheepleConversation.BuySnakRequest();
            buttonanimation.enabled = true;
            initialCoins = 0;
            return;
          }
          else if(initialCoins >= coins)
          {
              playModeMovements.Dance();
          }
    }

    public void ValidateGreet(int coins) 
    {
          if(initialCoins <= 0)
          {
            playModeMovements.StopAllAnimation();
            sheepleConversation.BuySnakRequest();
            buttonanimation.enabled = true;
            initialCoins = 0;
            return;
          }
          else if(initialCoins >= coins)
          {
              playModeMovements.Greet();
          }
    }
    
}