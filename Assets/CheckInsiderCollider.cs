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
        
    }
    
    private void CheckForDancingOnBox()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0f);
        Collider playerCollider;

        foreach(Collider hitCollider in hitColliders)
        {
            
            if(hitCollider.gameObject.tag == "Player"){
                isInBox = true;
                playerCollider = hitCollider;
                bool isDancing = AdventureMovement.instance.isDancing;
                
                if (isInBox && isDancing){
                    AdventureMovement.instance.TriggerBox();
                    StartCoroutine(PlayAnimation(1));
                    
                    
                }
                break;
            }
            
        }
        
    }
    private IEnumerator TemporarilyDealay(float duration) {
        yield return new WaitForSeconds(duration);
        setEgg.SetActive(true);
    }
    private IEnumerator PlayAnimation(float duration){
        yield return new WaitForSeconds(duration);
        TreasureBox.instance.OpenBoxAnim();
    }
}
