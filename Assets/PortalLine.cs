using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, target.position);
    }

}
