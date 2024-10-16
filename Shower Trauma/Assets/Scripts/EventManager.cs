using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject ShowerBounds;
    public float DirtyMeterValue = 100.0f;
    public float DirtyMeterRate = 1.0f; //Down

    public float InsanityMeterValue = 0.0f;
    public float InsanityMeterRate = 0.2f; //Up

    private bool ShowerStarted = false;
    private bool IsInsideShower = false;
    private Coroutine countdownCoroutine;
    private Coroutine countupCoroutine;

    void Update()
    {

    }

    private void OnTriggerEnter(Collider Shower)
    {
        if (Shower.CompareTag("Player"))
        {
            IsInsideShower = true;
            Debug.Log("Player entered Shower.");
            // if (!ShowerStarted) //starts the shower here
            // {
            ShowerStarted = true;
            countdownCoroutine = StartCoroutine(Countdown());
            if (countupCoroutine != null)
            {
                StopCoroutine(countupCoroutine);
                Debug.Log("Getting More Dirty stopped.");
            }
            Debug.Log("Getting Clean and insane started.");
            // }
        }
    }

    private void OnTriggerExit(Collider Shower)
    {
        if (Shower.CompareTag("Player"))
        {
            IsInsideShower = false;
            Debug.Log("Player exited Shower.");

            if (countdownCoroutine != null)
            {
                StopCoroutine(countdownCoroutine);
                countupCoroutine = StartCoroutine(CountUp());
                // countdownCoroutine = null;
            }
        }
    }

    private IEnumerator Countdown()
    {

        while (IsInsideShower)// while inside the shower you get clean but go more insane 
        {
            if (DirtyMeterValue > 0)
            {
                DirtyMeterValue -= DirtyMeterRate;
                if (DirtyMeterValue < 0f)
                {
                    DirtyMeterValue = 0f;
                }
                Debug.Log("Dirty Value (Inside): " + DirtyMeterValue);
            }

            if (InsanityMeterValue < 200)
            {
                InsanityMeterValue += InsanityMeterRate;
                if (InsanityMeterValue < 0f)
                {
                    InsanityMeterValue = 0f;
                }
                Debug.Log("Insanity Value (Inside): " + InsanityMeterValue);
            }

            // Wait for 1 second 
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator CountUp()
    {

        while (!IsInsideShower)// while Outside the shower you get Dirty
        {
            if (DirtyMeterValue < 200)
            {
                DirtyMeterValue += DirtyMeterRate;

                if (DirtyMeterValue < 0f)
                {
                    DirtyMeterValue = 0f;
                }

                Debug.Log("Dirty Value (Outside): " + DirtyMeterValue);
            }

            // Wait for 1 second 
            yield return new WaitForSeconds(1f);
        }
    }


}
