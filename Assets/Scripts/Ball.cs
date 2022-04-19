using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private FollowPlayer duck;

    public void OnThrown()
    {
        duck.followBall = true;
    }
}
