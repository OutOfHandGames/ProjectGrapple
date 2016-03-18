using UnityEngine;
using System.Collections;

public class CustomGravity : MonoBehaviour {
    public float gravityScale = 1;
    public bool gravityActive = true;

    float gravity = 9.8f;
    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        float finalGScale = gravityScale;
        if (Input.GetButton("Jump"))
        {
            finalGScale /= 2f;
        }

        float yVel = rigid.velocity.y - gravity * finalGScale * Time.fixedDeltaTime;
        rigid.velocity = new Vector3(rigid.velocity.x, yVel, rigid.velocity.z);
    }

}
