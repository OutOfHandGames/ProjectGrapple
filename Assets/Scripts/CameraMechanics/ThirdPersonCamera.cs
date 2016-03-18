using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {
    public float cameraXSensitivity = 25f;
    public float cameraYSensitivuty = 25f;
    public float cameraSmoothing = 10f;
    public float cameraMoveSmoothing = 10f;
    bool updateEnabled = true;


    Transform target;
    float distanceFromTarget = -5;
    Vector3 oldRotation;

    void Start()
    {
        target = transform.parent;
        transform.parent = null;
        distanceFromTarget = -(target.position - transform.position).magnitude;
        GetComponent<CameraCollider>().setDefaultDistance(distanceFromTarget);
        oldRotation = transform.eulerAngles;
    }

    public void setCurrentMagnitude(float mag)
    {
        this.distanceFromTarget = mag;
    }

    void Update()
    {
        if (!updateEnabled)
        {
            return;
        }
        lookHorizontal(Input.GetAxis("Mouse X"));
        lookVertical(Input.GetAxis("Mouse Y"));
        updateCameraRotation();
        updateCameraPosition();

    }

    public void setTargetFollow(Transform targetFollow)
    {
        this.target = targetFollow;
    }

    public Transform getTargetFollow()
    {
        return target;
    }

    public float getCurrentMagnitude()
    {
        return distanceFromTarget;
    }

    public void setUpdateEnabled(bool enable)
    {
        updateEnabled = enable;
    }

    void updateCameraRotation()
    {
        Quaternion goalRotation = Quaternion.Euler(oldRotation.x, oldRotation.y, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, goalRotation, Time.deltaTime * cameraSmoothing);
        oldRotation = transform.rotation.eulerAngles;
    }

    void updateCameraPosition()
    {
        float distance = distanceFromTarget;
        
        Vector3 goalPosition = target.position + transform.forward * distance;
        transform.position = Vector3.MoveTowards(transform.position, goalPosition, Time.deltaTime * cameraMoveSmoothing);
    }

    void lookHorizontal(float horizontalInput)
    {

        oldRotation += Vector3.up * horizontalInput * cameraXSensitivity * Time.deltaTime;

    }

    void lookVertical(float verticalInput)
    {

        oldRotation += Vector3.left * verticalInput * cameraYSensitivuty * Time.deltaTime;
    }
}
