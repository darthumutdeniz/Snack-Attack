using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FrySpawner : MonoBehaviour
{
	[SerializeField] Camera camera;
	[SerializeField] float shootWait = 3;
	[SerializeField] FryShooter shooter;
	[SerializeField] float rangeFromCameraXOutline = 10;
	[SerializeField] float rangeFromCameraYOutline = 10;
	[SerializeField] float rangeFromCameraXIn = 5;
	[SerializeField] float rangeFromCameraYIn = 5;
	bool playerishere = false;
	Vector2 position;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Shooter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player") playerishere = true;
	}

	void OerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player") playerishere = false;
	}

	IEnumerator Shooter()
	{
		while (true)
		{
			yield return new WaitForSeconds(shootWait);
			if (playerishere)
			{
				position = camera.GetComponent<Transform>().position;
				position.x += Mathf.Sign(Random.Range(-1, 1)) * Random.Range(rangeFromCameraXIn, rangeFromCameraXOutline);
				position.y += Random.Range(rangeFromCameraXIn, rangeFromCameraXOutline);
				StartCoroutine(shooter.Shoot(position));
			}
		}
	}
}
