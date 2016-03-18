using UnityEngine;
using System.Collections;

public class CameraCollider : MonoBehaviour {

    Camera mainCamera;
    ThirdPersonCamera cameraProperties;
    float defaultDistance;

    void Start()
    {
        cameraProperties = GetComponent<ThirdPersonCamera>();
        defaultDistance = cameraProperties.getCurrentMagnitude();

    }

    void Update()
    {
        float mag = checkCameraCollision();

        if (mag < 0)
        {
            cameraProperties.setCurrentMagnitude(defaultDistance);
        }
        else
        {
            cameraProperties.setCurrentMagnitude(-mag);
        }
    }

    public void setDefaultDistance(float defaultDistance)
    {
        this.defaultDistance = defaultDistance;
    }

    float checkCameraCollision()
    {
        float mag = -1;

        Ray ray = new Ray(cameraProperties.getTargetFollow().position, -transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, -defaultDistance))
        {
            return (ray.origin - hit.point).magnitude;
        }

        return mag;
    }

}
