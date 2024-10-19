using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerManager : MonoBehaviour
{
    public GameObject ShowerBounds;
    public float DirtyMeterValue = 100f;

    public float CleanRate = 0.5f; //Down: Getting clean
    public float DirtyRate = 0.1f; //UP : getting dirty

    public float InsanityMeterValue = 0f;
    public float InsaneRate = 0.2f; //Up

    private bool ShowerStarted = false; //The player started the Round
    private bool IsInsideShower = false;
    public bool IsShowerOn = false;
    private Coroutine countdownCoroutine;
    private Coroutine countupCoroutine;

    public GameObject ShowerHeadCollider;


    void Update()
    {

    }

    private void OnTriggerEnter(Collider Shower)
    {
        if (Shower.CompareTag("Player"))
        {
            IsInsideShower = true;
            Debug.Log("Player entered Shower.");
            countdownCoroutine = StartCoroutine(Countdown());
            if (countupCoroutine != null)
            {
                StopCoroutine(countupCoroutine);
            }

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
        Debug.Log($"Getting Clean and insane.");
        while (IsInsideShower)// while inside the shower you get clean but go more insane 
        {
            if (IsShowerOn && ShowerStarted)
            {
                if (DirtyMeterValue > 0)
                {
                    DirtyMeterValue -= CleanRate;
                    if (DirtyMeterValue < 0f)
                    {
                        DirtyMeterValue = 0f;
                    }
                    Debug.Log($"[IN SHOWER] Dirty Value: {DirtyMeterValue:F2}");
                }

                if (InsanityMeterValue < 200)
                {
                    InsanityMeterValue += InsaneRate;
                    if (InsanityMeterValue < 0f)
                    {
                        InsanityMeterValue = 0f;
                    }
                    Debug.Log($"[IN SHOWER] Insanity Value: {InsanityMeterValue:F2}");
                }
            }
            // Wait for 1 second 
            yield return new WaitForSeconds(1f);
        }

    }

    private IEnumerator CountUp()
    {
        if (ShowerStarted)
        {
            Debug.Log("Getting More Dirty.");
            while (!IsInsideShower)// while Outside the shower you get Dirty
            {
                if (DirtyMeterValue < 200)
                {
                    DirtyMeterValue += DirtyRate;

                    if (DirtyMeterValue < 0f)
                    {
                        DirtyMeterValue = 0f;
                    }

                    Debug.Log($"[OUT SHOWER] Dirty Value: {DirtyMeterValue:F2}");
                }

                // Wait for 1 second 
                yield return new WaitForSeconds(1f);
            }
        }
    }

    public void TurnShowerOnOff()
    {
        if (ShowerStarted == false)
        {
            ShowerStarted = true;
            Debug.Log("Shower Started");
        }
        if (IsShowerOn)
        {
            IsShowerOn = false;
            Debug.Log("Shower Turned Off");
        }
        else
        {
            IsShowerOn = true;
            Debug.Log("Shower Turned On");
        }
    }

    public void EnabledWashingFace()
    {
        if (IsShowerOn)
        {
            ShowerHeadCollider.SetActive(true);
        }
        else
        {
            ShowerHeadCollider.SetActive(false);
        }
    }
    public void WashingFace()
    {
        DirtyMeterValue -= 20f;
        InsanityMeterValue += 20f;
        Debug.Log("After Wash Value: " + DirtyMeterValue);
    }


}
