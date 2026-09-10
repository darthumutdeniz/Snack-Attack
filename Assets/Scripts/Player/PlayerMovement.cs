using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] float wallJumpWait = 0.35f;
	bool wallJumping = false;
	[SerializeField] float movementSpeed = 10;
	[SerializeField] float jumpSpeed = 10;
	[SerializeField] int jumpsOnAirMax = 0;
	[SerializeField] float airSpeedMax = 10;
	int jumpsOnAirLeft;
	[SerializeField] float wallJumpSpeedY = 9;
	[SerializeField] float wallJumpSpeedX = 17;
	[SerializeField] float onAirDeaccalerationForce = 10;
	[SerializeField] float onAirAccalerationForce= 50;
	[SerializeField] float wallJumpOffset = 0.01f;
	Animator myAnimator;
	Rigidbody2D playerBody;
	BoxCollider2D groundCollider;
	CapsuleCollider2D wallCollider;
	int groundLayer;
	Vector2 joystick = new Vector2(0, 0);

	IEnumerator WaitForWallJump()
	{
		wallJumping = true;
		yield return new WaitForSeconds(wallJumpWait);
		wallJumping = false;
	}

	public void IncreaseSpeed(int increaseCount)
	{
		movementSpeed += increaseCount* movementSpeed*0.1f;
		airSpeedMax +=  increaseCount* airSpeedMax*0.1f;
	}

	//sets the velocity and modifies the scale
	void GoX(float velocityX)
	{
		playerBody.linearVelocityX = velocityX;
		if (Mathf.Abs(playerBody.linearVelocityX) > Mathf.Epsilon) transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * Mathf.Sign(playerBody.linearVelocityX), transform.localScale.y, transform.localScale.z);
	}

	//Adds force and modifies the scale
	void PushX(float force)
	{
		playerBody.AddForceX(force);
		if (Mathf.Abs(playerBody.linearVelocityX) > Mathf.Epsilon) transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * Mathf.Sign(playerBody.linearVelocityX), transform.localScale.y, transform.localScale.z);
	}

	void jumper()
	{
		playerBody.linearVelocityY = jumpSpeed;
	}

	void wallJumper()
	{
		StartCoroutine(WaitForWallJump());
		playerBody.position = new Vector2(playerBody.position.x - (wallJumpOffset * Mathf.Sign(transform.localScale.x)), playerBody.position.y);
		GoX(wallJumpSpeedX * -Mathf.Sign(transform.localScale.x));
		playerBody.linearVelocityY = wallJumpSpeedY;
	}

	void Move()
	{
		myAnimator.SetBool("IsRunning", Mathf.Abs(joystick.x) > 0);
		if (Mathf.Abs(joystick.x) > Mathf.Epsilon)
		{
			if ((!groundCollider.IsTouchingLayers(groundLayer)) && (!wallCollider.IsTouchingLayers(groundLayer)))
			{
				if ((playerBody.linearVelocityX > airSpeedMax) && (joystick.x > 0))
				{
					GoX(airSpeedMax);
					return;
				}
				else if ((playerBody.linearVelocityX < -airSpeedMax) && (joystick.x < 0))
				{
					GoX(-airSpeedMax);
					return;
				}
				PushX(onAirAccalerationForce * Mathf.Sign(joystick.x));
				return;
			}
			GoX(movementSpeed * Mathf.Sign(joystick.x));
			return;
		}
		else if (groundCollider.IsTouchingLayers(groundLayer))
		{
			GoX(0);
			return;
		}
		else if (!wallCollider.IsTouchingLayers(groundLayer))
		{
			if (playerBody.linearVelocityX > 2)
			{
				PushX(-onAirDeaccalerationForce);
				return;
			}
				else if (playerBody.linearVelocityX < -2)
			{
				PushX(onAirDeaccalerationForce);
				return;
			}
				GoX(0);
			return;
		}		
	}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		myAnimator = GetComponent<Animator>();
		playerBody = GetComponent<Rigidbody2D>();
		groundCollider = GetComponent<BoxCollider2D>();
		wallCollider = GetComponent<CapsuleCollider2D>();
		jumpsOnAirLeft = jumpsOnAirMax;
		groundLayer = LayerMask.GetMask("Ground");

    }

    // Update is called once per frame
    void Update()
    {
		
		if (wallJumping)
		{
			return;
		}
		Move();
    }

	public void OnMove(InputValue value)
	{
		joystick = value.Get<Vector2>();
	}

	public void OnJump(InputValue space)
	{
		if (space.isPressed)
		{
			if (groundCollider.IsTouchingLayers(groundLayer))
			{
				jumpsOnAirLeft = jumpsOnAirMax;
				jumper();
				return;
			}
			if (wallCollider.IsTouchingLayers(groundLayer))
			{
				wallJumper();
				return;
			}
			if (jumpsOnAirLeft > 0)
			{
				jumpsOnAirLeft--;
				jumper();
				return;
			}
		}
	}
	
}