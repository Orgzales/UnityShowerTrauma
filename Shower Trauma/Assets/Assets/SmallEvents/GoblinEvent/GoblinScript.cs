using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinScript : MonoBehaviour
{
    private Renderer GoblinRender;
    public GameObject Door;
    public GameObject Goblin;
    Animator GoblinAnimator;
    Animator DoorAnimator;

    private bool GoblinLeft = false;

    private void Start()
    {
        GoblinRender = GetComponent<Renderer>(); 
        GoblinAnimator = Goblin.GetComponent<Animator>();
        DoorAnimator = Door.GetComponent<Animator>();   
    }

    private void Update()
    {
        if (!GoblinLeft && GoblinRender != null && IsVisibleFrom(Camera.main))
        {
            GoblinLeft = true;
            StartCoroutine(GoblinBeenSeen());  
        }
    }

    private bool IsVisibleFrom(Camera cam)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
        return GeometryUtility.TestPlanesAABB(planes, GoblinRender.bounds);
    }

    private IEnumerator GoblinBeenSeen()
    {
        yield return new WaitForSeconds(1f); // Wait 1 second to wait for the player to see it

        GoblinAnimator.Play("GoblinExit", 0, 0.0f);
        DoorAnimator.Play("Door45Close", 0, 0.0f);

        yield return new WaitForSeconds(2f);
        Debug.Log("$$Goblin Gone$$");
        Goblin.SetActive(false);  // Disable the Goblin
    }
}
