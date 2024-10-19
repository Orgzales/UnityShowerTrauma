using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject ShowerBounds;
    public float DirtyMeterValue = 100f;

    public float CleanRate = 0.5f; //Down: Getting clean
    public float DirtyRate = 0.1f; //UP : getting dirty

    public float InsanityMeterValue = 0f;
    public float InsaneRate = 0.2f; //Up

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
            Debug.Log($"Getting Clean and insane started.");
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
                DirtyMeterValue -= CleanRate;
                if (DirtyMeterValue < 0f)
                {
                    DirtyMeterValue = 0f;
                }
                // Debug.Log($"[IN SHOWER] Dirty Value: {DirtyMeterValue:F2}");
            }

            if (InsanityMeterValue < 200)
            {
                InsanityMeterValue += InsaneRate;
                if (InsanityMeterValue < 0f)
                {
                    InsanityMeterValue = 0f;
                }
                // Debug.Log($"[IN SHOWER] Insanity Value: {InsanityMeterValue:F2}");
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
                DirtyMeterValue += DirtyRate;

                if (DirtyMeterValue < 0f)
                {
                    DirtyMeterValue = 0f;
                }

                // Debug.Log($"[OUT SHOWER] Dirty Value: {DirtyMeterValue:F2}");
            }

            // Wait for 1 second 
            yield return new WaitForSeconds(1f);
        }
    }


}
