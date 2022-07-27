using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColliderCapsule : MonoBehaviour
{
    public bool isOnGround = false;
    public GameObject setEgg;
    public static CheckColliderCapsule instance;
    

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
                isOnGround = true;
                playerCollider = hitCollider;
                bool isKicking = AdventureMovement.instance.isKicking;
                
                if (isOnGround && isKicking){
                    AdventureMovement.instance.TriggerBox();
                    Destroy(setEgg);
                    Debug.Log("Destroyed egg");
                }
                break;
            }
            
        }
        
    }
    
}
