using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class Crafter : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject craftingCanvas;

    void Start()
    {
    }

    public bool canInteract()
    {
        return true;
    }

    public void Interact()
    {
        Debug.Log("Interacted");
        OpenCraftingCanvas();
    }

    void OpenCraftingCanvas()
    {
        craftingCanvas.SetActive(true);
    }
}
