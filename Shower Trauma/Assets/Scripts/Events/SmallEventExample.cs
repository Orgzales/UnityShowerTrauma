using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEventExample : MonoBehaviour
{

    public void PeakingDoor()
    {
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
