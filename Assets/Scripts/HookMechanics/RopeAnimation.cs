using UnityEngine;
using System.Collections;

public class RopeAnimation : MonoBehaviour {
    GrapplingHook hook;
    LineRenderer lineRenderer;

    void Start()
    {
        hook = GetComponent<GrapplingHook>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lineRenderer.SetPosition(0, hook.getOwner().position);
        lineRenderer.SetPosition(1, transform.position);
    }
}
