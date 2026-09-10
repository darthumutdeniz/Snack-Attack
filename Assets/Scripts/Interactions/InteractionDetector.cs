using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class InteractionDetector : MonoBehaviour
{
    IInteractable interactableInRange = null;
    [SerializeField] TextMeshProUGUI interactText;
    [SerializeField] GameObject interactionDetector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactText.gameObject.SetActive(false);
    }

    void OnInteract(InputValue value)
    {
        Debug.Log("Input Interacted");
        if (value.isPressed)
        {
            Debug.Log("Button Pressed");
            interactableInRange?.Interact();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable) && interactable.canInteract())
        {
            interactableInRange = interactable;
            interactText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.TryGetComponent(out IInteractable interactable) && interactable == interactableInRange)
        {
            interactableInRange = null;
            interactText.gameObject.SetActive(false);
        }
    }
}
