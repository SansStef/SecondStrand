using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D body;
    Animator animator;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float verticalMovementSpeed = 20.0f;
    public float horizontalMovementSpeed = 10.0f;

    bool isClimbing = false;
    bool isRepairing = false;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void UpdateAnimations()
    {
        animator.SetBool("isClimbing", isClimbing);
        animator.SetBool("isRepairing", isRepairing);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            isRepairing = true;
        }
        else{
            isRepairing = false;
        }

        // Gives a value between -1 and 1
        if(isRepairing){
            isClimbing = false;
            horizontal = 0;
            vertical = 0;
        }
        else{
            horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
            vertical = Input.GetAxisRaw("Vertical"); // -1 is down

            if(horizontal != 0 && vertical != 0){
                isClimbing = true;
            }
            else{
                isClimbing = false;
            }
        }
        

        UpdateAnimations();
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * horizontalMovementSpeed, vertical * verticalMovementSpeed);
    }
}
