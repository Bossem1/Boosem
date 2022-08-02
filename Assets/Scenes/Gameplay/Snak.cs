using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snak : MonoBehaviour
{
    public static Snak instance;

    //Here, we declare variables.
    public GameObject snak;

    public float timeLeft, originalTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //tick down our timer:
        timeLeft -= Time.deltaTime;
        //timeLeft = timeLeft - Time.deltaTime;
        if(timeLeft<=0)
        {
            // SpawnIt();

            //reset the time:
            timeLeft = originalTime;
        }

    }

    public void SpawnSnak()
    {
        Instantiate(snak, transform.position, Quaternion.identity);
    }

 
}
