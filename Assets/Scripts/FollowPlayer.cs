using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class FollowPlayer : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float closeEnough;

    public bool followBall;
    [SerializeField] private GameObject ball;
    [SerializeField] private Vector3 ballInMouth;
    [SerializeField] private Transform player;
    private Vector3 targetOldPosition;

    //debug purposes
    [SerializeField] private Text debugAgent;
    [SerializeField] private Text debugCamPos;
    [SerializeField] private Text debugBallPos;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        followBall = false;
    }
    
    float time;
    void Update()
    {
        Vector3 playerDestination = new Vector3(player.position.x, 0f, player.position.z) + offset;
        Vector3 ballDestination = ball.transform.position;
        Vector3 target = followBall ? ballDestination : playerDestination;

        
        time += Time.deltaTime;
        if (time >= 1f) {
            if (target != targetOldPosition) {
                Debug.Log("boi");
                NavMeshPath path = new NavMeshPath();
                Debug.Log("path exists " + agent.CalculatePath(target, path));
                bool success = agent.SetDestination (target);
                Debug.Log(success);
                Debug.Log(agent.pathStatus);
                targetOldPosition = target;
            }
            time = 0;
        }
        
        /*
        Vector3 playerDestination = player.position + offset;
        Vector3 ballDestination = ball.transform.position;
        agent.destination = followBall ? ballDestination : playerDestination;
        */
        debugAgent.text = "dest " + agent.destination.ToString();
        debugBallPos.text = "ballPos " + ballDestination.ToString();
        debugCamPos.text = "playerPos " + playerDestination.ToString();
        if (Vector3.Distance(transform.position, agent.destination) <= closeEnough)
        {
            anim.SetTrigger("idle");
            if (ball.transform.parent == transform)
            {
                ball.transform.parent = null;
                ball.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        else
        {
            anim.SetTrigger("walk");
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Ball") && followBall)
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.parent = transform;
            other.transform.localPosition = ballInMouth;
        }
        followBall = false;
    }
}
