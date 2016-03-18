using UnityEngine;
using System.Collections;

public class GrapplingHook : MonoBehaviour {
    public float firingForce = 100;
    public float hookSpeed = 15;
    public float disconnectJumpForce = 50;

    bool isHooked;
    bool isDisconnected;
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

    public void disconnectGrapple()
    {
        GetComponent<LineRenderer>().enabled = false;
        isDisconnected = true;
        owner.GetComponent<Rigidbody>().isKinematic = false;
        owner.GetComponent<Rigidbody>().AddForce(hookSpeed * disconnectJumpForce * Vector3.up, ForceMode.Impulse);
        owner.GetComponent<Rigidbody>().AddForce(hookSpeed * Input.GetAxisRaw("Vertical") * (transform.position - owner.position).normalized, ForceMode.Impulse);

    }

    void FixedUpdate()
    {
        if (isHooked && !isDisconnected)
        {
            owner.position = Vector3.MoveTowards(owner.position, transform.position, Time.fixedDeltaTime * hookSpeed);
        }
    }
}
