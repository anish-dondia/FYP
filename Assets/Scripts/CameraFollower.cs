using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;

    public float cameraLockOn = 0.25f;
    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 cleanPosition = Vector3.Lerp(transform.position, desiredPosition, cameraLockOn);
        transform.position = cleanPosition;
        Rotate();
    }

    void Rotate()
    {
        Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 2f, Vector3.up);
    }
}
