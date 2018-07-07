using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    public bool IsActive = true;
    public float defaultLength = 50f;

    public bool shotRay = true;
    public float rayLength = 50000f;
    public LayerMask rayExclusionLayers;

    public Transform target;
    public Transform anchor;
    public LineRenderer lineRenderer;

    
    // Use this for initialization
    void Awake()
    {
        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsActive)
        {
            lineRenderer.enabled = false;
            return;
        }

        if (shotRay)
        {
            Ray ray = new Ray(anchor.position, anchor.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, rayLength, -rayExclusionLayers))
            {
                target = hit.transform;
                DrawTo(hit.point);
                return;
            }

            target = null;
        }

        if (target != null)
            DrawTo(target.position);
        else
            DrawTo(anchor.position + anchor.forward * defaultLength);
    }

    void DrawTo(Vector3 pos)
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, anchor.position);
        lineRenderer.SetPosition(1, pos);
    }

   
}
