using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornManager : MonoBehaviour
{
    public AudioSource audiosource;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HornSound(){
        audiosource.Play();
        

    }
}
