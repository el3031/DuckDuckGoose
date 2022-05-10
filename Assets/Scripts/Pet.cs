using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem hearts;

    [SerializeField]
    private float offset;

    [SerializeField]
    private StatsTracker stats;

    [SerializeField]
    private float growthFactor = 0.002f;

    private AudioSource happyDuck;

    private double size;

    // Start is called before the first frame update
    void Start()
    {
        happyDuck = GetComponent<AudioSource>();
        size = System.Math.Round(growthFactor * stats.hunger, 2) + 0.03f;
        transform.localScale =
            new Vector3((float) size, (float) size, (float) size);
    }

    void Update()
    {
        if (size != System.Math.Round(growthFactor * stats.hunger, 2) + 0.03f)
        {
            size = System.Math.Round(growthFactor * stats.hunger, 2) + 0.03f;
            transform.localScale =
                new Vector3((float) size, (float) size, (float) size);
        }
    }

    public void OnHoverEnter()
    {
        stats.IncreaseAffection(1);
        hearts.Play();
        if (!happyDuck.isPlaying)
        {
            happyDuck.Play();
        }
    }

    public void OnHoverExit()
    {
        happyDuck.Stop();
        Instantiate(hearts,
        transform.position + Vector3.up * offset,
        Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (
            other.gameObject.tag == "Mushroom" ||
            other.gameObject.tag == "BaggedMushroom"
        )
        {
            stats.IncreaseAffection(5);
            Instantiate(hearts,
            transform.position + Vector3.up * offset,
            Quaternion.identity);
            int hungerIncrease = (int) Mathf.Floor(Random.Range(6f,8f));
            stats.IncreaseHungerBar (hungerIncrease);
            Destroy(other.gameObject);

            //transform.localScale += Vector3.one * growthFactor;
        }
    }
}
