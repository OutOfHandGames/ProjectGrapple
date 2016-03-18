using UnityEngine;
using System.Collections;

public class PlayerMovement : Movement {
    Transform cameraFollow;

    protected override void Start()
    {
        base.Start();
        cameraFollow = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    protected override void Update () {
        updateHInput(Input.GetAxisRaw("Horizontal"));
        updateVInput(Input.GetAxisRaw("Vertical"));
        base.Update();
        
    }

    protected override void updateVelocity(float hInput, float vInput)
    {

        Vector2 inputConversion = convertCameraForward(hInput, vInput);
        base.updateVelocity(inputConversion.x, inputConversion.y);
        
    }

    protected override void updateRotation(float hInput, float vInput)
    {
        Vector2 inputConversion = convertCameraForward(hInput, vInput);
        base.updateRotation(inputConversion.x, inputConversion.y);
    }

    Vector2 convertCameraForward(float hInput, float vInput)
    {
        Vector3 cameraForward = cameraFollow.forward;
        Vector3 cameraRight = cameraFollow.right;
        Vector3 newForward = cameraForward * vInput + cameraRight * hInput;
        newForward = newForward - Vector3.up * newForward.y;
        return new Vector2(newForward.x, newForward.z);
    }
}
