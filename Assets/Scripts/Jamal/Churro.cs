using UnityEngine;

public class Churro : MonoBehaviour
{
	float leftpos;
	float rightpos;
	[SerializeField] Rigidbody2D rigidbody;
	[SerializeField] Transform transformee;
	[SerializeField] float offsetDistance = 15;
	[SerializeField] float movementSpeed = 5;
	[SerializeField] float damage = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftpos = transformee.localPosition.x - offsetDistance;
		rightpos = transformee.localPosition.x + offsetDistance;
		rigidbody.linearVelocityX = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (transformee.localPosition.x > rightpos) rigidbody.linearVelocityX = -movementSpeed;
		if (transformee.localPosition.x < leftpos) rigidbody.linearVelocityX = movementSpeed;
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player") collision.gameObject.GetComponent<Health>().TakeDamage(damage);
	}
}
