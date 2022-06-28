using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    Vector3 pos;
    Rigidbody rb;

    private float speed = 0.3f;

    public float moveDelay = 9f;

    private bool canMove;
	private bool isMovingAround;
	private float countDown;
   
    float vertical;
    bool isMoving = false;
    bool isMovingRunning = false;
    //public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
       // pos = new Vector3(transform.position.x, transform.position.y, target.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        pos = new Vector3(0, 0, speed * Time.deltaTime);  // move forward
        
        if (isMoving == true)
        {
            transform.Translate(pos);
            transform.Rotate(0,Time.deltaTime * 45, 0); // turn a little
            anim.SetBool("isWalking", true);
        }
        else 
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("Idle", true);
        }

        if (isMovingRunning == true)
        {
            transform.Translate(pos);
            transform.Rotate(0,Time.deltaTime* 45, 0);
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("Idle", true);
        }

        
        if (isMovingAround && countDown > 0)
           {
			countDown -= Time.deltaTime;
           }
		else{
			canMove = true;
			isMovingAround = false;
			countDown = moveDelay;
		}


    }

    public void Walk()
    {
        if(canMove) {
			canMove = false;
			isMovingAround = true;
            transform.Rotate(0f, 90f, 0f);
            isMoving = true;
            StartCoroutine(StopAnimation());
        }
        anim.SetBool("isJumping", false);
        isMovingRunning = false;
        anim.SetBool("isKicking", false);
        anim.SetBool("isGreeting", false);
        anim.SetBool("isDancing", false);
    }
    public void Run()
    {
         if(canMove) {
			canMove = false;
			isMovingAround = true;
            transform.Rotate(0f, 90f, 0f);
            isMovingRunning = true;
            StartCoroutine(StopAnimation());
        }
         isMoving = false;
         anim.SetBool("isJumping", false);
         anim.SetBool("isKicking", false);
         anim.SetBool("isGreeting", false);
         anim.SetBool("isDancing", false);
    }
    public void Jump()
    {
        anim.Play("jump", -1, 0f);
        isMovingRunning = false;
        isMoving = false;
    }
    public void Kick()
    {
        anim.Play("kick", -1, 0f);
        isMovingRunning = false;
        isMoving = false;
    }
    public void Dance()
    {
        anim.Play("dance", -1, 0f);
        isMovingRunning = false;
        isMoving = false;
    }
    public void Greet()
    {
        // anim.SetBool("isGreeting", true);
        anim.Play("hello", -1, 0f);
        isMovingRunning = false;
        isMoving = false;
    }
   
    private IEnumerator StopAnimation()
    {
        yield return new WaitForSeconds(8);
        isMoving = false;
        isMovingRunning = false;
        transform.Rotate(0f, -90f, 0f);
    }
    
}
