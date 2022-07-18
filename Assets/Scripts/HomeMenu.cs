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
    }
    
    public void PlayableDemo()
    {
        circleTransition.OpenBlankScreen();
        StartCoroutine(DelayedPlayableChange()); 
    }

    public void LoadTraining()
    {
        circleTransition.OpenBlankScreen();
        StartCoroutine(DelayedTrainingChange());   
    }

    public void LoadAdventure()
    {
        circleTransition.OpenBlankScreen();
        StartCoroutine(DelayedAdventureChange());
    }

    IEnumerator DelayedPlayableChange()
    {
       yield return new WaitForSecondsRealtime(1);
       SceneManager.LoadScene("PlayableDemo");
    }

    IEnumerator DelayedTrainingChange()
    {
       yield return new WaitForSecondsRealtime(1);
       SceneManager.LoadScene("Training");
    }

    IEnumerator DelayedAdventureChange()
    {
       yield return new WaitForSecondsRealtime(1);
       SceneManager.LoadScene("TransitionAdventureScene");
    }
}
