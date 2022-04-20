using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Mushroom : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void GrabMushroom(SelectEnterEventArgs interactor)
    {
        transform.parent = null;
        transform.localScale = new Vector3(1, 1, 1);
        rb.constraints = RigidbodyConstraints.None;
        transform.rotation = Quaternion.identity;
        gameObject
            .GetComponent<XRGrabInteractable>()
            .selectEntered
            .RemoveListener(GrabMushroom);
    }

    public void OnGrabFromGround(SelectEnterEventArgs interactor)
    {
        rb.constraints = RigidbodyConstraints.None;
    }

    // public void GrabMushroom()
    // {
    //     rb.isKinematic = false;
    //     rb.useGravity = true;
    //     gameObject.tag = "Mushroom";
    //     transform.parent = null;
    //     transform.localScale = new Vector3(1, 1, 1);
    //     transform.rotation = Quaternion.identity;
    //     Debug.Log("ho");
    //     gameObject
    //         .GetComponent<XRGrabInteractable>()
    //         .selectEntered
    //         .RemoveListener(GrabMushroom);
    // }
    public void SetMushroomTag(SelectExitEventArgs interactor)
    {
        gameObject.tag = "Mushroom";
        GetComponent<XRGrabInteractable>()
            .selectExited
            .RemoveListener(SetMushroomTag);
    }
}