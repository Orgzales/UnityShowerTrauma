using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowerManager : MonoBehaviour
{
    public GameObject ShowerBounds;
    public float DirtyMeterValue = 100f;

    //~~~~~~~~~~~~~~Dirty Meter~~~~~~~~~~~~~~
    public Image DirtyBar;
    public Image DirtyBar2;
    public Image DirtyBar3;
    public Image DirtyBar4;
    public float CleanRate = 0.25f; //Down: Getting clean
    public float DirtyRate = 0.1f; //UP : getting dirty
    public float[] DirtyPercentile = { 75f, 50f, 25f, 0f }; //add more values later
    public bool[] PassedDirtyPercentile = { false, false, false, false }; //add more values later
    public int CurrentPercentile = 0;
    //~~~~~~~~~~~~~~Dirty Meter~~~~~~~~~~~~~~
    //~~~~~~~~~~~~~~Insane Meter~~~~~~~~~~~~~~

    public float InsanityMeterValue = 0f;
    public float InsaneRate = 0.2f; //Up
    public float[] InsanePercentile = { 0f, 25f, 50f, 75f, 100f, 125f, 150f, 175f, 200f, 300f }; //add more values later

    //~~~~~~~~~~~~~~Insane Meter~~~~~~~~~~~~~~

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
                    //put if percentile statement here, idk I'm tired
                    DirtyMeterValue -= CleanRate;

                    if (DirtyMeterValue <= DirtyPercentile[CurrentPercentile] && !PassedDirtyPercentile[CurrentPercentile])
                    {
                        DirtyMeterValue = DirtyPercentile[CurrentPercentile];
                        CurrentPercentile++;
                    }
                    else if (DirtyMeterValue >= && PassedDirtyPercentile[CurrentPercentile])
                    {
                        PassedDirtyPercentile[CurrentPercentile] = false;
                        CurrentPercentile--;
                    }
                    UpdateDirtyBar();
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
                    UpdateDirtyBar();

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

        float RandomCleanAmount = Random.Range(1f, 10f);
        float RandomInsaneAmount = Random.Range(5f, 10f);
        DirtyMeterValue -= RandomCleanAmount;
        InsanityMeterValue += RandomInsaneAmount;
        // Debug.Log("After Wash Value: " + DirtyMeterValue);
        Debug.Log("Random Clean Amount: " + RandomCleanAmount);
        Debug.Log("Random Insane Amount: " + RandomInsaneAmount);
    }

    // NormalizedValue = (DirtyMeterValue - minValue) / (maxValue - minValue);
    // float NormalizedValue = (DirtyMeterValue - 75f) / 25f;
    public void UpdateDirtyBar()
    {
        if (DirtyMeterValue >= 75f) //percentile 1
        {
            float NormalizedValue = (DirtyMeterValue - 75f) / 25f;
            DirtyBar.fillAmount = NormalizedValue;
        }
        else if (DirtyMeterValue < 75f) // for jumps down
        {
            DirtyBar.fillAmount = 0f;
        }
        else if (DirtyMeterValue > 100f) // for jumps up
        {
            DirtyBar.fillAmount = 1f;
        }
        if (DirtyMeterValue >= 50f && DirtyMeterValue < 75f) //percentile 2
        {
            float NormalizedValue = (DirtyMeterValue - 50f) / 25f;
            DirtyBar2.fillAmount = NormalizedValue;
        }
        else if (DirtyMeterValue < 50f) // for jumps down
        {
            DirtyBar2.fillAmount = 0f;
        }
        else if (DirtyMeterValue > 75f) // for jumps up
        {
            DirtyBar2.fillAmount = 1f;
        }
        if (DirtyMeterValue >= 25f && DirtyMeterValue < 50f) //percentile 3
        {
            float NormalizedValue = (DirtyMeterValue - 25f) / 25f;
            DirtyBar3.fillAmount = NormalizedValue;
        }
        else if (DirtyMeterValue < 25f) // for jumps down
        {
            DirtyBar3.fillAmount = 0f;
        }
        else if (DirtyMeterValue > 50f) // for jumps up
        {
            DirtyBar3.fillAmount = 1f;
        }
        if (DirtyMeterValue >= 0f && DirtyMeterValue < 25f) //percentile 4
        {
            float NormalizedValue = (DirtyMeterValue - 0f) / 25f;
            DirtyBar4.fillAmount = NormalizedValue;
        }
        else if (DirtyMeterValue < 0f) // for jumps down
        {
            DirtyBar4.fillAmount = 0f;
        }
        else if (DirtyMeterValue > 25f) // for jumps up
        {
            DirtyBar4.fillAmount = 1f;
        }
    }


}
