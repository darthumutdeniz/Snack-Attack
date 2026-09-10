using System;
using UnityEngine;

public class WalkerEnemy : MonoBehaviour
{
	[SerializeField] String weaponTagName = "Weapon";
	[SerializeField] BoxCollider2D sideCollider;
	[SerializeField] BoxCollider2D ledgeCollider;
	[SerializeField] Rigidbody2D rigidbody;
	[SerializeField] Transform transformee;
	[SerializeField] float movementSpeed = 10;
	int groundLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		rigidbody.linearVelocityX = movementSpeed;
        groundLayer = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        if ((!ledgeCollider.IsTouchingLayers(groundLayer)) || sideCollider.IsTouchingLayers(groundLayer))
		{
			GoX(-Mathf.Sign(transformee.localScale.x) * movementSpeed);
		}
		else
		{
			GoX(Mathf.Sign(transformee.localScale.x) * movementSpeed);
		}
    }

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == weaponTagName)
		{
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy") GoX(-Mathf.Sign(transformee.localScale.x) * movementSpeed);
		if (collision.gameObject.tag == "Player") collision.gameObject.GetComponent<Health>().TakeDamage(20);
	}

	void GoX(float velocityX)
	{
		rigidbody.linearVelocityX = velocityX;
		if (rigidbody.linearVelocityX != 0) transformee.localScale = new Vector3(Mathf.Abs(transformee.localScale.x) * Mathf.Sign(rigidbody.linearVelocityX), transformee.localScale.y, transformee.localScale.z);
	}
}
