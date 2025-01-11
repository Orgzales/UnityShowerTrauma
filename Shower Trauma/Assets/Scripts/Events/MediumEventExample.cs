using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEventExample : MonoBehaviour
{


    public void Random_pick()
    {
        int RandomEvent = Random.Range(1, 3);
        if (RandomEvent == 1)
        {
            Lightsturnoff();
        }
        else if (RandomEvent == 2)
        {
            Windowopens();

        }
    }
    public void Lightsturnoff()
    {
        Debug.Log("$$LightsTurnOff$$");
    }

    public void Windowopens()
    {
        Debug.Log("$$WindowOpens$$");
    }

}
