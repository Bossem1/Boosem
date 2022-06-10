using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SheepleConversation : MonoBehaviour
{
    public AudioObject clipToPlay;
    public GameObject helloButton;
    public GameObject snakButton;
    public TextMeshProUGUI snakText;

    public void SheepleStatement()
    {
          Vocals.instance.Say(clipToPlay);
    }

    public void SheepleRequest(){
        StartCoroutine(PlayAudioSound());
    }

    private IEnumerator PlayAudioSound()
    {
        yield return new WaitForSeconds(2);
        Vocals.instance.Say(clipToPlay);
        // audioSource.PlayOneShot(audioClip);
        helloButton.gameObject.SetActive(false);
        snakButton.gameObject.SetActive(true);
    }
}
