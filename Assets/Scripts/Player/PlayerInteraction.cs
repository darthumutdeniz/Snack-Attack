using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements.Experimental;

public class PlayerInteraction : MonoBehaviour
{
    public bool interactable = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnInteract(InputValue value)
    {
        Debug.Log("Interact Input Action Detected");
        if(value.isPressed)
        {
            interactable = true;
            Debug.Log("Button is pressed");
        }
        else if(!value.isPressed)
        {
            interactable = false;
            Debug.Log("Button is released");
        }
    }

    public void ChangeVelocity(float increaseAmount)
    {

    }

    public void ChangeJumpSpeed(float decreaseAmount)
    {

    }
}
