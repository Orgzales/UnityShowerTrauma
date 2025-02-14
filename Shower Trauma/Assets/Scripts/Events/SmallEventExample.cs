using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SmallEventExample : MonoBehaviour
{

    //test delete later
    public GameObject Door;
    public GameObject Goblin;

    public UnityEvent onInteraction;

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

    Animator GoblinAnimator;
    Animator DoorAnimator;
    public bool GoblinSeen = false;

    public void PeakingDoor()
    {
        //Goblin animation start hear 
        GoblinAnimator = GetComponent<Animator>();
        DoorAnimator = GetComponent<Animator>();
        //goblin is active and opens the door slightly
        Goblin.SetActive(true);
        DoorAnimator.Play("GoblinOpen", 0, 0.0f);
        GoblinAnimator.Play("GoblinStart", 0, 0.0f);
        

        //if player sees goblin, goblin hides and closes door
        
        

    }
    /// Plan
    /// Make small goblin that peaking around door
    /// if player makes contact with vector, goblin runs into door
    /// Goblin object disappears

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
