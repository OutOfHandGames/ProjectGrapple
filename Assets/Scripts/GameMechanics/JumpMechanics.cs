using UnityEngine;
using System.Collections;

public class JumpMechanics : MonoBehaviour {
    public float jumpForce = 200;
    public bool canDoubleJump;
    public Transform jumpCheckTransform;

    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void jumpPressed()
    {
        if (checkCanJump())
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpPressed();
        }
    }

    bool checkCanJump()
    {
        RaycastHit hit;
        return Physics.Raycast(jumpCheckTransform.position, -jumpCheckTransform.up, out hit, .1f) ;
    }
}
