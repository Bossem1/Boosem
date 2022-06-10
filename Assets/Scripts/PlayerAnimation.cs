using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Niantic.ARDK.AR;
using Niantic.ARDK.AR.ARSessionEventArgs;
using Niantic.ARDK.Utilities;

using Niantic.ARDK.AR.Configuration;

using Niantic.ARDK.AR.Mesh;

public class PlayerAnimation : MonoBehaviour
{
    IARSession _ARsession;

    Animator anim;
    public float speed;
    Vector3 pos;
    Rigidbody rb;
   
    float vertical;
    bool isMoving = false;
    bool isMovingRunning = false;
    //public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        ARSessionFactory.SessionInitialized += OnSessionInitialized;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
       // pos = new Vector3(transform.position.x, transform.position.y, target.transform.position.z);
        
    }

    private void OnSessionInitialized(AnyARSessionInitializedArgs args)
    {
        //Now that we've initiated our session, we don't need to do this again so we can remove the callback
        ARSessionFactory.SessionInitialized -= OnSessionInitialized;

        //Here we're saving our AR Session to our '_ARsession' variable, along with any arguments our session contains
        _ARsession = args.Session;
    }

    // Update is called once per frame
    void Update()
    {
     
        vertical = Input.GetAxis("Vertical");
        pos = new Vector3(0, 0, speed * Time.deltaTime);
        if (isMoving == true)
        {
            transform.Translate(pos);
            anim.SetBool("isWalking", true);
        }
        if (isMovingRunning == true)
        {
            transform.Translate(pos);
            anim.SetBool("isRunning", true);
        }


    }
    private void FixedUpdate()
    {
        
      //  rb.velocity = new Vector3(0, rb.velocity.y, vertical * speed * Time.fixedDeltaTime);
      

    }
    public void Walk()
    {
        isMoving = true;
        StartCoroutine(StopWalkAnimation());
    }
    public void Run()
    {
        isMovingRunning = true;
    }
    public void Jump()
    {
        anim.SetBool("isJumping", true);
    }
    public void Kick()
    {
        anim.SetBool("isKicking", true);
    }
    public void Stop()
    {
        transform.Translate(0,0,0);
        isMoving = false;
        isMovingRunning = false;
        anim.SetBool("isJumping", false);
        anim.SetBool("isRunning", false);
        anim.SetBool("isKicking", false);
        anim.SetBool("isWalking", false);
    }

    private IEnumerator StopWalkAnimation()
    {
        yield return new WaitForSeconds(10);
        transform.Rotate(0f, 90f, 0f);
        // transform.rotation = Camera.main.transform.rotation;
        isMoving = false;
        anim.SetBool("isWalking", false);
    }
    
}
