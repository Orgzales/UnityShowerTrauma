using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableManager : MonoBehaviour
{

    Outline OutlineScript;
    public string Message;

    public UnityEvent onInteraction;

    void Start()
    {
        OutlineScript = GetComponent<Outline>();
        DisableOutline();
    }

    public void Interact()
    {
        onInteraction.Invoke();
    }

    public void DisableOutline()
    {
        OutlineScript.enabled = false;
    }

    public void EnableOutline()
    {
        OutlineScript.enabled = true;
    }


    ///  INTERACTIONS CALLS 


    private bool ShowerIsOn = false;

    public void TurnShowerOnOff()
    {
        if (ShowerIsOn)
        {
            ShowerIsOn = false;
            Debug.Log("Shower Turned Off");
        }
        else
        {
            ShowerIsOn = true;
            Debug.Log("Shower Turned On");
        }
    }


    // public void WashFace()
    // {
    //     Debug.Log("Washing Face");
    // }


}
