using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementBetter : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10;
    [SerializeField] float jumpSpeed = 10;
    [SerializeField] float wallJumpDuration = 10;
    [SerializeField] Vector2 wallJumpSpeed;
    Vector2 moveInput;
    Rigidbody2D myRigidbody2D;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    Animator myAnimator;
    int groundLayer = 0;
    bool isStunned;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();    
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        groundLayer = LayerMask.GetMask("Ground");
    }

    void Run()
    {
        Vector2 playerVelocity =  new Vector2 (moveInput.x * movementSpeed, myRigidbody2D.linearVelocity.y);
        myRigidbody2D.linearVelocity = playerVelocity;

        bool playerHasHorizantalSpeed = Mathf.Abs(myRigidbody2D.linearVelocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("IsRunning",playerHasHorizantalSpeed);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void FlipSprite()
    {
        bool playerHasHorizantalSpeed = Mathf.Abs(myRigidbody2D.linearVelocity.x) > Mathf.Epsilon;

        if (playerHasHorizantalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody2D.linearVelocity.x), 1f);
        }
    }

    void OnJump(InputValue value)
    {
        if(!value.isPressed || isStunned) {return;}
        if(myFeetCollider.IsTouchingLayers(groundLayer)){myRigidbody2D.linearVelocity += new Vector2(0, jumpSpeed);}
        else if (myBodyCollider.IsTouchingLayers(groundLayer) && Math.Abs(moveInput.x) > 0){WallJump();}
    }

    private void WallJump()
    {
        myRigidbody2D.linearVelocity = new Vector2(wallJumpSpeed.x * -transform.localScale.x, wallJumpSpeed.y);
        StartCoroutine(Stun(wallJumpDuration));
    }

    IEnumerator Stun(float duration)
    {
        isStunned = true;
        yield return new WaitForSeconds(duration);
        isStunned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isStunned) {return;}
        Run();
        FlipSprite();
    }
}
