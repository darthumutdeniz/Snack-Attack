using UnityEngine;
using UnityEngine.InputSystem;

public class AttackerSpoon : MonoBehaviour
{
	int framecounter;
	[SerializeField] GameObject hitter;
	bool hitting = false;
	bool hit = false;
	bool unhit = false;
	[SerializeField] int animationFrameCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
	{
		hitter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		if (hit)
		{
			hitter.SetActive(true);
			hit = false;
			framecounter = 0;
			hitting = true;
		}
        if (hitting)
		{
			if (unhit)
			{
				unhit = false;
				hitting = false;
			}
			framecounter++;
			if (framecounter == animationFrameCount)
			{
				hitting = false;
				hitter.SetActive(false);
			}
		}
    }

	void OnAttack(InputValue value)
	{
		if (value.isPressed)
		{
			hit = true;
		}
		else
		{
			unhit = false;
		}
	}
}
