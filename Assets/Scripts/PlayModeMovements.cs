using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayModeMovements : MonoBehaviour
{
    public static PlayModeMovements instance;

    Animator anim;
    Vector3 pos;
    Rigidbody rb;

    public AudioSource audioSource;
    public float delay = 4f;

    public float jumpVelocity;
    public float jumpDelay = 1f;

    private bool canjump;
	private bool isjumpingUp;
    private float startCount;

    private float speed = 0.3f;

    public float moveDelay = 7f;

    private bool canMove;
	private bool isMovingAround;
    public bool hasbeenclicked;
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

        audioSource.PlayDelayed(delay);
       // pos = new Vector3(transform.position.x, transform.position.y, target.transform.position.z);
        canjump = true;
		startCount = jumpDelay;

    }

    // Update is called once per frame
    void Update()
    {
        
        pos = new Vector3(0, 0, speed * Time.deltaTime);  // move forward
        
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

        
        if (isMovingAround && countDown > 0)
           {
			countDown -= Time.deltaTime;
           }
		else{
			canMove = true;
			isMovingAround = false;
			countDown = moveDelay;
		}

        if (isjumpingUp && startCount > 0)
        {
			startCount -= Time.deltaTime;
        }
		else
        {
			canjump = true;
			isjumpingUp = false;
			startCount = jumpDelay;
		}

    }

    public void Walk()
    {
        if(canMove) {
			canMove = false;
			isMovingAround = true;
            transform.Rotate(0f, 90f, 0f);
            isMoving = true;
        }
        anim.SetBool("isJumping", false);
        isMovingRunning = false;
        anim.SetBool("isKicking", false);
        anim.SetBool("isGreeting", false);
        anim.SetBool("isDancing", false);
    }

    public void StopAllAnimation()
    {
        isMoving = false;
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
            transform.Rotate(0f, 85f, 0f);
            isMovingRunning = true;
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
        // hasbeenclicked = true;
    }

    public void Kick()
    {
        anim.Play("kick", -1, 0f);
        isMovingRunning = false;
        isMoving = false;
        // hasbeenclicked = true;
    }
    public void Dance()
    {
        anim.Play("dance", -1, 0f);
        isMovingRunning = false;
        isMoving = false;
        // hasbeenclicked = true;
    }
    public void Greet()
    {
        // anim.SetBool("isGreeting", true);
        anim.Play("hello", -1, 0f);
        isMovingRunning = false;
        isMoving = false;
        // hasbeenclicked = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("treasure_box"))
        {
           transform.Rotate(0f, 180f, 0f);
           StartCoroutine(StopAnimation());
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("snak"))
        {
             Destroy(collision.gameObject);
             Debug.Log("It worked");
            // this.gameObject.SetActive(false);
        }
    }

    
   
    private IEnumerator StopAnimation()
    {
        yield return new WaitForSeconds(4);
        isMoving = false;
        isMovingRunning = false;
        transform.Rotate(0f, 90f, 0f);
    }
    
}
