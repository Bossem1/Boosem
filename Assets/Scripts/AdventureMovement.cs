using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureMovement : MonoBehaviour
{
    Animator anim;
    Vector3 pos;
    Rigidbody rb;

    public float speed;

    public float jumpVelocity;
    public float jumpDelay = 1f;

    private bool canjump;
	private bool isjumpingUp;
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
        canjump = true;
		countDown = jumpDelay;
       // pos = new Vector3(transform.position.x, transform.position.y, target.transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.up * jumpVelocity;
        }
        
        vertical = Input.GetAxis("Vertical");
        pos = new Vector3(0, 0, speed * Time.deltaTime);
        if (isMoving == true)
        {
            transform.Translate(pos);
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
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("Idle", true);
        }

        if (isjumpingUp && countDown > 0)
           {
			countDown -= Time.deltaTime;
           }
		else{
			canjump = true;
			isjumpingUp = false;
			countDown = jumpDelay;
		}
    }
    private void FixedUpdate()
    {
        
      

    }
    public void Walk()
    {
        isMoving = true;
        anim.SetBool("isJumping", false);
        isMovingRunning = false;
        anim.SetBool("isKicking", false);
        anim.SetBool("isGreeting", false);
        anim.SetBool("isDancing", false);
    }
    public void Run()
    {
         isMovingRunning = true;
         isMoving = false;
         transform.Rotate(0f, 90f, 0f);
         anim.SetBool("isJumping", false);
         anim.SetBool("isKicking", false);
         anim.SetBool("isGreeting", false);
         anim.SetBool("isDancing", false);
         StartCoroutine(StopAnimation());
    }
    public void Jump()
    {
        if(canjump) {
			canjump = false;
			isjumpingUp = true;
            // anim.SetBool("isJumping", true);
            anim.Play("jump", -1, 0f);
            rb.velocity = (Vector3.up * jumpVelocity) + (Vector3.left * speed);
        }
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

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("treasure_box"))
        {
           transform.Rotate(0f, 180f, 0f);
        //    isMovingRunning = false;
        }
    }

    private IEnumerator StopAnimation()
    {
        yield return new WaitForSeconds(6);
        isMoving = false;
        isMovingRunning = false;
        transform.Rotate(0f, 90f, 0f);
    }
}
