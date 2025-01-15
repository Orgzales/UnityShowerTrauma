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
        int RandomEvent = Random.Range(1, 4);
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

    public void PeakingDoor()
    {
        Goblin.SetActive(true);
        Debug.Log("$$PeakingDoor$$");
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
