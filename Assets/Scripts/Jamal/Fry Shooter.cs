using System;
using System.Collections;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Lumin;

public class FryShooter : MonoBehaviour
{
	[SerializeField] GameObject player;
	[SerializeField] GameObject projectile;
	[SerializeField] Transform transformee;
	[SerializeField] float projectileSpeed = 10;
	[SerializeField] float projectileSpinTime = 1;
	[SerializeField] int projectileSpinSample = 60;
	Transform playerTransformee;
	Vector2 velocity;
	float degrees;
	GameObject placeholder;
	Transform phTransformee;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransformee = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public IEnumerator Shoot(Vector2 position)
	{
		velocity = new Vector2(playerTransformee.localPosition.x - position.x, playerTransformee.localPosition.y - position.y);
		velocity.Scale(new Vector2(projectileSpeed / velocity.magnitude, projectileSpeed / velocity.magnitude));
		degrees = Mathf.Rad2Deg * Mathf.Atan2(velocity.y, velocity.x);
		placeholder = Instantiate(projectile);
		placeholder.SetActive(true);
		phTransformee = placeholder.GetComponent<Transform>();
		phTransformee.position = new Vector3(position.x, position.y);
		phTransformee.rotation = new Quaternion(phTransformee.rotation.x, phTransformee.rotation.y, degrees / 180, phTransformee.rotation.w);
		float spin = Mathf.Abs(360 - (phTransformee.rotation.z * 180));
		spin = spin / projectileSpinSample;
		for (int i = 0; i < projectileSpinSample; i++)
		{
			if (phTransformee == null) yield break;
			phTransformee.rotation = new Quaternion(phTransformee.rotation.x, phTransformee.rotation.y, phTransformee.rotation.z + (spin / 180), phTransformee.rotation.w);
			yield return new WaitForSeconds(projectileSpinTime / projectileSpinSample);
			if (phTransformee == null) yield break;
		}

		placeholder.GetComponent<Rigidbody2D>().linearVelocity = velocity;
	}
}
