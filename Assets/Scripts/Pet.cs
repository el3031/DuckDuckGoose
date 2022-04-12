using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    [SerializeField] private ParticleSystem hearts;
    [SerializeField] private float offset;
    [SerializeField] private StatsTracker stats;
    private AudioSource happyDuck;

    // Start is called before the first frame update
    void Start()
    {
        happyDuck = GetComponent<AudioSource>();
    }

    public void OnHoverEnter()
    {
        stats.IncreaseAffection(1);
        hearts.Play();
        happyDuck.Play();
    }

    public void OnHoverExit()
    {
        happyDuck.Stop();
    }
}
