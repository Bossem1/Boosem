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
        StartCoroutine(DelayedSceneChange()); 
    }

    public void PlayGame()
    {
        circleTransition.OpenBlankScreen();
        StartCoroutine(DelayedSceneChange1());   
    }

    public void LoadHomeMenu()
    {
        SceneManager.LoadScene("Home Menu");
    }

    IEnumerator DelayedSceneChange()
    {
       yield return new WaitForSecondsRealtime(1);
       SceneManager.LoadScene("Playable Demo");
    }

    IEnumerator DelayedSceneChange1()
    {
       yield return new WaitForSecondsRealtime(1);
       SceneManager.LoadScene("Training");
    }
}
