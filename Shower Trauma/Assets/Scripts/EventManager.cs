using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject ShowerBounds;
    public float DirtyMeterValue = 100.0f;
    public float DirtyMeterRate = 0.1f; //Down

    public float InsanityMeterValue = 0.0f;
    public float InsanityMeterRate = 1.0f; //Up

    private bool ShowerStarted = false;
    private bool IsInsideShower = false;
    private Coroutine countdownCoroutine;

    void Update()
    {
        if (ShowerStarted && !IsInsideShower) //If the player is outside the shower
        {
            DirtyMeterValue += DirtyMeterRate * Time.deltaTime; //You get more dirty

            if (DirtyMeterValue > 200f)
            {
                DirtyMeterValue = 200f; //Max Dirty
            }

            Debug.Log("Countdown Value (Outside): " + DirtyMeterValue);
        }
    }

    private void OnTriggerEnter(Collider Shower)
    {
        if (Shower.CompareTag("Player"))
        {
            IsInsideShower = true;
            if (!ShowerStarted) //starts the shower here
            {
                ShowerStarted = true;
                countdownCoroutine = StartCoroutine(Countdown());
                Debug.Log("Countdown started.");
            }
        }
    }

    private void OnTriggerExit(Collider Shower)
    {
        if (Shower.CompareTag("Player"))
        {
            IsInsideShower = false;
            Debug.Log("Player exited boundary.");

            if (countdownCoroutine != null)
            {
                StopCoroutine(countdownCoroutine);
                countdownCoroutine = null;
            }
        }
    }

    private IEnumerator Countdown()
    {

        while (IsInsideShower)// while inside the shower you get clean
        {
            if (DirtyMeterValue < 100)
            {
                DirtyMeterValue -= 1f;

                if (DirtyMeterValue < 0f)
                {
                    DirtyMeterValue = 0f;
                }

                Debug.Log("Countdown Value (Inside): " + DirtyMeterValue);
            }

            // Wait for 1 second 
            yield return new WaitForSeconds(1f);
        }
    }


}
