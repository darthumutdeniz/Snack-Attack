using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float projectileDamage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   
    }
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player") collision.gameObject.GetComponent<Health>().TakeDamage(projectileDamage);
		Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Weapon") Destroy(gameObject);
	}
}
