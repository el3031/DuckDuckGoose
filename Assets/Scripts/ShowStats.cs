using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStats : MonoBehaviour
{
    public Canvas canvas;

    public Camera cam;

    public float waitTime;

    public bool withinRange;

    public float oldDistance;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        waitTime += 0.02f;
        float distance =
            Vector3.Distance(transform.position, cam.transform.position);
        if (waitTime < 7)
        {
            if (!canvas.enabled) canvas.enabled = true;
        }
        else
        {
            if (canvas.enabled) canvas.enabled = false;
        }
        if (oldDistance > 4 && distance < 4)
        {
            if (!canvas.enabled) canvas.enabled = true;
            waitTime = 0;
        }
        oldDistance = distance;
    }
}
