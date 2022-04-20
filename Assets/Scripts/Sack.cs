using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Sack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private StatsTracker stats;

    private int mushroomCount = 0;

    public GameObject mushroom;

    void Start()
    {
        // int mushrooms = stats.mushrooms;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnMushroom()
    {
        GameObject newMushroom = Instantiate(mushroom, transform);
        newMushroom.tag = "BaggedMushroom";
        Rigidbody rb = newMushroom.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        mushroomCount += 1;
        newMushroom.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        newMushroom.transform.localPosition = new Vector3(0, 0, 0);
        newMushroom
            .GetComponent<XRGrabInteractable>()
            .selectEntered
            .AddListener(newMushroom.GetComponent<Mushroom>().GrabMushroom);
        newMushroom
            .GetComponent<XRGrabInteractable>()
            .selectExited
            .AddListener(newMushroom.GetComponent<Mushroom>().SetMushroomTag);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Mushroom")
        {
            SpawnMushroom();
            Destroy(collision.gameObject);
            // stats.IncreaseMushroom();
        }
    }
}