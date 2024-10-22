using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    ShowerManager ShowerManagerScript;

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
        int Day = 2; //TESTING
        float RandomNumber = Random.Range(1f, 100f);
        if (RandomNumber <= floatInsaneAmount + Day)
        {
            GetEventLevel();
        }

    }


    public void GetEventLevel() //severaity of the event based on dirty value and Day [later]
    {
        float Dirty_Amount = ShowerManagerScript.DirtyMeterValue;
        if (Dirty_Amount >= 25f) //
        {
            InstanceEvent();
        }
        else if (Dirty_Amount >= 50f)
        {
            SmallEvent();
        }
        else if (Dirty_Amount >= 75f)
        {
            BigEvent();
        }
        else if (Dirty_Amount >= 100f)
        {
            LevelChangingEvent();
        }

    }

    public void InstanceEvent() //Small Jumpscare or Creapy Quick Event
    {
        Debug.Log("Instance Event Happened");
    }

    public void SmallEvent() //small encounter, 1 click or look away
    {
        Debug.Log("Small Event Happened");
    }

    public void BigEvent() //Big Encounter, Near Death or Death
    {
        Debug.Log("Big Event Happened");
    }

    public void LevelChangingEvent() //Event that changes the level
    {
        Debug.Log("Level Changing Event Happened");
    }


}
