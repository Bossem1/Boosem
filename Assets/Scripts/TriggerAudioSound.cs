using UnityEngine;

public class TriggerAudioSound : MonoBehaviour
{
     public AudioObject clipToPlay;


     public void SheepleStatement()
     {
          Vocals.instance.Say(clipToPlay);
     }
}
