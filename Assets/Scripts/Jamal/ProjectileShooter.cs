using System.Collections;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
	[SerializeField] GameObject projectileObject;
	[SerializeField] Transform transformee;
	Transform playerTransformee;
	GameObject placeholder;
	[SerializeField] GameObject Player;
	[SerializeField] float projectileDamage = 10;
	[SerializeField] float projectileSpeed = 10;
	[SerializeField] float projectileWait = 1;
	Vector2 velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		playerTransformee = Player.GetComponent<Transform>();
		StartCoroutine(Shooting());
    }

    // Update is called once per frame
    void Update()
    {
    }

	IEnumerator Shooting()
	{
		while (true)
		{
			yield return new WaitForSeconds(projectileWait);
			Shoot();
		}
	}

	void Shoot()
	{
		velocity = new Vector2(playerTransformee.localPosition.x - transformee.localPosition.x, playerTransformee.localPosition.y - transformee.localPosition.y);
		velocity.Scale(new Vector2(projectileSpeed / velocity.magnitude, projectileSpeed / velocity.magnitude));
		placeholder = Instantiate(projectileObject);
		placeholder.SetActive(true);
		placeholder.GetComponent<Transform>().localPosition = new Vector3(transformee.localPosition.x, transformee.localPosition.y);
		placeholder.GetComponent<Rigidbody2D>().linearVelocity = velocity;
		placeholder.GetComponent<Projectile>().projectileDamage = projectileDamage;
	}
}
