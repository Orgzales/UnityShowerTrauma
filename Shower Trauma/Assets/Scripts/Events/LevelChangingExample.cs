using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChangingExample : MonoBehaviour
{

    public void Random_pick()
    {
        int RandomEvent = Random.Range(1, 4);
        if (RandomEvent == 1)
        {
            forest();
        }
        else if (RandomEvent == 2)
        {
            cave();

        }
        else if (RandomEvent == 3)
        {
            secrettunnel();
        }
    }
    public void forest()
    {
        Debug.Log("$$Forest$$");
    }

    public void cave()
    {
        Debug.Log("$$Cave$$");
    }

    public void secrettunnel()
    {
        Debug.Log("$$SecretTunnel$$");
    }

}
