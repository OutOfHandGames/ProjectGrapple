using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public float speed = 6;
    public float acceleration = 15;

    Rigidbody rigid;
    bool movementDisabled;
    float hInput;
    float vInput;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        updateVelocity();
    }

    void updateVelocity()
    {
        if (movementDisabled)
        {
            hInput = 0;
            vInput = 0;
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
}
