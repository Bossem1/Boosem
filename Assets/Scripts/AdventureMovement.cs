using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureMovement : MonoBehaviour
{
    Animator anim;
    Vector3 pos;
    Rigidbody rb;
    Animator m_Animator;
    //Use to output current speed of the state to the screen
    float m_CurrentSpeed;

    public float speed;

    public AudioSource audioSource;
    public float delay = 4f;

    public float jumpVelocity;
    public float jumpDelay = 1f;

    private bool canMove;
	private bool isMovingAround;
    private float moveDelay = 5f;

    private bool canjump;
	private bool isjumpingUp;
    private float jumpSpeed = 1f;
	private float countDown;

    private float count;

    private bool OnJumpFailed = false;

    float vertical;
    bool isMoving = false;
    bool isMovingRunning = false;
    public bool isDancing = false;
    public bool isKicking = false;
    public bool FinishedDancing = false;
    public GameObject weaponBox;
    public GameObject showEgg;
    public GameObject disabbleMyCube;
    public static AdventureMovement instance;
    //public GameObject target;
    // Start is called before the first frame update
    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        FinishedDancing = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        canjump = true;
		countDown = jumpDelay;
        m_Animator = gameObject.GetComponent<Animator>();
        //The current speed of the first Animator state
        m_CurrentSpeed = m_Animator.GetCurrentAnimatorStateInfo(0).speed;
       // pos = new Vector3(transform.position.x, transform.position.y, target.transform.position.z);

       audioSource.PlayDelayed(delay);

    //    InvokeRepeating("RepeatAction", 10.0f, 15.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.up * jumpVelocity;
        }
        
        if(Input.GetKey("up")){
            rb.velocity = Vector3.forward * speed;
            isDancing = false;
        }
        if(Input.GetKey("down"))
        {
            rb.velocity = Vector3.back * speed;
            isDancing = false;
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

         if (isMovingAround && count > 0)
           {
			count -= Time.deltaTime;
           }
		else{
			canMove = true;
			isMovingAround = false;
			count = moveDelay;
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

         if (OnJumpFailed == true)
        {
            transform.Translate(pos);
            transform.Rotate(0,Time.deltaTime * 45, 0); // turn a little
            anim.SetBool("isWalking", true);
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
        isKicking = false;
        isDancing = false;
    }

    public void Run()
    {
         isMovingRunning = true;
         isMoving = false;
        //  transform.Rotate(0f, 90f, 0f);
         anim.SetBool("isJumping", false);
         anim.SetBool("isKicking", false);
         anim.SetBool("isGreeting", false);
         anim.SetBool("isDancing", false);
         isKicking = false;
         isDancing = false;
    }

    // public void Run()
    // {
    //      if(canMove) {
	// 		canMove = false;
	// 		isMovingAround = true;
    //         transform.Rotate(0f, 90f, 0f);
    //         isMovingRunning = true;
    //      }
    //      isMoving = false;
    //      anim.SetBool("isJumping", false);
    //      anim.SetBool("isKicking", false);
    //      anim.SetBool("isGreeting", false);
    //      anim.SetBool("isDancing", false);
    // }

    public void HighJump()
    {
        if(canjump) {
			canjump = false;
			isjumpingUp = true;
            anim.Play("jump", -1, 0f);
            rb.velocity = (Vector3.up * jumpVelocity) + (Vector3.left * jumpSpeed);
        }
        isMovingRunning = false;
        isMoving = false;
        isKicking = false;
        isDancing = false;
    }

    public void Jump()
    {
        anim.Play("jump", -1, 0f);
        isMovingRunning = false;
        isMoving = false;
        isKicking = false;
        isDancing = false;
    }

    public void Kick()
    {
        anim.Play("kick", -1, 0f);
        isMovingRunning = false;
        isMoving = false;
        isDancing = false;
        isKicking = true;
    }
    public void Dance()
    {
        anim.Play("dance", -1, 0f);
        isMovingRunning = false;
        isMoving = false;
        isKicking = false;
        isDancing = true;

    }

    public void Greet()
    {
        // anim.SetBool("isGreeting", true);
        anim.Play("hello", -1, 0f);
        isMovingRunning = false;
        isMoving = false;
        // hasbeenclicked = true;
    }

    public void TriggerBox()
    {
        
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("dance"))
        {
           
            if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                anim.Play("jump", -1, 0f);
                Debug.Log("It jumped");


            }
                
                
        }
            
            
            // Avoid any reload.
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("treasure_box"))
        {
        //    transform.Rotate(0f, -90f, 0f);
           
              StartCoroutine(StopMovement());
        //    isMovingRunning = false;
        }
        else
        {
            // StartCoroutine(JumpFailPenalty());
            // transform.Rotate(0f, -90f, 0f);
            // StartCoroutine(StopMovement());
        }
        /*if(collision.gameObject.CompareTag("MyCube"))
        {
           TriggerBox();

        //    isMovingRunning = false;
        }*/              
        if(collision.gameObject.CompareTag("Jump_failed"))
        {
             StartCoroutine(JumpFailPenalty());
           transform.Rotate(0f, 180f, 0f);
           StartCoroutine(StopMovement());
        }
        
        
    }

    public void RepeatAction()
    {
        StartCoroutine(JumpFailPenalty());
    }

    private IEnumerator JumpFailPenalty()
    {
        yield return new WaitForSeconds(4);
        OnJumpFailed = true;
        yield return new WaitForSeconds(8);
        OnJumpFailed = false;
        Kick();
        isMovingRunning = false;
        transform.Rotate(0f, 180f, 0f);
    }

    private IEnumerator StopMovement()
    {
        yield return new WaitForSeconds(2);
        isMoving = false;
        isMovingRunning = false;
        // transform.Rotate(0f, 90f, 0f);
    }
}
