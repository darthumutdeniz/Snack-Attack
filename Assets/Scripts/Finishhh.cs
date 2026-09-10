using UnityEngine;

public class Finishhh : MonoBehaviour
{
    bool isCalled = false;

    void Start()
    {
        isCalled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isCalled)
        {
            GameScript.instance.NextScene();
            isCalled = true;
        }
    }
}
