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
        affection = PlayerPrefs.GetInt("affection", 0);
        mushrooms = PlayerPrefs.GetInt("mushrooms", 0);
    }

    public void IncreaseAffection(int i)
    {
        affection += i;
        affectionTracker.text = affection.ToString();
    }
}
