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
        rb.constraints = RigidbodyConstraints.FreezePosition;
        mushroomCount += 1;
        newMushroom.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        newMushroom
            .GetComponent<XRGrabInteractable>()
            .selectEntered
            .AddListener(newMushroom.GetComponent<Mushroom>().GrabMushroom);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Mushroom")
        {
            Destroy(collision.gameObject);
            SpawnMushroom();
            // stats.IncreaseMushroom();
        }
    }
}
