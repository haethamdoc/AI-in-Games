using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AreaTrigger : MonoBehaviour
{ 
    public UnityEvent onEnter, onExit; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.GetComponent<Interact>() != null)
            {
                if (gameObject.GetComponent<Interact>().isInteractable)
                    onEnter?.Invoke();
            }
            else 
                onEnter?.Invoke();
             
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            onExit?.Invoke();
    }

}
