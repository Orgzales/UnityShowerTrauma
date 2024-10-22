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
        InsaneAmount = ShowerManagerScript.InsanityMeterValue;
        //get the # Days 1-7 week 
        int Day = 2; //TESTING
        int RandomNumber = Random.Range(1, 10);
        if (Day >= RandomNumber)
        {
            if (InsaneAmount >= 25f)
            {
                InstanceEvent();
            }
            else if (InsaneAmount >= 50f)
            {
                SmallEvent();
            }
            else if (InsaneAmount >= 75f)
            {
                BigEvent();
            }
            else if (InsaneAmount >= 100f)
            {
                LevelChangingEvent();
            }
        }

    }


    public void GetEventLevel() //severaity of the event based on dirty value and Day [later]
    {
        Dirty_Amount = ShowerManagerScript.DirtyMeterValue;


    }

    public void InstanceEvent() //Small Jumpscare or Creapy Quick Event
    {

    }

    public void SmallEvent() //small encounter, 1 click or look away
    {

    }

    public void BigEvent() //Big Encounter, Near Death or Death
    {

    }

    public void LevelChangingEvent() //Event that changes the level
    {

    }


}
