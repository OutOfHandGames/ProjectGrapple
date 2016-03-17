using UnityEngine;
using System.Collections;

public class FireGrapple : MonoBehaviour {
    public GameObject grapple;

    Transform cameraTransform;

    void Start()
    {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void Update()
    {
        fireGrapplingHook(Input.GetButtonDown("Fire1"));
    }

    void fireGrapplingHook(bool isFired)
    {
        if (!isFired)
        {
            return;
        }

        GameObject obj = (GameObject)Instantiate(grapple, this.transform.position, cameraTransform.rotation);
        GrapplingHook hookObj = obj.GetComponent<GrapplingHook>();
        hookObj.setOwner(this.transform.parent);
        hookObj.fireGrapple(cameraTransform.forward);
        
    }
}
