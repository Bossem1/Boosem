using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleColiider : MonoBehaviour
{
    public bool isOnGround = false;
    public GameObject setEgg;
    public static CapsuleColiider instance;
    

    public void Awake()
    {
        instance = this;
    }
    
    private void Update(){
        CheckForKickingEgg();
        
    }
    
    private void CheckForKickingEgg()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0f);
        Collider playerCollider;

        foreach(Collider hitCollider in hitColliders)
        {
            Debug.Log(hitCollider.gameObject.tag);
            if(hitCollider.gameObject.tag == "Player"){
                Debug.Log("player now");
                isOnGround = true;
                playerCollider = hitCollider;
                bool isKicking = AdventureMovement.instance.isKicking;
                
                if (isOnGround && isKicking){
                    AdventureMovement.instance.TriggerBox();
                    Destroy(setEgg,1);
                    Debug.Log("Destroyed egg");
                }
                break;
            }
            
        }
        
    }
    
}

