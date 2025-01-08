using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float PlayerReach = 3f;
    InteractableManager CurrentInteractable; //script InteractableManager
    FPS_Contoller PlayerController; //script FPS_Contoller

    public GameObject WashFaceUI; //testing for now w/ Black image
    public bool IsWashingFace = false;
    // Update is called once per frame

    void Start()
    {
        PlayerController = GetComponent<FPS_Contoller>();
    }

    void Update()
    {
        CheckInteraction();
        if (!IsWashingFace)
        {
            if (Input.GetKeyDown(KeyCode.E) && CurrentInteractable != null)
            {
                CurrentInteractable.Interact();
            }
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

    public void WashFace()
    {
        // Debug.Log("Washing Face");
        StartCoroutine(WashFaceRoutine());
    }
    private IEnumerator WashFaceRoutine()
    {
        WashFaceUI.gameObject.SetActive(true);
        PlayerController.moveSpeed = 0f;
        PlayerController.lookSpeed = 0f;
        PlayerController.jumpForce = 0f;
        IsWashingFace = true;
        yield return new WaitForSeconds(2f);
        WashFaceUI.gameObject.SetActive(false);
        PlayerController.moveSpeed = 5f;
        PlayerController.lookSpeed = 2f;
        PlayerController.jumpForce = 5f;
        IsWashingFace = false;
        StopCoroutine(WashFaceRoutine());
    }


}
