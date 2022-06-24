using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    Vector3 moveVector = Vector3.zero;
    CharacterController characterController;

    public float moveSpeed;
    public float jumpSpeed;
    public float gravity;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal") * moveSpeed;
        moveVector.z = Input.GetAxis("Vertical") * moveSpeed;

        if(characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            moveVector.y = jumpSpeed;
            moveVector.y -= gravity * Time.deltaTime;

            characterController.Move(moveVector * Time.deltaTime);
        }
        
    }
}
