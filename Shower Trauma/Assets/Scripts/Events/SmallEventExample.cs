using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEventExample : MonoBehaviour
{

    //test delete later
    public GameObject Door;
    public GameObject Goblin;
    public Camera PlayerPOVController;

    public void Random_pick()
    {
        // int RandomEvent = Random.Range(1, 4);
        int RandomEvent = 1; //Testing
        switch (RandomEvent)
        {
            case 1:
                PeakingDoor();
                break;
            case 2:
                Knocking(); 
                break;
            case 3:
                LightsFlicker();
                break;
        }
    }

       Animator GoblinAnimator ;
    Animator DoorAnimator ;

    public bool GoblinSeen = false;
    private bool hasPeaked = false;
    private bool hasHidden = false;
 
    public void PeakingDoor()
    {
        //Goblin animation start hear 
        // If the goblin hasn't peaked yet

        GoblinAnimator = Goblin.GetComponent<Animator>();
        DoorAnimator = Door.GetComponent<Animator>();    
        if (!hasPeaked)
        {
            Goblin.SetActive(true);
            DoorAnimator.Play("GoblinOpen", 0, 0.0f);
            GoblinAnimator.Play("Goblinstart", 0, 0.0f);
            Debug.Log("$$PeakingDoor$$");

            hasPeaked = true;
        }
        // if player sees goblin, goblin hides and closes door
        if (Goblin.activeSelf && !hasHidden)
        {
            Vector3 screenPoint = PlayerPOVController.WorldToViewportPoint(Goblin.transform.position);
            bool isInView = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

            if (isInView)
            {
                // Play hide animation and close door
                GoblinAnimator.Play("GoblinHide", 0, 0.0f);
                DoorAnimator.Play("GoblinClose", 0, 0.0f);
                Debug.Log("$$GoblinHides$$");

                hasHidden = true;
                Invoke("HideGoblin", 1.5f); // Adjust the delay to match the animation length
            }
        }

    } 

    void HideGoblin() 
    {
 
	}

	public void Start()
	{
		Random_pick();
	}
		


    public void Knocking()
    {
        Debug.Log("$$Knocking$$");
    }

    /// Plan
    /// Audio queue of knocking really loud and yelling
    public void LightsFlicker()
    {
        Debug.Log("$$LightFlicker$$");
    }

    /// Plan
    /// Lights flicker off for player 
    /// Need to make an nightlight so there is visabliltiy for player 


}
