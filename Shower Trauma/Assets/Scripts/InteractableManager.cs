using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableManager : MonoBehaviour
{

    Outline Outline;
    public string Message;

    public UnityEvent onInteraction;

    void Start()
    {
        Outline = GetComponent<Outline>();
        DisableOutline();
    }

    public void Interact()
    {
        onInteraction.Invoke();
    }

    public void DisableOutline()
    {
        Outline.enabled = false;
    }

    public void EnableOutline()
    {
        Outline.enabled = true;
    }

}
