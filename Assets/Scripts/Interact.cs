using UnityEngine;
using UnityEngine.Events;

public class Interact : MonoBehaviour
{
    public UnityEvent onInteract;
    public bool isInteractable = false;


    public void SetInteractable(bool value)
    {
        isInteractable = value;
    }


    public virtual void InteractWith()
    {
        // Invoke the onInteract event
        if(isInteractable)
            onInteract?.Invoke();
    }
}
