using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    ShowerManager ShowerManagerScript;

    // [percentages of event changers]
    public float HigherChancePercentage = 10f; //changes one event value
    public float LowerChancePercentage = 5f; //changes two event values

    //[percentages of events happening]
    public float PercentileOneEventChance = 50f;
    public float nChance = 25f;
    public float PercentileThreeEventChance = 15f;
    public float PercentileFourEventChance = 10f;

    public float DaysPassed = 0f;

    void Start()
    {
        ShowerManagerScript = GetComponent<ShowerManager>();
    }

    // public void test()
    // {
    //     Debug.Log(ShowerManagerScript.DirtyMeterValue);
    //     Debug.Log(ShowerManagerScript.InsanityMeterValue);
    // }

    public void DoesEventHappen() //more insane and more down the week causes more events to happen
    {
        float floatInsaneAmount = ShowerManagerScript.InsanityMeterValue;
        //get the # Days 1-7 week 
        float RandomNumber = Random.Range(1f, 100f);
        if (RandomNumber <= floatInsaneAmount + DaysPassed)
        {
            GetEventLevel();
        }

    }


    public void GetEventLevel() //severaity of the event based on dirty value and Day [later]
    {
        float Dirty_Amount = ShowerManagerScript.DirtyMeterValue;
        if (Dirty_Amount >= 25f) //
        {
            PercentileOneEvent(); //instance
        }
        else if (Dirty_Amount >= 50f)
        {
            PercentileTwoEvent();
        }
        else if (Dirty_Amount >= 75f)
        {
            PercentileThreeEvent();
        }
        else if (Dirty_Amount >= 100f)
        {
            PercentileFourEvent();
        }

    }

    public void PercentileOneEvent() //Small Jumpscare or Creapy Quick Event
    {
        Debug.Log("Event(1) Happened");
    }

    public void PercentileTwoEvent() //small encounter, 1 click or look away
    {
        Debug.Log("Event(2) Happened");
    }

    public void PercentileThreeEvent() //Big Encounter, Near Death or Death
    {
        Debug.Log("Event(3) Happened");
    }

    public void PercentileFourEvent() //Event that changes the level
    {
        Debug.Log("Event(4) Happened");
    }


}
