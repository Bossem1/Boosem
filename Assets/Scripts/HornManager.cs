using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornManager : MonoBehaviour
{
    ButtonAnimation buttonanimation;

    private AudioSource audioSource;
    public AudioClip audioClip;
    public AudioObject clipToPlay;

    [SerializeField] GameObject hello;
   
    public void Awake()
    {
        buttonanimation = hello.GetComponent<ButtonAnimation>();
    }
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
        yield return new WaitForSeconds(6);
        Vocals.instance.Say(clipToPlay);
        yield return new WaitForSeconds(3);
        buttonanimation.enabled = true;
    }

}
