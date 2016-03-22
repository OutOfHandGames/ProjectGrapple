using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public float speed = 6;
    public float acceleration = 15;
    public float rotationSpeed = 15;

    protected Rigidbody rigid;
    protected bool movementDisabled;
    protected bool rotationDisabled;
    protected float hInput;
    protected float vInput;

    protected virtual void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        updateRotation(this.hInput, this.vInput);
        updateVelocity(this.hInput, this.vInput);

    }

    void FixedUpdate()
    {
    }

    protected virtual void updateVelocity(float hInput, float vInput)
    {
        if (movementDisabled)
        {
            return;
        }

        Vector3 goalVec = new Vector3(hInput, 0, vInput).normalized;
        goalVec *= speed;
        goalVec += Vector3.up * rigid.velocity.y;
        rigid.velocity = Vector3.MoveTowards(rigid.velocity, goalVec, Time.fixedDeltaTime * acceleration);

    }

    public void updateHInput(float hInput)
    {
        if (movementDisabled)
        {
            return;
        }
        this.hInput = hInput;

    }

    public void updateVInput(float vInput)
    {
        if (movementDisabled)
        {
            return;
        }
        this.vInput = vInput;
    }

    protected virtual void updateRotation(float hInput, float vInput)
    {
        if (rotationDisabled)
        {
            return;
        }
        if (Mathf.Abs(hInput) > .01f || Mathf.Abs(vInput) > .01f)
        {
            float yRotation = Mathf.Atan2(hInput, vInput) * Mathf.Rad2Deg;
            Vector3 goalRotation = yRotation * Vector3.up;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(goalRotation), Time.deltaTime * rotationSpeed);
        }
    }

    public float getSpeed()
    {
        if (hInput == 0 && vInput == 0)
        {
            return 0;
        }
        else
        {
            return Mathf.Sqrt(Mathf.Pow(hInput, 2) + Mathf.Pow(vInput, 2));
        }
    }
}
