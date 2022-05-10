using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(VoiceController))]
public class VoiceTest : MonoBehaviour {

    public Text uiText;

    VoiceController voiceController;
    public PlayerController playerController;

    public void GetSpeech() {
        voiceController.GetSpeech();
    }

    void Start() {
        voiceController = GetComponent<VoiceController>();
       
    }
    void Updte()
    {
        
    }

    void OnEnable() {
        VoiceController.resultRecieved += OnVoiceResult;
    }

    void OnDisable() {
        VoiceController.resultRecieved -= OnVoiceResult;
    }

    void OnVoiceResult(string text) {
        uiText.text = text;
        if(uiText.text == "Up" || uiText.text == "up")
        {

            playerController.Up();
        }

            
        else if(uiText.text == "Left" || uiText.text == "left")
        {

            playerController.Left();
        }

        else if(uiText.text == "Down" || uiText.text == "down")
        {

            playerController.Down();
        }

        else if(uiText.text == "Right" || uiText.text == "right")

        {

            playerController.Right();
        }



    }
}
