using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInsiderCollider : MonoBehaviour
{
    public bool isInBox = false;
    public static CheckInsiderCollider instance;
    public GameObject setEgg;

    public void Awake()
    {
        instance = this;
    }
    
    private void Update(){
        CheckForDancingOnBox();
        AdventureMovement.instance.TriggerBox();
    }
    
    private void CheckForDancingOnBox()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0f);
        Collider playerCollider;

        foreach(Collider hitCollider in hitColliders)
        {
            Debug.Log(hitCollider.gameObject.tag);
            if(hitCollider.gameObject.tag == "Player"){
                isInBox = true;
                playerCollider = hitCollider;
                bool isDancing = AdventureMovement.instance.isDancing;
                
                if (isInBox && isDancing){
                    AdventureMovement.instance.TriggerBox();
                    Destroy(this.gameObject.transform.parent.gameObject,15f);
                    StartCoroutine(TemporarilyDealay(10));
                    Debug.Log("Destroyed");
                }
                break;
            }
            
        }
        
    }
    private IEnumerator TemporarilyDealay(float duration) {
        yield return new WaitForSeconds(duration);
        setEgg.SetActive(true);
    }
}
