using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsTracker : MonoBehaviour
{
    public int affection;
    public int mushrooms;
    [SerializeField] private Text affectionTracker;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void IncreaseAffection(int i)
    {
        affection += 1;
        affectionTracker.text = affection.ToString();
    }
}
