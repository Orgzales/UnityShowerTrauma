using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinScript : MonoBehaviour
{
    private Renderer GoblinRender;

    private void Start()
    {
        GoblinRender = GetComponent<Renderer>();
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
        Debug.Log("RUNNING AWAY...");
        gameObject.SetActive(false);
    }

}
