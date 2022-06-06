using UnityEngine;

public class TriggerAudioSound : MonoBehaviour
{
     public AudioObject clipToPlay;


     public void SheepleConversation()
     {
          Vocals.instance.Say(clipToPlay);
     }
}
