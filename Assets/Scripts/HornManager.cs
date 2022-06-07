using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip audioClip;
   
    // Start is called before the first frame update
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HornSound(){
        audioSource.Play(); 
        StartCoroutine(PlayAfterSeconds());
    }

    private IEnumerator PlayAfterSeconds()
    {
        yield return new WaitForSeconds(3);
        audioSource.PlayOneShot(audioClip);
    }
}
