using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour
{ 
    CircleTransition circleTransition;

    void Awake()
    {
        circleTransition = GameObject.Find("Circle Transition Canvas").GetComponent<CircleTransition>();

        // GameObject.FindObjectsOfType(typeof(Canvas)).Cast<CircleTransition>().FirstOrDefault((c) => c.name == "Circle Transition Canvas");
    }
    
    public void PlayableDemo()
    {
        circleTransition.OpenBlankScreen();
        StartCoroutine(DelayedPlayableChange()); 
    }

    public void PlayGame()
    {
        circleTransition.OpenBlankScreen();
        StartCoroutine(DelayedTrainingChange());   
    }

    public void LoadHomeMenu()
    {
        SceneManager.LoadScene("Home Menu");
    }

    public void LoadAdventure()
    {
        circleTransition.OpenBlankScreen();
        StartCoroutine(DelayedAdventureChange());
    }

    IEnumerator DelayedPlayableChange()
    {
       yield return new WaitForSecondsRealtime(1);
       SceneManager.LoadScene("Playable Demo");
    }

    IEnumerator DelayedTrainingChange()
    {
       yield return new WaitForSecondsRealtime(1);
       SceneManager.LoadScene("Training");
    }

    IEnumerator DelayedAdventureChange()
    {
       yield return new WaitForSecondsRealtime(1);
       SceneManager.LoadScene("Adventures");
    }
}
