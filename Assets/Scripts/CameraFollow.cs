using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    public void SetTarget(IEntity entity)
    {
        target = entity.gameObject.transform;
    }

    void FixedUpdate()
    {
        if (target == null)
            return;

        Vector3 aimPosition = target.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, aimPosition, smoothSpeed);

        transform.position = smoothedPosition;

        transform.LookAt(target);
    }

}

