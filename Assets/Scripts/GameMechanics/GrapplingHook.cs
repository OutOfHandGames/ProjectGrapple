using UnityEngine;
using System.Collections;

public class GrapplingHook : MonoBehaviour {
    public float firingForce = 100;
    public float hookSpeed = 15;

    bool isHooked;
    Transform cameraTransform;
    Rigidbody rigid;
    Transform owner;

    public void fireGrapple(Vector3 direction)
    {
        rigid = GetComponent<Rigidbody>();
        rigid.AddForce(firingForce * direction, ForceMode.Impulse);
    }

    public void setOwner(Transform owner)
    {
        this.owner = owner;
    }

    public Transform getOwner()
    {
        return this.owner;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            return;
        }
        rigid.isKinematic = true;
        isHooked = true;
        owner.GetComponent<Rigidbody>().isKinematic = true;
    }

    void FixedUpdate()
    {
        if (isHooked)
        {
            owner.position = Vector3.MoveTowards(owner.position, transform.position, Time.fixedDeltaTime * hookSpeed);
        }
    }
}
