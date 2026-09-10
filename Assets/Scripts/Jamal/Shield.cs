using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Shield : MonoBehaviour
{

	[SerializeField] GameObject shield;
	[SerializeField] float shieldDuration;
	[SerializeField] float cooldown;
	bool cooldownHasEnded = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
	{
		shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		
    }
	IEnumerator SetActive()
	{
		shield.SetActive(true);
		yield return new WaitForSeconds(shieldDuration);
		shield.SetActive(false);
		yield return new WaitForSeconds(cooldown);
		cooldownHasEnded = true;

	}

	void OnShield(InputValue value)
	{
		if (value.isPressed && cooldownHasEnded)
		{
			cooldownHasEnded = false;
			StartCoroutine(SetActive());
		}
	}
}
