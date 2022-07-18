using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Transition : MonoBehaviour
{
    public Animator animator;
    public float transitionDelayTime = 50.0f;

    void Awake()
    {
        animator = GameObject.Find("Transition").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        LoadLevel();
        
    }

    public void LoadLevel()
    {
        StartCoroutine(DelayLoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator DelayLoadLevel(int index)
    {
        animator.SetTrigger("TriggerTransition");
        yield return new WaitForSeconds(transitionDelayTime);
        SceneManager.LoadScene(index);
    }
}