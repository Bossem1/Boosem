using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleColiider : MonoBehaviour
{
    public bool isOnGround = false;
    public GameObject setEgg;
    public static CapsuleColiider instance;
    public ParticleSystem explosion;
    public ParticleSystem explosion2;
    

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
            
            if(hitCollider.gameObject.GetComponent<AdventureMovement>()){
                Debug.Log("player on the co now");
                isOnGround = true;
                playerCollider = hitCollider;

                Debug.Log("new egg");
                bool isKicking = AdventureMovement.instance.isKicking;
                
                if (isOnGround && isKicking){
                    
                    explosion.Play();
                    explosion2.Play();
                    Destroy(setEgg,2);
                    Debug.Log("Destroyed egg");
                    BossemDollar.instance.BossemAddReward(19);
                }
                break;
            }
            
        }
        
    }
    
}

