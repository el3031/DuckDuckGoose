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
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        rb.constraints = RigidbodyConstraints.None;
        transform.rotation = Quaternion.identity;
        gameObject.GetComponent<AudioSource>().Stop();
        gameObject
            .GetComponent<XRGrabInteractable>()
            .selectEntered
            .RemoveListener(GrabMushroom);
    }

    public void OnGrabFromGround(SelectEnterEventArgs interactor)
    {
        rb.constraints = RigidbodyConstraints.None;
        gameObject.GetComponent<AudioSource>().Stop();
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
        PlayerPrefs.SetInt("mushrooms", PlayerPrefs.GetInt("mushrooms", 1) - 1);
        gameObject.tag = "Mushroom";
        gameObject.GetComponent<AudioSource>().Stop();
        transform.parent = null;
        GetComponent<XRGrabInteractable>()
            .selectExited
            .RemoveListener(SetMushroomTag);
    }
}
