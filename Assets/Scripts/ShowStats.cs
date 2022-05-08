using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStats : MonoBehaviour
{
    public Canvas canvas;

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float distance =
            Vector3.Distance(transform.position, cam.transform.position);
        Debug.Log (distance);
        if (distance < 4)
        {
            if (!canvas.enabled)
            {
                canvas.enabled = true;
            }
        }
        else
        {
            if (canvas.enabled)
            {
                canvas.enabled = false;
            }
        }
    }
}
