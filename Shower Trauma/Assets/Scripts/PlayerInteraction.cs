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
        if (Input.GetKeyDown(KeyCode.E) && CurrentInteractable != null)
        {
            CurrentInteractable.Interact();
        }
    }

    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out hit, PlayerReach)) //player looking at interabtable 
        {
            InteractableManager newInteractable = hit.collider.GetComponent<InteractableManager>();
        }
    }

}
