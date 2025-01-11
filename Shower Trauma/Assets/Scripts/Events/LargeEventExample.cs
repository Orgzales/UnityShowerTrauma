using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeEventExample : MonoBehaviour
{
    public void Random_pick()
    {
        int RandomEvent = Random.Range(1, 3);
        if (RandomEvent == 1)
        {
            Dontlook();
        }
        else if (RandomEvent == 2)
        {
            Hide();
        }

    }

    public void Hide()
    {
        Debug.Log("$$Hide$$");
    }

    public void Dontlook()
    {
        Debug.Log("$$Don't look$$");
    }
}
