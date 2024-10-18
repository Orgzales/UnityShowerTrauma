using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float PlayerReach = 3f;
    InteractableManager CurrentInteractable; //script InteractableManager

    // Update is called once per frame
    void Update()
    {
        CheckInteraction();
        if (Input.GetKeyDown(KeyCode.E) && CurrentInteractable != null)
        {
            CurrentInteractable.Interact();
        }
    }

    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out hit, PlayerReach)) //player looking at interactable 
        {
            InteractableManager NewInteractable = hit.collider.GetComponent<InteractableManager>();

            //if there is a current interactable and is not the new interactable
            if (CurrentInteractable != null && CurrentInteractable != NewInteractable)
            {
                CurrentInteractable.DisableOutline();
            }

            if (NewInteractable != null)
            {
                //outline new interactable
                if (NewInteractable.enabled)
                {
                    SetNewCurrentInteractable(NewInteractable);
                }
                else //if interactable is not enabled
                {
                    DisableCurrentInteractable();
                }
            }
            else //if nothing in reach
            {
                DisableCurrentInteractable();
            }
        }
        else //if nothing in reach
        {
            DisableCurrentInteractable();
        }
    }

    void SetNewCurrentInteractable(InteractableManager NewInteractable)
    {
        CurrentInteractable = NewInteractable;
        CurrentInteractable.EnableOutline();
        HudController.Instance.EnableInteractionText(CurrentInteractable.Message);
    }

    void DisableCurrentInteractable()
    {
        HudController.Instance.DisableInteractionText();
        if (CurrentInteractable != null)
        {
            CurrentInteractable.DisableOutline();
            CurrentInteractable = null;
        }
    }

}
