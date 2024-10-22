using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    ShowerManager ShowerManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        ShowerManagerScript = GetComponent<ShowerManager>();
    }

    public void test()
    {
        Debug.Log(ShowerManagerScript.DirtyMeterValue);
        Debug.Log(ShowerManagerScript.InsanityMeterValue);
    }

}
