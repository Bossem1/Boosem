using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(VoiceController))]
public class VoiceTest : MonoBehaviour
{

    public Text uiText;

    VoiceController voiceController;
    public PlayerAnimation  playerController;

    public void GetSpeech()
    {
        voiceController.GetSpeech();
    }

    void Start()
    {
        voiceController = GetComponent<VoiceController>();

    }
    void Update()
    {

    }

    void OnEnable()
    {
        VoiceController.resultRecieved += OnVoiceResult;
    }

    void OnDisable()
    {
        VoiceController.resultRecieved -= OnVoiceResult;
    }

    void OnVoiceResult(string text)
    {
        uiText.text = text;
        if (uiText.text == "Jump" || uiText.text == "jump")
        {

            playerController.Jump();
        }


        else if (uiText.text == "Walk" || uiText.text == "walk")
        {

            playerController.Walk();
        }

        else if (uiText.text == "Run" || uiText.text == "run")
        {

            playerController.Run();
        }
        else if (uiText.text == "Kick" || uiText.text == "kick")
        {

            playerController.Kick();
        }

        else if (uiText.text == "Stop" || uiText.text == "stop")

        {

            playerController.Stop();
        }




    }
}
