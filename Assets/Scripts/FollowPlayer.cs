using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    [SerializeField] private Transform playerSide;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float closeEnough;
    private Vector3 camPrevPos;
    [SerializeField] private float waitForSeconds;
    private float timeToGo;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //agent.updateRotation = true;
        anim = GetComponent<Animator>();
        camPrevPos = Camera.main.transform.position;

        timeToGo = Time.fixedTime + waitForSeconds;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.fixedTime >= timeToGo)
        {
            camPrevPos = Camera.main.transform.position;
            
            timeToGo = Time.fixedTime + waitForSeconds;
        }
    }
    
    void Update()
    {
        
        float cameraPosDelta = Vector3.Distance(Camera.main.transform.position, camPrevPos);
        if (cameraPosDelta >= closeEnough)
        {
            Vector3 temp = Camera.main.transform.position;
            Vector3 destination = new Vector3(temp.x, 0f, temp.z) + offset;
            
            agent.destination = destination;
            
            /*
            if (Vector3.Distance(transform.position, agent.destination) <= closeEnough)
            {
                anim.SetTrigger("idle");
                Debug.Log("setting idle");
            }
            else
            {
                anim.SetTrigger("walk");
                Debug.Log("setting walk");
            }
            */
            anim.SetTrigger("walk");
        }
        else
        {
            anim.SetTrigger("idle");
        }
    }
}
