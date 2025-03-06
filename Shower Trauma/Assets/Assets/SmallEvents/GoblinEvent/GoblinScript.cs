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



    private void Start()
    {
        GoblinRender = GetComponent<Renderer>(); 
        GoblinAnimator = Goblin.GetComponent<Animator>();
        DoorAnimator = Door.GetComponent<Animator>();   
    }

    private void Update()
    {
        if (GoblinRender != null && IsVisibleFrom(Camera.main))
        {
            GoAway();
        }
    }

    private bool IsVisibleFrom(Camera cam)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
        return GeometryUtility.TestPlanesAABB(planes, GoblinRender.bounds);
    }

    private void GoAway()
    {
        
        GoblinAnimator.Play("GoblinEnd", -1, 0.0f);
        DoorAnimator.Play("GoblinClose", -1, 0.0f);

        Debug.Log($"$$GoblinLeaving$$");
        // gameObject.SetActive(false);
    }

}
