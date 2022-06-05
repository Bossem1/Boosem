using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource hellosource;
    public GameObject sheeple;
    public GameObject hellobutton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HelloSound(){
        if(sheeple.activeSelf)
            hellosource.Play();
            hellobutton.SetActive(true);
        //sheeple.SetActive(true);

    }
}
