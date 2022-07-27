using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashObject : MonoBehaviour
{
    public int Countdown = 8;
    public float timeVisible    = 0.3f;
    public float timeInvisible  = 0.3f;
    public float blinkFor       = 2.0f;
    public bool startState      = true;
    public bool endState        = true;
 
    void Start()
    {
        StartCoroutine(blink());
    }
 
    IEnumerator blink()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.enabled = startState;
 
        yield return new WaitForSeconds(Countdown);
       
        var whenAreWeDone = Time.time + blinkFor;
 
        while (Time.time < whenAreWeDone)
        {
                renderer.enabled = !startState;
                yield return new WaitForSeconds(timeInvisible);
                renderer.enabled = startState;
                yield return new WaitForSeconds(timeVisible);
        }
        renderer.enabled = endState;
 
       
    }
 
}
