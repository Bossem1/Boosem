using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatSnak : MonoBehaviour
{
    public GameObject player;
    
    Transform target;
 
     // Start is called before the first frame update
     void Start()
     {
         player = GameObject.FindWithTag("Mouth");
         target = player.transform;
     }
 
     // Update is called once per frame
     void Update()
     {
         transform.position = Vector3.MoveTowards(transform.position, target.position, 0.45f);
     }

}
