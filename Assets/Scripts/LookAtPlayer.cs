using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cameraToLookAt;

    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform
            .LookAt(transform.position +
            cameraToLookAt.transform.rotation * Vector3.back,
            cameraToLookAt.transform.rotation * Vector3.up);
        transform.Rotate(0, 180, 0);
    }
}
