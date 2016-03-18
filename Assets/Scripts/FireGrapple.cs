using UnityEngine;
using System.Collections;

public class FireGrapple : MonoBehaviour {
    public GameObject grapple;
    public int grappleCount = 10;

    GrapplingHook currentGrapplingHook;
    GrapplingHook[] grappleList;
    Transform cameraTransform;
    bool grappleActive = false;
    int frame;

    void Start()
    {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        grappleList = new GrapplingHook[grappleCount];
        
    }

    void Update()
    {
        frame++;
        if (!grappleActive)
        {
            fireGrapplingHook(Input.GetButtonDown("Fire1"));
        }
        else
        {
            disconnectGrapple(Input.GetButtonDown("Fire1"));
        }
    }

    void disconnectGrapple(bool  isDisconnected)
    {
        if (!isDisconnected)
        {
            return;
        }
        currentGrapplingHook.disconnectGrapple();
        grappleActive = false;
    }

    void fireGrapplingHook(bool isFired)
    {
        if (!isFired)
        {
            return;
        }
        GameObject obj = (GameObject)Instantiate(grapple, this.transform.position, cameraTransform.rotation);
        currentGrapplingHook = obj.GetComponent<GrapplingHook>();
        grappleActive = true;
        currentGrapplingHook.setOwner(this.transform.parent);
        currentGrapplingHook.fireGrapple(cameraTransform.forward);
        
    }
}
