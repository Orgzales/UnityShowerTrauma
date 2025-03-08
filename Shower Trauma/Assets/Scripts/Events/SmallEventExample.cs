using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEventExample : MonoBehaviour
{

    //test delete later
    public GameObject Door;
    public GameObject Goblin;

    public void Random_pick()
    {
        // int RandomEvent = Random.Range(1, 4);
        int RandomEvent = 1; //Testing
        switch (RandomEvent)
        {
            case 1:             
                GoblinEvent();
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
 
    public void GoblinEvent()
    {
        GoblinAnimator = Goblin.GetComponent<Animator>();
        DoorAnimator = Door.GetComponent<Animator>();    

        Goblin.SetActive(true);
        DoorAnimator.Play("Door45Open", 0, 0.0f);
        GoblinAnimator.Play("GoblinEnter", 0, 0.0f);
        Debug.Log("$$GoblinEvent$$");
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
