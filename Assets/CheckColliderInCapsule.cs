using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColliderInCapsule : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("capsule_col"))
        {
            bool isKicking = AdventureMovement.instance.isKicking;
            if(isKicking)
            {
                Destroy(gameObject);


           }
           

        
        }
        
        
    }
}

