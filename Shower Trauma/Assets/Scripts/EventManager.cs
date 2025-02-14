using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //Use $$Example$$ to find logs in the console
    ShowerManager ShowerManagerScript;

    SmallEventExample SmallEventExample;
    MediumEventExample MediumEventExample;
    LargeEventExample LargeEventExample;
    LevelChangingExample LevelEventExample;

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
        SmallEventExample = GetComponent<SmallEventExample>();
        MediumEventExample = GetComponent<MediumEventExample>();
        LargeEventExample = GetComponent<LargeEventExample>();
        LevelEventExample = GetComponent<LevelChangingExample>();
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
            // Debug.Log("$$EVENT HAPPENED$$");
        }
        else
        {
            // Debug.Log("$$No Event Happened$$");
        }

    }


    public void GetEventLevel() //severaity of the event based on dirty value and Day [later]
    {
        float Dirty_Amount = ShowerManagerScript.DirtyMeterValue;
        if (Dirty_Amount >= 75f) //
        {
            PercentileOneEvent(); //instance
        }
        else if (Dirty_Amount >= 50f)
        {
            PercentileTwoEvent();
        }
        else if (Dirty_Amount >= 25f)
        {
            PercentileThreeEvent();
        }
        else if (Dirty_Amount >= 0f)
        {
            PercentileFourEvent();
        }

    }

    public void PercentileOneEvent() //Small Jumpscare or Creapy Quick Event
    {
        Debug.Log("$$Event(1) Happened$$");
        float InstanceEvent = InstanceEventChance + HigherChancePercentage; //50 + 10 = 60%
        float SmallEvent = SmallEventChance; //25 = 25%
        float MediumEvent = MediumEventChance - LowerChancePercentage; //15 - 5 = 10%
        float LevelChangingEvent = LevelChangingEventChance - LowerChancePercentage; //10 - 5 = 5%

        float RandomChance = Random.Range(1f, 100f);
        if (RandomChance <= InstanceEvent) // EX: 1-60, <= 60%
        {
            Debug.Log("$$Instance Event Happened$$");
            SmallEventExample.Random_pick();
        }
        else if (RandomChance <= InstanceEvent + SmallEvent) // EX: 61-85 <= 25%
        {
            Debug.Log("$$Small Event Happened$$");
            MediumEventExample.Random_pick();
        }
        else if (RandomChance <= SmallEvent + MediumEvent) // EX: 86-95 <= 10%
        {
            Debug.Log("$$Medium Event Happened$$");
            LargeEventExample.Random_pick();
        }
        else if (RandomChance <= MediumEvent + LevelChangingEvent) // EX: 96-100 <= 5%
        {
            Debug.Log("$$Level Changing Event Happened$$");
            LevelEventExample.Random_pick();
        }
    }

    public void PercentileTwoEvent() //small encounter, 1 click or look away
    {
        Debug.Log("$$Event(2) Happened$$");
        float InstanceEvent = InstanceEventChance - LowerChancePercentage; //45 = 45%
        float SmallEvent = SmallEventChance + HigherChancePercentage; //25 + 10 = 35%
        float MediumEvent = MediumEventChance; //15 = 15%
        float LevelChangingEvent = LevelChangingEventChance - LowerChancePercentage; //10 - 5 = 5%

        float RandomChance = Random.Range(1f, 100f);
        if (RandomChance <= InstanceEvent) // EX: 1-45, <= 45%
        {
            Debug.Log("$$Instance Event Happened$$");
            SmallEventExample.Random_pick();
        }
        else if (RandomChance <= InstanceEvent + SmallEvent) // EX: 46-80 <= 35%
        {
            Debug.Log("$$Small Event Happened$$");
            MediumEventExample.Random_pick();
        }
        else if (RandomChance <= SmallEvent + MediumEvent) // EX: 81-95 <= 15%
        {
            Debug.Log("$$Medium Event Happened$$");
            LargeEventExample.Random_pick();
        }
        else if (RandomChance <= MediumEvent + LevelChangingEvent) // EX: 96-100 <= 5%
        {
            Debug.Log("$$Level Changing Event Happened$$");
            LevelEventExample.Random_pick();
        }
    }

    public void PercentileThreeEvent() //Big Encounter, Near Death or Death
    {
        Debug.Log("$$Event(3) Happened$$");
        float InstanceEvent = InstanceEventChance - LowerChancePercentage; //45 = 45%
        float SmallEvent = SmallEventChance - LowerChancePercentage; //25 - 5 = 20%
        float MediumEvent = MediumEventChance + HigherChancePercentage; //15 + 10 = 25%
        float LevelChangingEvent = LevelChangingEventChance; //10 = 10%

        float RandomChance = Random.Range(1f, 100f);
        if (RandomChance <= InstanceEvent) // EX: 1-45, <= 45%
        {
            Debug.Log("$$Instance Event Happened$$");
            SmallEventExample.Random_pick();
        }
        else if (RandomChance <= InstanceEvent + SmallEvent) // EX: 46-65 <= 20%
        {
            Debug.Log("$$Small Event Happened$$");
            MediumEventExample.Random_pick();
        }
        else if (RandomChance <= SmallEvent + MediumEvent) // EX: 66-90 <= 25%
        {
            Debug.Log("$$Medium Event Happened$$");
            LargeEventExample.Random_pick();
        }
        else if (RandomChance <= MediumEvent + LevelChangingEvent) // EX: 91-100 <= 10%
        {
            Debug.Log("$$Level Changing Event Happened$$");
            LevelEventExample.Random_pick();
        }
    }

    public void PercentileFourEvent() //Event that changes the level
    {
        Debug.Log("$$Event(4) Happened$$");
        float InstanceEvent = InstanceEventChance; //50 = 50%
        float SmallEvent = SmallEventChance - LowerChancePercentage; //25 - 5 = 20%
        float MediumEvent = MediumEventChance - LowerChancePercentage; //15 - 5 = 10%
        float LevelChangingEvent = LevelChangingEventChance + HigherChancePercentage; //10 + 10 = 20%

        float RandomChance = Random.Range(1f, 100f);
        if (RandomChance <= InstanceEvent) // EX: 1-50, <= 50%
        {
            Debug.Log("$$Instance Event Happened$$");
            SmallEventExample.Random_pick();
        }
        else if (RandomChance <= InstanceEvent + SmallEvent) // EX: 51-70 <= 20%
        {
            Debug.Log("$$Small Event Happened$$");
            MediumEventExample.Random_pick();
        }
        else if (RandomChance <= SmallEvent + MediumEvent) // EX: 71-80 <= 10%
        {
            Debug.Log("$$Medium Event Happened$$");
            LargeEventExample.Random_pick();
        }
        else if (RandomChance <= MediumEvent + LevelChangingEvent) // EX: 81-100 <= 20%
        {
            Debug.Log("$$Level Changing Event Happened$$");
            LevelEventExample.Random_pick();
        }
    }


}
