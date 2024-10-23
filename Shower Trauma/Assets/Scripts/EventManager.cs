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
    public float InstanceEventChance = 50f;
    public float SmallEventChance = 25f;
    public float MediumEventChance = 15f;
    public float LevelChangingEventChance = 10f;

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
        float RandomChance = Random.Range(1f, 100f);
        if (RandomChance <= floatInsaneAmount + DaysPassed)
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
        float InstanceEvent = 100 - InstanceEventChance + HigherChancePercentage; // 100 - 50 + 10 = 60
        float SmallEvent = 100 - SmallEventChance; // 100 - 25 = 75
        float MediumEvent = 100 - MediumEventChance - LowerChancePercentage; // 100 - 15 - 5 = 80
        float LevelChangingEvent = 100 - LevelChangingEventChance - LowerChancePercentage; // 100 - 10 - 5 = 85

        float RandomChance = Random.Range(1f, 100f);
        if (RandomChance <= InstanceEvent) // EX: 50-1, <= 60%
        {
            Debug.Log("Instance Event Happened");
        }
        else if (InstanceEvent < RandomChance && RandomChance <= SmallEvent) //EX: 51-75 <= 25%
        {
            Debug.Log("Small Event Happened");
        }
        else if (SmallEvent < RandomChance && RandomChance <= MediumEvent) //EX: 76-80 <= 15%
        {
            Debug.Log("Medium Event Happened");
        }
        else if (MediumEvent < RandomChance && RandomChance <= LevelChangingEvent) //EX: 81-85 <= 10%
        {
            Debug.Log("Level Changing Event Happened");
        }
    }

    public void PercentileTwoEvent() //small encounter, 1 click or look away
    {
        Debug.Log("Event(2) Happened");
        float InstanceEvent = 100 - InstanceEventChance; // 100 - 50 = 50
        float SmallEvent = 100 - SmallEventChance + HigherChancePercentage; // 100 - 25 + 10 = 35
        float MediumEvent = 100 - MediumEventChance - LowerChancePercentage; // 100 - 15 - 5 = 80
        float LevelChangingEvent = 100 - LevelChangingEventChance - LowerChancePercentage; // 100 - 10 - 5 = 85

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
