using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCam : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(mainCamera.position.x, transform.position.y, mainCamera.position.z);
    }
}
