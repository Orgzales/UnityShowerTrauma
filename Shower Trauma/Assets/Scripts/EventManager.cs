using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{


    public float DirtyMeter = 10.0f;
    public float DirtyMeterDecreaseRate = 1.0f;

    public float InstanityMeter = 0.0f;
    public float InstanityMeterIncreaseRate = 0.1f;

    void Start()
    {
        StartDecreaseDirtyMeter();
    }

    void Update()
    {

    }

    //make a function that will decrease the dirty meter by dirtyMeterDecreaseRate every second
    public void DecreaseDirtyMeter()
    {
        DirtyMeter -= DirtyMeterDecreaseRate;
        Debug.Log("Dirty Meter: " + DirtyMeter);
        if (DirtyMeter <= 0)
        {
            //end the day and stop the decrease of the dirty meter
            CancelInvoke("DecreaseDirtyMeter");
            Debug.Log("End of the day");
        }
    }

    //call DecreaseDirtyMeter every 2 seconds
    public void StartDecreaseDirtyMeter()
    {
        InvokeRepeating("DecreaseDirtyMeter", 0.0f, 2.0f);
    }



}
