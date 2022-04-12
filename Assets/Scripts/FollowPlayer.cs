using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    [SerializeField] private Transform playerSide;
    [SerializeField] private float closeEnough;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = playerSide.position;
        Vector3 diff = agent.destination - transform.position;
        if (diff.magnitude <= closeEnough)
        {
            anim.SetTrigger("idle");
        }
        else
        {
            anim.SetTrigger("walk");
        }
    }
}
