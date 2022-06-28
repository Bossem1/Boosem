using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SheepleConversation : MonoBehaviour
{
    public AudioObject snakRequestClip;
    public AudioObject thankYouClip;
    public AudioObject buySnakClip;
    public GameObject helloButton;
    public GameObject snakButton;
    public TextMeshProUGUI snakText;

    public void SheepleStatement()
    {
          Vocals.instance.Say(snakRequestClip);
    }
    
    public void ThankYou()
    {
        StartCoroutine(PlayAudio());
    }

    public void BuySnakRequest()
    {
        Vocals.instance.Say(buySnakClip);
    }

    private IEnumerator PlayAudio()
    {
        yield return new WaitForSeconds(2);
        Vocals.instance.Say(thankYouClip);
    }
    public void SheepleRequest(){
        StartCoroutine(PlayAudioSound());
    }

    private IEnumerator PlayAudioSound()
    {
        yield return new WaitForSeconds(2);
        Vocals.instance.Say(snakRequestClip);
        // audioSource.PlayOneShot(audioClip);
        helloButton.gameObject.SetActive(false);
        snakButton.gameObject.SetActive(true);
    }
}
